using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbcInsuranceWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { Premium = 1500.75, TermInMonths = 6, Status = "Success" });
        }

    }
}
