using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Primus.Autoamtion.Core.UI.Utility;

namespace Primus.Autoamtion.Core.UI
{
    [TestFixture]
    public class ExtentManager
    {
        public IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
 

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
        }
        [OneTimeSetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var htmlreport = new ExtentSparkReporter(path+@"\extent.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlreport);
            extent.AddSystemInfo("Host Name", "Jay Prakash");
            extent.AddSystemInfo("Browser", "Chrome");

        }
        [Test]
        public void BrowserTest()
        {
            test = null;
            test = extent.CreateTest("Register User on Facebook").Info("Browser test");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com/r.php");
            test.Log(Status.Info,"Go to Facebook Register URL");

            Thread.Sleep(2000);
            IWebElement uname = driver.FindElement(By.XPath("//input[@name='firstname']"));
            uname.SendKeys("Jay Prakash"); ;
            
            test.Log(Status.Pass, "Able to Enter Username");
           
        }
        [TearDown]
        public void CloseBroser()
        {
            driver.Close();
            driver.Quit();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }
    }
}
