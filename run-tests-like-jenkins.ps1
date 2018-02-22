param(
    $TestFilter = "cat=~.*"
)

$ErrorActionPreference = "Stop"
$BuildConfiguration = "Release"
$NugetVersion = "latest"
$GitVersionVersion = "3.6.5"

$currentFolder = $PWD.Path
$buildToolsFolder = "$currentFolder/build-tools"
$buildMetaDataFolder = "$buildToolsFolder/build-data"
$buildArtifactsFolder = "$buildToolsFolder/build-artifacts"    
$LogsFolder = "$buildToolsFolder/build-logs"
$nugetFolder = "$buildToolsFolder/nuget"
$nugetPackagesFolder = "$nugetFolder/packages"
$dotnetFolder = "$ENV:TEMP/dotnet/$DotnetCoreSDKVersion" -replace "\.", "_"
$testResultsFolder = "$buildToolsFolder/test-results"
$octopusToolsFolder = "$buildToolsFolder\OctopusTools"
$buildOutputFolder = "$buildToolsFolder\build-output"    

$buildTxtFile = "$buildMetaDataFolder\build.txt"
$versionInfoFile = "$buildMetaDataFolder/gitversion.json"

function New-EmptyFolder {
    param(
        [string]
        $Path
    )
    if (Test-Path -Path $Path) {
        Remove-Item -Path $Path -Recurse -Force | Out-Null
    }
    New-Item -Path $Path -ItemType Directory -Force | Out-Null
}

function Read-Nuget {
    param(
        [parameter(Mandatory = $true)]
        [String]
        $InstallPath,

        [parameter()]    
        [String]
        $Version = "latest"
    )

    Read-InternetFile -Source "https://dist.nuget.org/win-x86-commandline/$Version/nuget.exe" -DestinationFolder $InstallPath
}

function Read-InternetFile {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Source,
        
        [Parameter(Mandatory = $true)]
        [string]$DestinationFolder    
    )
    begin {
        function download($src, $dst) {            
            $wc = New-Object System.Net.WebClient
            $wc.DownloadFile($src, $dst)
        }
    }
    process {
        if (!(Test-Path $DestinationFolder)) {
            mkdir $DestinationFolder | Out-Null
        }       
        $fileName = [System.IO.Path]::GetFileName($Source)
        $downloadPath = Join-Path -Path $DestinationFolder -ChildPath $fileName        
        download -src $Source -dst $downloadPath
        Get-ChildItem -Path $downloadPath    
    }
}

function New-BuildToolsInstall {    

    #New-EmptyFolder -Path $buildToolsFolder
    New-EmptyFolder -Path $LogsFolder
    New-EmptyFolder -Path $buildMetaDataFolder 
    New-EmptyFolder -Path $buildArtifactsFolder
    New-EmptyFolder -Path $testResultsFolder
    New-EmptyFolder -Path $octopusToolsFolder
    New-EmptyFolder -Path $buildOutputFolder

    $nugetExe = Read-Nuget -InstallPath $nugetFolder -Version $NugetVersion  
   
    & $nugetExe install GitVersion.CommandLine -Version $GitVersionVersion -OutputDirectory `"$nugetPackagesFolder`"
    & $nugetExe restore
    if ($LASTEXITCODE -ne 0) {
        throw "Install of gitversion commandline failed"
    }
}
function New-GitVersionPropertiesFile {
    
    $gitversionExe = "$nugetPackagesFolder/Gitversion.CommandLine.$GitVersionVersion/tools/Gitversion.exe"
    & $gitversionExe /output buildserver | Out-Null
    $versionInfo = (& $gitversionExe) | ConvertFrom-Json
    if ($LASTEXITCODE -ne 0) {
        throw "Gitversion Failed" 
    }    
    ConvertTo-Json $versionInfo | Set-Content -Path $versionInfoFile
    $versionInfo
}

function New-BuildTxtMetaDataFile {
    
    $versionInfo = get-content -Path $versionInfoFile -Raw | ConvertFrom-Json

    
    $CurrentDate = get-date -Format "r"
    $bNumber = $versionInfo.InformationalVersion + ".$BuildNumber";
    Set-Content -Value "build-number: $bNumber" -Path $buildTxtFile -Encoding UTF8
    Add-Content -Value ("commit-date: " + $versionInfo.CommitDate) -Path $buildTxtFile -Encoding UTF8
    Add-Content -Value "build-date: $CurrentDate" -Path $buildTxtFile -Encoding UTF8
    write-host (get-content "$buildTxtFile" -Raw)
}

function Run-MsBuild {
    $msbuild = (gci "${ENV:Programfiles(x86)}\MSBuild\14.0\bin\msbuild.exe").FullName
    & $msbuild /p:Configuration=$BuildConfiguration
}

function Run-Nunit {
    param(
        $Filter = "cat=~.*"
    )


    $nunit = (gci -Recurse -Include nunit3-console.exe).FullName  

    Get-ChildItem -Recurse -Filter *.csproj `
        | ForEach-Object {
        [xml]$p = get-content -Path $_.FullName
        if (($p.Project.ItemGroup.Reference.Include | Where-Object {$_ -match "^nunit\.framework"}).Count -Gt 0) {
            $dllName = [System.IO.Path]::GetFileNameWithoutExtension($_.FullName) + ".dll"
            $dllFileName = (Join-Path -Path $_.DirectoryName -ChildPath "bin/$BuildConfiguration/$dllName")
            if (Test-Path -Path $dllFileName) {
                write-host $dllFileName
                $dllFileName
            }
        }
    } `
        | ForEach-Object { 
        $resultFile = [System.IO.Path]::GetFileName($dllFileName + ".results.xml")   

        & $nunit $_  --where="`"$Filter`"" 
        if ($LASTEXITCODE -ne 0) {
            throw "Tests failed"
        }
    }
}

git clean -fdx
New-BuildToolsInstall
New-GitVersionPropertiesFile
New-BuildTxtMetaDataFile
Run-MsBuild
Run-Nunit -Filter $TestFilter