using Microsoft.AspNetCore.Mvc;
using BLL;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class TradeController : Controller
    {
        private readonly BusinessLogic _businessLogic;

        public TradeController(BusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public async Task<IActionResult> Index()
        {
            // Call the method to get real-time trading data
            var tradingData = await _businessLogic.GetRealTimeTradingData();

            // Pass the trading data to the view
            return View(tradingData);
        }
    }
}
