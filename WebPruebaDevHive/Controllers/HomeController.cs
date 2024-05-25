using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebPruebaDevHive.Models;
using WebPruebaDevHive.Services;

namespace WebPruebaDevHive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;

        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var inmuebles = await _apiService.GetInmueblesAsync();
                if (inmuebles == null)
                {
                    ViewBag.ErrorMessage = "La lista de inmuebles está vacía.";
                    return View(new List<Inmueble>());
                }
                return View(inmuebles);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener la lista de inmuebles: " + ex.Message;
                return View(new List<Inmueble>());
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var inmueble = await _apiService.GetInmuebleByIdAsync(id);
                if (inmueble == null)
                {
                    ViewBag.ErrorMessage = "El inmueble no fue encontrado.";
                    return RedirectToAction(nameof(Index));
                }
                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles del inmueble: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inmueble inmueble)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _apiService.CreateInmuebleAsync(inmueble);
                    return RedirectToAction(nameof(Index));
                }
                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al crear el inmueble: " + ex.Message;
                return View(inmueble);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var inmueble = await _apiService.GetInmuebleByIdAsync(id);
                if (inmueble == null)
                {
                    ViewBag.ErrorMessage = "El inmueble no fue encontrado.";
                    return RedirectToAction(nameof(Index));
                }
                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles del inmueble: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Inmueble inmueble)
        {
            try
            {
                if (id != inmueble.Id)
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    var success = await _apiService.UpdateInmuebleAsync(id, inmueble);
                    if (!success)
                    {
                        ViewBag.ErrorMessage = "No se pudo actualizar el inmueble.";
                        return View(inmueble);
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al editar el inmueble: " + ex.Message;
                return View(inmueble);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var inmueble = await _apiService.GetInmuebleByIdAsync(id);
                if (inmueble == null)
                {
                    ViewBag.ErrorMessage = "El inmueble no fue encontrado.";
                    return RedirectToAction(nameof(Index));
                }
                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles del inmueble: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _apiService.DeleteInmuebleAsync(id);
                if (!success)
                {
                    ViewBag.ErrorMessage = "No se pudo eliminar el inmueble.";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al eliminar el inmueble: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
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
