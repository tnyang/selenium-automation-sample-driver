REQUIREMENTS FOR CREATING CONFIGURATION FILES:

	1. Do not delete the AppConfigs directory as it is used by framework!!!
	2. The config file must be a json file with key/value pair
		Example:
			{
				"Browser": "Chrome",
				"BrowserResolution": "Max",
				"EnvironmentUrl": "https://hgtestweb12.healthgrades.com",
				"ImplicitlyWaitSeconds": "60",
				"ScreenshotOnError": "True"
			}
	3. You can add as many folders/subfolders under the AppConfigs directory as you want
		Example:
			AppConfigs/MyFolder1/MyFolder2/MyFolder3 etc....
			AppConfigs/Uat
			AppConfigs/Dev/Regression
	4. Each config file must be named uniquely!!!!
		- You can not have multiple config file with same name such as 'myapp.config' even though they are in 
		  different directories such as:
				AppConfigs/Dev/myapp.config 
				AppConfigs/Test/myapp.config
				AppConfigs/Test/Regression/Main/myapp.config

		- Recommendation is use to name each config file prefix with the environment such as:
			AppConfigs/Dev/dev-myapp.config
			AppConfigs/Test/test-myapp.config
			AppConfigs/Test/Regression/test-regression-myapp.config