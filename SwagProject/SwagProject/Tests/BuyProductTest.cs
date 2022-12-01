using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using SwagProject.Driver;
using SwagProject.Pages;

namespace SwagProject.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        CartPage cartPage;

        [SetUp]
        public void Setup()
        {

            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cartPage = new CartPage();  
        }

        [TearDown]
        public void TearDown()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddTwoProductInCart_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2",Is.EqualTo(productPage.Cart.Text));


        }
        [Test]

        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.SelectOptions("Price (high to low)");

            Assert.That(productPage.SortByByPrice.Displayed);

        }

        [Test]
        public void TC03_GoToAboutPage_ShouldRedirectToNewPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]

       public void TC04_BuyProducts_ShouldBeFinishedShopping()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();
            productPage.ShoppingCartClick.Click();


            cartPage.Checkout.Click();
            cartPage.FirstName.SendKeys("Petar");
            cartPage.LastName.SendKeys("Matic");
            cartPage.ZipCode.SendKeys("11000");
            cartPage.ButonContinue.Submit();

            cartPage.Finish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(cartPage.OrderFinished.Text));
        }
            
    }

   
}
