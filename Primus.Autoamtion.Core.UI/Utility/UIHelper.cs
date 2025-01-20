using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;
using static System.Net.Mime.MediaTypeNames;

namespace Primus.Autoamtion.Core.UI.Utility
{
    public class UIHelper
    {
        protected  IWebElement webElement,WebElement2;
        public IWebDriver driver=null;
        protected WebDriverWait wait;
        protected Actions actions;
        public UIHelper()
        {
            
        }

        #region UIWebMethod Handler
        public IWebElement FindWebElementByXpath(string xpath)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30); here I am implention explcit wait so ne need to user Implicit wait
            //  webElement = driver.FindElement(By.XPath(xpath));
            webElement = wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
            return webElement;
        }

        public void SetText( string XPath, string text)
        {
            webElement= FindWebElementByXpath(XPath);
            webElement.SendKeys(text);
        }

        public void ClickOnElement(string Xpath)
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webElement = FindWebElementByXpath(Xpath);
            webElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath))); ;
            webElement.Click();
        }

        // return visible text from a web element
        public string GetText(string Xpath) 
        {
            webElement = FindWebElementByXpath(Xpath);
            return webElement.Text;
        }
        public void ExitApp()
        {
            driver.Close();
            driver.Quit();
        }

        public void RedirectURL(string urlpath)
        {
            driver.Navigate().GoToUrl(urlpath);
            driver.Manage().Window.Maximize();
        }

        public void SelectByText(string xpath,string textval)
        {
            webElement =FindWebElementByXpath(xpath);
            SelectElement days = new SelectElement(webElement);
            days.SelectByText(textval);
        }

        public void SelectByValue(string xpath, string textval)
        {
            webElement = FindWebElementByXpath(xpath);
            SelectElement days = new SelectElement(webElement);
            days.SelectByValue(textval);
        }

        public void ClickOnRadio(string xpath)
        {
            webElement= FindWebElementByXpath(xpath);
            webElement.Click();
        }

        #endregion
        
        #region Action Class
        public void ActionInitilize()
        {
            actions = new Actions(driver);
        }

        public void MoveTOEelemnt(string xpath)
        {
            webElement=FindWebElementByXpath(xpath);
            ActionInitilize();
            actions.MoveToElement(webElement).Build().Perform();
        }

        public void ClickandSetText(string xpath,string value)
        {
            webElement=FindWebElementByXpath(xpath);
            ActionInitilize();
            actions.MoveToElement(webElement).Click().SendKeys(value).Build().Perform();
        }

        public void MouseHoveronElement(string xpath) 
        {
            webElement = FindWebElementByXpath(xpath);
            ActionInitilize();
            actions.MoveToElement(webElement).Perform();
        }

        public void DragandDrop(string sxpath, string dxpath) 
        { 
            webElement=FindWebElementByXpath(sxpath);
            WebElement2=FindWebElementByXpath(dxpath);  

            ActionInitilize();
            actions.DragAndDrop(webElement,WebElement2).Build().Perform();
        }

        #endregion

        #region Table Handler
        public int GetTotalColumn(string Xpath)
        {
            IList<IWebElement> tablecolumn = FindWebElementSByXpath(Xpath);

            int totalcolumn = tablecolumn.Count;

            return totalcolumn;
        }

        public int GetTotalRows(string Xpath)
        {
            IList<IWebElement> tablerows = FindWebElementSByXpath(Xpath);

            int totalrows = tablerows.Count;

            return totalrows;
        }

        public void GetTableColumnHeadername(string Xpath)
        {
            IList<IWebElement> tablecolumn = FindWebElementSByXpath(Xpath);

            int totalcolumn = tablecolumn.Count;

            foreach (IWebElement element in tablecolumn)
            {
                Console.WriteLine("Column Text " + element.Text);
            }
        }
        public IList<IWebElement> FindWebElementSByXpath(string xpath)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IList<IWebElement> webelements = driver.FindElements(By.XPath(xpath));
            return webelements;
        }
        #endregion

        #region Browser Helper

        //  it actually return current page title
        public string GetTitle()
        {  
            return driver.Title;
        }

        // this method will backward your web browser
        public void NavtoPrevPage()
        {
            driver.Navigate().Back();
        }

        // this method will Forward your web browser
        public void NavtoNextPage()
        {
            driver.Navigate().Forward();
        }
        #endregion
    }
}
