using CookieClicker.Tests.Pages;
using Microsoft.Playwright;
using System.Net;

namespace CookieClicker.StepDefinitions
{
    [Binding]
    public class GamePlayStepDefinitions
    {
        private readonly PlayerPage _playerPage;
        public GamePlayStepDefinitions(IPage page)
        {
            _playerPage = new PlayerPage(page);
        }

        [Given("the game has {int} cookies, {int} factories and {string} money")]
        [When("the game has {int} cookies, {int} factories and {string} money")]
        [Then("the game has {int} cookies, {int} factories and {string} money")]
        public async Task GivenTheGameHasCookiesFactoriesAndMoney(int cookies, int factories, string money)
        {
            var expectedMoney = decimal.Parse(money, System.Globalization.CultureInfo.InvariantCulture);
            await _playerPage.CheckCookiesFactoriesAndMonies(cookies, factories, expectedMoney);
        }

        [When("I click the cookie button {int} times")]
        public async Task GivenIClickTheCookieButtonTimes(int quantity)
        {
            await _playerPage.ClickCookieAsync(quantity);
        }

        [Then("the factory count should be {int}")]
        public async Task ThenTheFactoryCountShouldBe(int expectedFactories)
        {
            await _playerPage.CheckFactoryCountAsync(expectedFactories);
        }

        [Then("the money balance should be ${int}")]
        public async Task ThenTheMoneyBalanceShouldBe(int expectedMoney)
        {
            await _playerPage.CheckMoneyBalanceAsync(expectedMoney);
        }

        [Given("I click the cookie button {int} times")]
        public async Task WhenIClickTheCookieButtonTimes(int quantity)
        {
            await _playerPage.ClickCookieAsync(quantity);
        }

        [When("I sell (.*) cookies")]
        public async Task WhenISellCookies(string quantity)
        {
            await _playerPage.SellCookiesAsync(quantity);
        }

        [When("the cookie count should be {int}")]
        [Then("the cookie count should be {int}")]
        public async Task ThenTheCookieCountShouldBe(int expectedCookies)
        {
            await _playerPage.CheckCookieCountAsync(expectedCookies);
        }

        [When("I buy (.*) factory")]
        public async Task WhenIBuyFactory(string quantity)
        {
            await _playerPage.BuyFactoriesAsync(quantity);
        }

        [When("the game has {int} factories and {string} money")]
        [Then("the game has {int} factories and {string} money")]
        public async Task ThenTheGameHasFactoriesAndMoney(int expectedFactories, string money)
        {
            var expectedMoney = decimal.Parse(money, System.Globalization.CultureInfo.InvariantCulture);
            await _playerPage.CheckFactoriesAndMoneyAsync(expectedFactories, expectedMoney);
        }
    }
}