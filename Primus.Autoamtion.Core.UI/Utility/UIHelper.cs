using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
        protected WaitHandle wait;
        protected Actions actions;
        public UIHelper()
        {
           
        }

        #region UIWebMethod Handler
        public IWebElement FindWebElementByXpath(string xpath)
        {
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30);
            webElement = driver.FindElement(By.XPath(xpath));
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
    }
}
