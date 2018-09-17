using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AlunoController : Controller
    {
        [HttpGet]
        public ActionResult Index(string returnUrl = null)
        {
            return View();
        }
    }
}
