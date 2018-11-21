using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading;

namespace SeleniumTests
{
    [TestClass]
    public class TheMostAmazingWebsiteOnTheInternetTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void InitialiseDriver()
        {
            driver = new ChromeDriver(@"..\..\..");
            driver.Url = "http://www.themostamazingwebsiteontheinternet.com/";
        }

        [TestCleanup]
        public void QuitDriver()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestCorrectTitle()
        {
            Assert.AreEqual("!@#$!@@@@@@@ MY ISYS PROJECT @@@@@@!%#@!@", driver.Title);
        }

        [TestMethod]
        public void TestAutoplay()
        {
            var audioElement = driver.FindElement(By.TagName("audio"));
            Assert.IsTrue(audioElement.Enabled);
        }

        [TestMethod]
        public void TestDonateButton()
        {
            var DonateButton = driver.FindElement(By.Name("submit"));
            DonateButton.Click();
            Assert.IsTrue(driver.Url.StartsWith("https://www.paypal.com/donate"));
        }

        [TestMethod]
        public void TestEmailLink()
        {
            var emailLink = driver.FindElement(By.LinkText("mostamazingwebsiteoninternet@gmail.com"));
            var href = emailLink.GetAttribute("href");
            Assert.AreEqual(href, "mailto:mostamazingwebsiteoninternet@gmail.com");
        }

        [TestMethod]
        public void ClickMelGibsonTest()
        {
            var images = driver.FindElements(By.TagName("img"));
            var melGibson = images.Where(n => n.GetAttribute("src") == "http://farm4.static.flickr.com/3556/3697567084_e779c4aa14_o.jpg").Single();
            melGibson.Click();
            Assert.AreEqual(driver.Url, "http://www.cccoe.k12.ca.us/bats/good.htm");
        }

        [TestMethod]
        public void CheckTomCruiseIsNotReallyAWizard()
        {
            var text = driver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(text.Contains("tom cruise isnt actually a wizzard."));
        }

        [TestMethod]
        public void TestDoYouLikeGunsQuiz()
        {
            var containingDiv = driver.FindElements(By.TagName("div"))
                                      .Where(n => n.Text.Equals("I LIKE GUNZ DO YOU?!? FILL OUT MY GUN FORM!:\r\nDO YOU LIKE GUNS????")).Single();
            var submitFormButton = containingDiv.FindElements(By.TagName("input"))
                                                .Where(n=>n.GetAttribute("type") == "submit").Single();

            var choiceInput = driver.FindElement(By.Name("Choice"));
            choiceInput.Click();
            submitFormButton.Click();
            Assert.AreEqual(driver.Url, "http://www.themostamazingwebsiteontheinternet.com/");
        }
    }
}
