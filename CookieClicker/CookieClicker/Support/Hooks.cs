
using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;
using System.Threading.Tasks;

namespace CookieClicker.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        private IBrowserContext? _context;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });

            _context = await _browser.NewContextAsync();

            var page = await _context.NewPageAsync();

            _container.RegisterInstanceAs<IPlaywright>(_playwright);
            _container.RegisterInstanceAs<IBrowser>(_browser);
            _container.RegisterInstanceAs<IBrowserContext>(_context);
            _container.RegisterInstanceAs<IPage>(page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_context != null)
                await _context.CloseAsync();

            if (_browser != null)
                await _browser.CloseAsync();

            _playwright?.Dispose();
        }
    }
}
