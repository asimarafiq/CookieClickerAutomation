using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CookieClicker.Tests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly string _baseUrl;

        public HomePage(IPage page)
        {
            _page = page;
            _baseUrl = "https://asim-rafiq-2026-07-27.cookieclickertechtest.airelogic.com";

        }

        private const string PlayerNameInput = "input[name='name']";
        private const string StartButton = "Start!";
        private const string ExistingPlayerLinks = "table tbody a";


        public async Task NavigateAsync()
        {
            await _page.GotoAsync(_baseUrl);
            var playerNameInput = _page.Locator(PlayerNameInput);
            await playerNameInput.WaitForAsync();            
        }

        public async Task EnterPlayerNameAsync(string playerName)
        {
            var playerNameInput = _page.Locator(PlayerNameInput);
            await playerNameInput.FillAsync(playerName);
        }

        public async Task ClearPlayerNameAsync()
        {
            var playerNameInput = _page.Locator(PlayerNameInput);
            await playerNameInput.FillAsync(string.Empty);
        }

        public async Task<bool> IsPlayerNameEmptyAsync()
        {
            var playerNameInput = _page.Locator(PlayerNameInput);
            return string.IsNullOrEmpty(await playerNameInput.InputValueAsync());
        }

        public async Task ClickStartAsync()
        {
            var startButton = _page.GetByRole(AriaRole.Button, new() { Name = "Start!", Exact = true });
            await startButton.ClickAsync();
        }

        public async Task SelectExistingPlayerAsync(string playerName)
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = playerName, Exact = true }).ClickAsync();
        }

        public async Task<int> GetExistingPlayerLinkCountAsync()
        {
            var existingPlayerLinks = _page.Locator(ExistingPlayerLinks);
            return await existingPlayerLinks.CountAsync();
        }

        public async Task<bool> IsHomePageDisplayedAsync()
        {
            var playerNameInput = _page.Locator(PlayerNameInput);
            return await playerNameInput.IsVisibleAsync() && _page.Url.TrimEnd('/') == _baseUrl.TrimEnd('/');
        }

        public async Task<bool> IsPlayerListedAsync(string playerName)
        {
            return await _page.Locator(ExistingPlayerLinks)
                .GetByText(playerName, new() { Exact = true })
                .CountAsync() > 0;
        }

        public async Task CheckHomePageAndPlayerNotCreatedAsync(int playerCountBeforeSubmission)
        {
            Assert.That(await _page.Locator(PlayerNameInput).IsVisibleAsync(), Is.True, "Expected to remain on the home page.");
            Assert.That(await _page.Locator(PlayerNameInput).InputValueAsync(), Is.Empty, "Expected the player name input to remain empty.");
            Assert.That(await _page.Locator(ExistingPlayerLinks).CountAsync(), Is.EqualTo(playerCountBeforeSubmission), "Expected no new player to be created when submitting an empty player name.");
        }
    }
}