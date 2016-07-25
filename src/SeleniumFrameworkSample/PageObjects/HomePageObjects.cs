
namespace SeleniumFrameworkV2Sample.PageObjects
{
    class HomePageObjects : BasePageObjects
    {
        #region Elements

        #endregion

        #region Methods
        public bool isLogoLinkPresent()
        {
            return logoLink.IsElementDisplayed();
        }

        #endregion

    }
}
