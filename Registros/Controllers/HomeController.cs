using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registros.Data;
using Registros.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Registros.Services;
using Registros.Models.ViewModels;
using Registros.Services.Exceptions;

namespace Registros.Controllers
{
    public class HomeController : Controller
    {


        private readonly PessoaService _pessoaService;
        public HomeController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _pessoaService.FindAllAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _pessoaService.FindByIdAsync(id.Value);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        public IActionResult Create()
        {
            var viewModel = new PessoaFormViewModel { };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = new PessoaFormViewModel { Pessoa = pessoa };
                return View(viewModel);
            }


            await _pessoaService.InsertAsync(pessoa);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _pessoaService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            PessoaFormViewModel viewModel = new PessoaFormViewModel { Pessoa = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                
                var viewModel = new PessoaFormViewModel { Pessoa = pessoa };
                return View(viewModel);
            }

            if (id != pessoa.Id)
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" }); ;

            try
            {
                await _pessoaService.UpdateAsync(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provider" });

            var obj = await _pessoaService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); ;

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _pessoaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public async Task<IActionResult> Search(string searchName)
        {
           
            
            ViewData["searchName"] = searchName.ToString();

            List<Pessoa> result = await _pessoaService.FindAllByNameAsync(searchName);
            return View(result);
        }





























        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
