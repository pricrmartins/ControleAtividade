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
        [AllowAnonymous]
        public async Task<IActionResult> Index(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginProfessorViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Matricula, model.Senha, model.Lembrar, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // GET: Professor/Details/5
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {/*
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(p => p.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            */
            return View();
        }

        // GET: Professor/Cadastrar
        [AllowAnonymous]
        public IActionResult Cadastrar(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: Professor/Cadastrar
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(CadastrarViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Matricula, Email = model.Email, Matricula = model.Matricula };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    var id = await _professorService.SetProfessorAsync(new Professor
                    {
                        IdApplicationUser = user.Id
                    });

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {/*
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.SingleOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            ViewData["IdApplicationUser"] = new SelectList(_context.Users, "Id", "Id", professor.IdApplicationUser);*/
            return View();
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdApplicationUser")] Professor professor)
        {
          /*  if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdApplicationUser"] = new SelectList(_context.Users, "Id", "Id", professor.IdApplicationUser);*/
            return View(professor);
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
