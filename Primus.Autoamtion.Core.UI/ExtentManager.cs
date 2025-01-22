using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
namespace Primus.Autoamtion.Core.UI
{
    [SetUpFixture]
    public class ExtentManager
    {
        public static ExtentReports extent;
        public static ExtentTest? test;

        [OneTimeSetUp]
        public void Setup()
        {
           // string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var htmlreport = new ExtentHtmlReporter("extent.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlreport);
            extent.AddSystemInfo("Host Name", "Jay PRakash");
            extent.AddSystemInfo("Browser", "Chrome");

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }
    }
}
