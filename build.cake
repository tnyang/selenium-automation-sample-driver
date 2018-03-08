#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0-beta.13"
#addin nuget:?package=Cake.Json
#addin nuget:?package=Newtonsoft.Json&version=9.0.1
#addin "Cake.FileHelpers"
#tool "nuget:?package=OctopusTools"
#tool "nuget:?package=GitReleaseNotes"
#tool "nuget:?package=NUnit.ConsoleRunner"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var solutionFile = "Automation-FrameworkV2-Samples.sln";
var projectName = "SeleniumFrameworkV2Sample";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

GitVersion gitVersionInfo = null;

// Define directories.
var buildToolsDirectory = Directory("build-tools");
var testResultsDirectory = buildToolsDirectory + Directory("test-results");
var buildArtifactsDirectory = buildToolsDirectory + Directory("build-artifacts");
var buildOutputDirectory = buildToolsDirectory + Directory("build-output");
var buildMetaDataDirectory = buildOutputDirectory + Directory("build-metadata");
var buildLogDirectory = buildOutputDirectory + Directory("build-log");

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildToolsDirectory);
    CleanDirectory(buildOutputDirectory);
    CleanDirectory(buildArtifactsDirectory);
    CleanDirectory(buildMetaDataDirectory);
    CleanDirectory(testResultsDirectory);
    CleanDirectory(buildLogDirectory);
	Information("Build data files has been cleaned."); 
});


Task("Calculate-SemVer")
    .IsDependentOn("Clean")
    .Does(()=>
{
    ReplaceRegexInFiles("./**/AssemblyInfo.cs", "\\[assembly: Assembly.*Version.*\\]","");    
    gitVersionInfo = GitVersion(new GitVersionSettings{
        UpdateAssemblyInfo=true,
        OutputType=GitVersionOutput.Json
    });
    var gvTxt = SerializeJsonPretty(gitVersionInfo);
    var gvTxtFileName = buildMetaDataDirectory + File("gitversion.json");
    FileWriteText(gvTxtFileName, gvTxt);
	Information("gitversion.json - has been created with Git Version info:" ); 
    Information(FileReadText(gvTxtFileName));  
	
	 var isJenkinsBuild = Jenkins.IsRunningOnJenkins;
    if(isJenkinsBuild) {
        Information("Started setting Jenkins Build display name");             
        var jobName = $"\"{Jenkins.Environment.Job.JobName}\"";
        var buildNumber = Jenkins.Environment.Build.BuildNumber;        
        var displayname = gitVersionInfo.FullSemVer;
        var jenkinsUrl = Jenkins.Environment.JenkinsUrl;
        var javaCliFile = buildToolsDirectory + File("jenkins-cli.jar");
        DownloadFile($"{jenkinsUrl}/jnlpJars/jenkins-cli.jar", javaCliFile);
        
        var settings = new ProcessSettings()
            .WithArguments(args=>{                
                args.Append("-jar")
                    .Append(javaCliFile.Path.FullPath)
                    .Append("-s")
                    .Append(jenkinsUrl)
                    .Append("-auth")
                    .Append($"jenkinscli:{EnvironmentVariable("JENKINS_CLI_APIKEY")}")
                    .Append("set-build-display-name")
                    .Append(jobName)
                    .Append(buildNumber.ToString())
                    .Append(displayname);
            });
        var exitCode = StartProcess("java", settings);
        if(exitCode != 0 ){
            throw new Exception("Unable to set build name");
        }
	}
		
});

Task("Restore-Packages")
    .Does(() =>
{
    var settings = new NuGetRestoreSettings();
    //var SlnFiles = GetFiles("./**/*.sln");
    NuGetRestore(solutionFile, settings);
});

Task("Create-BuildMetadata")
    .IsDependentOn("Clean")
    .IsDependentOn("Calculate-SemVer")  
    .Does(()=>
{
    
});


Task("Compile-Sources")
    .IsDependentOn("Create-BuildMetaData")
    .IsDependentOn("Restore-Packages")
    .Does(() =>
{
    var settings = new MSBuildSettings {
        Configuration = configuration,
        ToolVersion = MSBuildToolVersion.VS2015
    };
    settings.AddFileLogger(
        new MSBuildFileLogger{
            AppendToLogFile = true,
            LogFile = buildLogDirectory + File("dotnet-build.log.txt")
        });
    MSBuild(solutionFile, settings );
});

Task("Run-NUnit-Tests")    
    .IsDependentOn("Compile-Sources")
    .Does(() =>
{
	var resultsFile = testResultsDirectory + File("result.xml");
    NUnit3(new [] {$"./bin/Debug/{projectName}.dll" }, new NUnit3Settings {
	Results = new[] { new NUnit3Result { FileName = resultsFile } },
	Where = "cat==SampleTest"
    });
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);





