using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Primus.Autoamtion.Core.UI.Utility;

namespace Primus.Autoamtion.Core.UI
{
    public class Tests:UIHelper
    {
        IWebElement username = null;
        UIHelper helper = new UIHelper();
       
        [SetUp]
        public void Setup()
        {
            helper.driver= new ChromeDriver();
            helper.driver.Navigate().GoToUrl("https://www.facebook.com/");
            helper.driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginPage()
        {
            helper.SetText("Jay Prakash Pathak","//input[@id='email']");
            Thread.Sleep(5000);

            helper.ClickOnElement("//button[@name='login']");
            Thread.Sleep(5000);
            helper.ExitApp();
        }

        [Test]

        public void RegisterUser()
        {
            string registerurl = "https://www.facebook.com/r.php";

            helper.RedirectURL(registerurl);
            helper.SetText("Jay Prakash", "//input[@name='firstname']");
            helper.SetText("Pathak", "//input[@name='lastname']");
            helper.SelectByValue("//select[@id='day']","17");
            helper.SelectByValue("//select[@id='month']", "3");
            helper.SelectByValue("//select[@id='year']", "1988");
            helper.ClickOnRadio("//input[@value='2']");
            helper.SetText("jayprakashutw@gmail.com", "//input[@name='reg_email__']");
            helper.SetText("12345678", "//input[@name='reg_passwd__']");
            Thread.Sleep(5000);
            helper.ClickOnElement("//button[@name='websubmit']");

            helper.ExitApp();
        }
    }
}