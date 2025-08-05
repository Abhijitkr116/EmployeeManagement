using Microsoft.AspNetCore.Mvc;


namespace Saurav.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Dashboard(){
            return View();
        }
    }
}
