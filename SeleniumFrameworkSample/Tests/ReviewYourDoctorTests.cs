using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class ReviewYourDoctorTests : WebDriverTestBase
    {
     
        [Test]
        [Category("ReviewYourDoctorTests")]
        public void SearchDoctorReviews()
        {
            ReviewYourDoctorPageObjects reviewDocPage = new ReviewYourDoctorPageObjects();
            reviewDocPage.OpenPage("/doctor-reviews");
            ReviewYourDoctorResultsPageObjects reviewResultsPage = reviewDocPage.SearchDoctor("family medicine", "80031");

            Assert.IsTrue(reviewResultsPage.isResultsMessagePresent(),"FAILED - The result label searching for 'Family Medicine' not found!");
        }



    }
}
