using Healthgrades.TestAutomation.SeleniumFramework.Configuration;
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public abstract class BasePageObjects
    {
        #region Header Element Objects
        public HyperlinkObject logoLink = new HyperlinkObject("logoLink", BaseLocators.logoLinkLocator);
        public TextFieldObject universalSearch = new TextFieldObject("universalSearch", BaseLocators.universalSearchLocator);
        #endregion

        #region Footer Element Objects
        public OtherObject loadingBar = new OtherObject("loadingBar", BaseLocators.loadingBarLocator);

        #endregion


        public void OpenPageBypassingModal(string pageUrl)
        {
            var providerProfilePage = new ProviderProfileObjects();

            //Console.WriteLine(">>>>> GoToUrl: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
            //WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl + "?$.core.enableNewsletterModal = false");
            WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl + "?$.core.newsletterModalTriggers = ''");
            //ClearLocalStorage();
            //providerProfilePage.MoveToFooterSection();
            //providerProfilePage.MoveToHamburger();
            //providerProfilePage.ClickCloseNewsletterModalOnSignUpModal();           
        }

        public void OpenPage(string pageUrl)
        {
                WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
                Console.WriteLine("Go to url: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);            
        }
        public void OpenGooglePage(string pageUrl)
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl("https://www.google.com/" + pageUrl);            
        }
        public bool DoesSearchFieldPresent()
        {
            return universalSearch.IsElementDisplayed();
        }

        public void OpenHtmlPage(string htmlPage)
        {
            var codebase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codebase);
            var codebasepath = Uri.UnescapeDataString(uri.Path);
            var directoryname = Path.GetDirectoryName(codebasepath);

            var fullPathToHtmlFile = SearchForHtmlFile(htmlPage, directoryname);

            Console.WriteLine("***** Using html file: " + fullPathToHtmlFile);

            WebDriverTestBase.Driver.Navigate().GoToUrl(fullPathToHtmlFile);
            Console.WriteLine("Go to html url: " + fullPathToHtmlFile);
        }


        private string SearchForHtmlFile(string htmlPage, string directoryname)
        {
            var fullPathToConfigFile = Path.GetFullPath(Path.Combine(directoryname) + @"\..\..\Html");
            string[] configFiles = Directory.GetFiles(fullPathToConfigFile, htmlPage, SearchOption.AllDirectories);

            if (configFiles.Length == 1)
            {
                //Console.WriteLine("Search File: " + configFiles[0]);
                return configFiles[0].ToString();
            }
            else if (configFiles.Length == 0)
            {
                throw new Exception("****** The configuration file does not exists in the 'Html' directory: " + htmlPage);
            }
            else if (configFiles.Length > 1)
            {
                string exmessage = "\n****** There are multiple file with same name: " + htmlPage + "\n" +
                                    "****** Configuration files must have unique name!" + "\n" + "****** Found files:";
                string fmessage = "";

                int cnt = 1;
                foreach (string s in configFiles)
                {
                    fmessage = fmessage + "\t" + cnt++ + " - " + s + "\n";
                }

                throw new Exception(exmessage + "\n" + fmessage);
            }

            return null;
        }
    }
}
