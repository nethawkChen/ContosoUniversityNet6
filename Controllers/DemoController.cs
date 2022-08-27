using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityNet6.Controllers {
    public class DemoController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
