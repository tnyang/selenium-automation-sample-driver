
namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class HomePageObjects : BasePageObjects
    {
        #region Elements
        #endregion

        #region Methods
        public bool isLogoLinkPresent()
        {
            return logoLink.IsElementDisplayed();
        }

        public string GetViewSourceCode()
        {
            return logoLink.GetAttribute("innerHTML");
        }
        #endregion

    }
}
