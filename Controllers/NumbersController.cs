using Microsoft.AspNetCore.Mvc;
using NumberManager.Services;

namespace NumberManager.Controllers
{
    public class NumbersController : Controller
    {
        private readonly INumberService _service;

        public NumbersController(INumberService service) => _service = service;

        public IActionResult Index() => View(_service.GetList());

        [HttpPost]
        public IActionResult AddNumber()
        {
            _service.AddRandom();
            return PartialView("_NumberListPartial", _service.GetList());
        }

        [HttpPost]
        public IActionResult ClearNumbers()
        {
            _service.Clear();
            return PartialView("_NumberListPartial", _service.GetList());
        }

        [HttpPost]
        public IActionResult SumNumbers()
        {
            _service.Sum();
            return PartialView("_NumberListPartial", _service.GetList());
        }
    }

}
