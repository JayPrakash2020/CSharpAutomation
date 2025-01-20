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
            helper.driver.Navigate().GoToUrl("https://billing.udeshatechnology.com/");
            helper.driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginPage()
        {
            Console.WriteLine("Title of the Page is "+helper.GetTitle());
            helper.SetText("//input[@id='email']", "rohan@udeshatechnology.com");
            Thread.Sleep(2000);

            helper.SetText("//input[@id='pass']", "1234567890");
            Thread.Sleep(2000);

            helper.ClickOnElement("//button[text()='Sign In']");
            Thread.Sleep(2000);

            helper.NavtoPrevPage();
            Thread.Sleep(3000);
            helper.ExitApp();
        }

        [Test]

        public void RegisterUser()
        {
            string registerurl = "https://www.facebook.com/r.php";

            helper.RedirectURL(registerurl);

            Thread.Sleep(2000);
            helper.NavtoPrevPage();
            Thread.Sleep(2000);
            helper.NavtoNextPage();
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

        [Test]
        public void DynamicTable()
        {

            helper.RedirectURL("https://cosmocode.io/automation-practice-webtable/");
            helper.MoveTOEelemnt("//table[@id='countries']");
            int columncount = helper.GetTotalColumn("//table[@id='countries']//tbody//tr[1]//td"); // for table column xpath
            Console.WriteLine("Total column is " + columncount);


            int rowcount = helper.GetTotalRows("//table[@id='countries']//tbody//tr");

            Console.WriteLine("Total number of rows is " + rowcount);

            helper.GetTableColumnHeadername("//table[@id='countries']//tbody//tr[1]//td");


            helper.ClickOnElement("(//tr//td[contains(text(),'New Delhi')])//..//preceding-sibling::td//input");
            Thread.Sleep(5000);
            helper.ExitApp();

        }
    }
}
