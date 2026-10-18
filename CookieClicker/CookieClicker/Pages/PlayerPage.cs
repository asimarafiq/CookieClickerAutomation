using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace CookieClicker.Tests.Pages
{
    public class PlayerPage
    {
        private readonly IPage _page;

        // Locators
        private const string CookieCount = "#cookies";
        private const string FactoryCount = "#factories";
        private const string MoneyBalance = "#money";
        private const string ClickCookieButton = "#click";
        private const string CookiesToSellInput = "#cookies-to-sell";
        private const string SellCookiesButton = "#sell-cookies";
        private const string FactoriesToBuyInput = "#factories-to-buy";
        private const string BuyFactoriesButton = "#buy-factories";

        public PlayerPage(IPage page)
        {
            _page = page;
        }

        public async Task CheckGamePageForPlayerAsync(string playerName)
        {
            await _page.WaitForURLAsync("**/game/**");

            await Assertions.Expect(
                _page.GetByText(
                    $"Hello {playerName}",
                    new() { Exact = true }))
                .ToBeVisibleAsync();
        }

        public async Task ClickCookieAsync()
        {
            await _page.Locator(ClickCookieButton).ClickAsync();
        }

        public async Task ClickCookieAsync(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                await ClickCookieAsync();
            }
        }

        public async Task SellCookiesAsync(string quantity)
        {
            quantity = quantity.Replace("[blank]", "").Trim();
            await _page.Locator(CookiesToSellInput).FillAsync(quantity);
            await _page.Locator(SellCookiesButton).ClickAsync();
        }

        public async Task BuyFactoriesAsync(string quantity)
        {
            quantity = quantity.Replace("[blank]", "").Trim();
            await _page.Locator(FactoriesToBuyInput).FillAsync(quantity);
            await _page.Locator(BuyFactoriesButton).ClickAsync();
        }

        public async Task CheckCookiesFactoriesAndMonies(int expectedCookies, int expectedFactories, decimal expectedMoney)
        {
            await CheckCookieCountAsync(expectedCookies);
            await CheckFactoryCountAsync(expectedFactories);
            await CheckMoneyBalanceAsync(expectedMoney);
        }

        public async Task CheckCookieCountAsync(int expectedCookies)
        {
            var cookieCount = _page.Locator(CookieCount);
            await Assertions.Expect(cookieCount, $"Expected cookie count to be {expectedCookies}.").ToHaveTextAsync(expectedCookies.ToString());
        }

        public async Task CheckFactoryCountAsync(int expectedFactories)
        {
            await _page.WaitForTimeoutAsync(1000);
            var factoryCount = _page.Locator(FactoryCount);
            await Assertions.Expect(factoryCount, $"Expected factory count to be {expectedFactories}.").ToHaveTextAsync(expectedFactories.ToString());
        }

        public async Task CheckMoneyBalanceAsync(decimal expectedMoney)
        {
            string expectedMoneyText = NormaliseMoney(expectedMoney.ToString());
            var moneyBalance = _page.Locator(MoneyBalance);
            await Assertions.Expect(moneyBalance, $"Expected money balance to be {expectedMoney}.").ToHaveTextAsync(expectedMoneyText);
        }

        public async Task CheckFactoriesAndMoneyAsync(int expectedFactories, decimal expectedMoney)
        {
            await CheckFactoryCountAsync(expectedFactories);
            await CheckMoneyBalanceAsync(expectedMoney);
        }

        public string NormaliseMoney(string value)
        {
            if (decimal.TryParse(
                value,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal money))
            {
                return money.ToString("0.##", CultureInfo.InvariantCulture);
            }

            return value;
        }
    }
}