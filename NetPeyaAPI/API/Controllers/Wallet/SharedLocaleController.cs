using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet.SharedLocaleController
{
    public class SharedLocaleController : WalletBaseController
    {
        private readonly IStringLocalizer<SharedLocaleController> _baseLocalizer;

        public SharedLocaleController(
            IStringLocalizer<SharedLocaleController> baseLocalizer)
        {
            _baseLocalizer = baseLocalizer;
        }
    }
}
