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
            helper.SetText("//input[@name='firstname']", "Jay Prakash");
            helper.SetText("//input[@name='lastname']", "Pathak");
            helper.MouseHoveronElement("//a[@id='birthday-help']");
            Thread.Sleep(3000);
            helper.SelectByValue("//select[@id='day']","17");
            helper.SelectByValue("//select[@id='month']", "3");
            helper.SelectByValue("//select[@id='year']", "1988");
            helper.ClickOnRadio("//input[@value='2']");
            helper.ClickandSetText("//input[@name='reg_email__']", "jayprakashutw@gmail.com");
            helper.SetText("//input[@name='reg_passwd__']","12345678");
            Thread.Sleep(5000);
            helper.MoveTOEelemnt("//button[@name='websubmit']");
            Thread.Sleep(5000);
            helper.ClickOnElement("//button[@name='websubmit']");

            helper.ExitApp();
        }
    }
}