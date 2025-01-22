using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.Page;
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

        #region Assertion and Wait Helper
        public void AssertContainTextByXpath(string xpath, string expectedresult)
        {
            webElement = FindWebElementByXpath(xpath);
            webElement.Text.Should().Contain(expectedresult,"Element found using Xpath "+xpath);
        }
        
        public void AreEqualValue(string value1, string value2)
        {
            Assert.That(value1, Is.EqualTo(value2));
        }

        public void WaitUntilElementsExists(string elementxpath)
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(elementxpath)));
        }


        #endregion

        #region Element with JavaScript Events
        public void ClickByJS(string xpath)
        {
            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(20));
            try
            {
                //wait until element exists
                wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
                //wait until element visible
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

                //scroll to the element to view using JavaScript 

                webElement = FindWebElementByXpath(xpath);

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);",webElement);

                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                //wait until element clickalbe
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

                try
                {
                    webElement.Click();
                }
                catch(ElementClickInterceptedException)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", webElement);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepion is "+ex);
            }
        }

        public void ScrollToButtom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }
        public void ScrollToTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.documentElement.scrollTop=0;");
        }

        #endregion

        #region wait and  retry method

        public void WaitandClickWithRetry(string xpath, int maxRetries=3)
        {
            wait =new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            bool isElementCLicked = false;
            
            for(int attempt=1;attempt<=maxRetries;attempt++)
            {
                driver.Navigate().Refresh();
                try
                {
                    try
                      {
                        webElement= FindWebElementByXpath(xpath);
                        if(webElement.Displayed && webElement.Enabled)
                         {
                           webElement.Click();
                           Console.WriteLine("Element is CLicked");
                           isElementCLicked = true;
                         }
                      }
                     catch(NoSuchElementException)
                     {
                                
                     }
                }
                
                catch( WebDriverTimeoutException)
                {
                    if(attempt==maxRetries)
                    {
                        Console.WriteLine($"Object is not found after {maxRetries} attempts.");
                        throw;
                    }

                    Console.WriteLine($"Attempt  {attempt} failded. Retrying ...");
                }
            }
        }

        public void WaitandCheckTextwithRetry(string xpath, string expectedtext, int maxretries=3)
        {
            for(int attempt=1;attempt<=maxretries;attempt++)
            {
                driver.Navigate().Refresh();

                try
                {
                    webElement = FindWebElementByXpath(xpath);
                    if(webElement.Displayed && webElement.Text.Contains(expectedtext))
                    {
                        Console.WriteLine($" Text {expectedtext} found within element");
                    }
                    else
                    {
                        throw new WebDriverTimeoutException();
                    }
                }
                catch(WebDriverTimeoutException)
                {
                    if (attempt == maxretries)
                    {
                        Console.WriteLine($"Text {expectedtext} not found after {maxretries} attempts.");
                        throw;
                    }

                    Console.WriteLine($"Attempt  {attempt} failded. Text {expectedtext} not found Retrying ...");
                }
            }
        }
        #endregion

        #region screenshot
        // to use screenshot method first we need to implement extent report
        //public void AddScreenShot(IWebDriver driver, ScenarioContext)
        //{
        //    ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
        //    Screenshot screenShot = takesScreenshot.GetScreenshot();
        //    string screenshotlocation = Path.Combine();
        //}
        #endregion
    }
}
