using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagProject.Driver;

namespace SwagProject.Pages
{
    public class ProductPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement AddBackPack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement AddT_Shirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement Cart => driver.FindElement(By.CssSelector("#shopping_cart_container .shopping_cart_badge"));

        public IWebElement SortByByPrice => driver.FindElement(By.ClassName("product_sort_container"));

        public IWebElement MenuClick => driver.FindElement(By.Id("react-burger-menu-btn"));

        public IWebElement AboutClick => driver.FindElement(By.Id("about_sidebar_link"));

        public IWebElement ShoppingCartClick => driver.FindElement(By.Id("shopping_cart_container"));

        public void SelectOptions(string text)
        {
            SelectElement element = new SelectElement(SortByByPrice);
            element.SelectByText(text);
        }
    }
}
