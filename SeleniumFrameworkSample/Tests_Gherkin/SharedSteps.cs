using SeleniumFrameworkV2Sample.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkV2Sample.Tests_Gherkin
{
    public class SharedSteps
    {
        protected LoginPageObjects loginPage;

        public SharedSteps()
        {
            loginPage = new LoginPageObjects();
        }
    }
}
