using HospiEnCasa.Models;
using HospiEnCasa.Models.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace HospiEnCasa.Controllers
{
    public class MedicosController : Controller
    {
        private readonly IRepositorioMedicos repositorioMedicos;

        public MedicosController(IRepositorioMedicos repositorioMedicos)
        {
            this.repositorioMedicos = repositorioMedicos;
        }
        public string nombre = null;



        public async Task<IActionResult> Index(string nombre)
        {
            if (nombre is null)
            {
                var medicos = await repositorioMedicos.Obtener();
                return View(medicos);

            }
            var filtromedico = await repositorioMedicos.FiltroMedico(nombre);

            return View (filtromedico);

        }


        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Crear(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return View(medico);
            }

            var yaExisteMedico = await repositorioMedicos.Existe(medico.Codigo);

            if (yaExisteMedico)
            {
                ModelState.AddModelError(nameof(medico.Codigo), $"El medico ingresado con CODIGO  {medico.Codigo}  ya existe.");
                return View(medico);

            }

           await repositorioMedicos.Crear(medico);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExistMedico(string codigo)
        {
            var yaExisteMedico = await repositorioMedicos.Existe(codigo);
            if (yaExisteMedico )
            {
                return Json($"El codigo de profesional {codigo} ya existee");
            }
            return Json(true);
        }




        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            var MedicoEncontrado = await repositorioMedicos.ObtenerporId(id);
            if (MedicoEncontrado is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            return View(MedicoEncontrado);
        }
       [HttpPost]
       public async Task<IActionResult> Editar (Medico medico)
        {
             await repositorioMedicos.Actualizar(medico);
            return RedirectToAction("Index");
        }





    }
}
