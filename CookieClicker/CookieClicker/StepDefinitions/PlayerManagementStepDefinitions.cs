using CookieClicker.Tests.Pages;
using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using System;

namespace CookieClicker.StepDefinitions
{
    [Binding]
    public class PlayerManagementStepDefinitions
    {

        private readonly HomePage _homePage;
        private readonly PlayerPage _playerPage;

        private int _playerCountBeforeSubmission;

        public PlayerManagementStepDefinitions(IPage page)
        {
            _homePage = new HomePage(page);
            _playerPage = new PlayerPage(page);
        }

        [Given("I navigate to the Cookie Clicker home page")]
        public async Task GivenINavigateToTheCookieClickerHomePage()
        {
            await _homePage.NavigateAsync();
        }

        [When("I enter {string} into the player name input")]
        public async Task WhenIEnterIntoThePlayerNameInputAsync(string playerName)
        {
            await _homePage.EnterPlayerNameAsync(playerName);
        }

        [When("I click the Start button")]
        public async Task WhenIClickTheStartButtonAsync()
        {
            await _homePage.ClickStartAsync();
        }

        [Then("a game should be created for player {string}")]
        public async Task ThenAGameShouldBeCreatedForPlayerAsync(string playerName)
        {
            await _playerPage.CheckGamePageForPlayerAsync(playerName);
        }

        [Given("I create a new player {string}")]
        public async Task GivenICreateANewPlayer(string playerName)
        {
            await _homePage.NavigateAsync();
            await _homePage.EnterPlayerNameAsync(playerName);
            await _homePage.ClickStartAsync();
            await _playerPage.CheckGamePageForPlayerAsync(playerName);
        }

        [When("I navigate to the home page")]
        public async Task WhenINavigateToTheHomePage()
        {
            await _homePage.NavigateAsync(); ;
        }

        [When("I select the existing player {string}")]
        public async Task WhenISelectTheExistingPlayer(string playerName)
        {
            await _homePage.SelectExistingPlayerAsync(playerName);
        }

        [Then("the game page should be displayed for player {string}")]
        public async Task ThenTheGamePageShouldBeDisplayedforPlayer(string playerName)
        {
            await _playerPage.CheckGamePageForPlayerAsync(playerName);
        }

        [When("the player name input is empty")]
        public async Task WhenThePlayerNameInputIsEmpty()
        {
            _playerCountBeforeSubmission = await _homePage.GetExistingPlayerLinkCountAsync();

            await _homePage.ClearPlayerNameAsync();
        }

        [Then("I should remain on the home page and a player should not be created")]
        public async Task ThenIShouldRemainOnTheHomePageAndAPlayerShouldNotBeCreated()
        {
            await _homePage.CheckHomePageAndPlayerNotCreatedAsync(_playerCountBeforeSubmission);
        }


    }
}
