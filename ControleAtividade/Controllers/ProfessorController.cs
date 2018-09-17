using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleAtividade.Data;
using ControleAtividade.Models;
using Microsoft.AspNetCore.Authorization;
using ControleAtividade.Models.ProfessorViewModels;
using Microsoft.AspNetCore.Identity;
using ControleAtividade.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;

namespace ControleAtividade.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ProfessorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IProfessorService _professorService;

        public ProfessorController(UserManager<ApplicationUser> userManager,
            IProfessorService professorService,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _professorService = professorService;
        }

        // GET: Professor
        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginProfessorViewModel model, string returnUrl = null)
        {
           
            // If we got this far, something failed, redisplay form
            return View(model);
        }
  
        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
