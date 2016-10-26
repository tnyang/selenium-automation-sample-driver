﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Ams.Acceptance.Testing.Solr
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AppointmentManagementSolrTests")]
    [NUnit.Framework.CategoryAttribute("SolrTests")]
    public partial class AppointmentManagementSolrTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AppointmentManagementSolrTests.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AppointmentManagementSolrTests", "\tRun Solr queries agains ProviderAppointment  and ProviderAppointmentFull cores", ProgrammingLanguage.CSharp, new string[] {
                        "SolrTests"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Removed Timeslot _MHD")]
        [NUnit.Framework.TestCaseAttribute("providerappointmentfull", new string[0])]
        [NUnit.Framework.TestCaseAttribute("providerappointment", new string[0])]
        public virtual void GetRemovedTimeslot_MHD(string solrCore, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Removed Timeslot _MHD", exampleTags);
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
    testRunner.Given("I have prepared an api request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.And("the solrNode is slave", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And(string.Format("the solrCore is {0}", solrCore), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("the url is /select?q=timeslot_id%3A+TIMESLOTID&fq=schema_type%3ATIMESLOT&wt=json&" +
                    "indent=true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("the fileName is MHD <slotIdMHD.txt>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("the request is sent as a GET", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("the response should NOT contain removed timeslot", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Added Timeslot _MHD")]
        [NUnit.Framework.TestCaseAttribute("providerappointmentfull", new string[0])]
        [NUnit.Framework.TestCaseAttribute("providerappointment", new string[0])]
        public virtual void GetAddedTimeslot_MHD(string solrCore, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Added Timeslot _MHD", exampleTags);
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
    testRunner.Given("I have prepared an api request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.And("the solrNode is slave", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("the solrCore is providerappointment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("the url is /select?q=timeslot_id%3A+SLOTID&fq=schema_type%3ATIMESLOT&wt=json&inde" +
                    "nt=true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("the fileName is MHD <MHDDateTime.txt>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("the request is sent as a GET", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("the response should contain added timeslot", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
