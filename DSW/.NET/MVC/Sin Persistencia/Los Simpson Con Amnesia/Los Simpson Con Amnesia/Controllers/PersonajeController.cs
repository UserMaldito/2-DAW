using Los_Simpson_Con_Amnesia.Models;
using Los_Simpson_Con_Amnesia.Views.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Los_Simpson_Con_Amnesia.Controllers
{
    //Se encarga de ofrecer rutas (endpoints)
    public class PersonajeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //GET -> Ir al formulario
        [HttpGet]
        public IActionResult Create()
        {
            //Forma de comunicación entre Vista y Controlador 1:
            //modelo [Model] -> (dentro del View() poner un objeto)
            return View(new Personaje());
        }
        
        //POST -> Tramita info del formulario
        [HttpPost]
        public IActionResult Create(Personaje createPersonaje)
        {
            //Si hay algún error, vuelve a la página y muestra los errores
            //Si no hay  errores, crea el personaje y va hacia el listado (para ver los cambios)
            if (ModelState.IsValid)
            {
                PersonajeService.CreateCharacter(createPersonaje);

                return RedirectToAction("ReadAll");
            }

            return View();
        }


        [HttpGet]
        public IActionResult ReadAll()
        {
            //Forma 2: uso del ViewBag/ViewData[""]
            ViewBag.listaPersonaje = PersonajeService.ListCharacter();
            return View();
        }

        [HttpGet]
        public IActionResult ReadSingle(int id)
        {
            Personaje readChar = PersonajeService.SearchCharacter(id);
            return View(readChar);
        }


        [HttpGet]
        public IActionResult Update(int idUpdate)
        {
            return View(PersonajeService.GetPersonaje(idUpdate));
        }

        [HttpPost]
        public IActionResult Update(Personaje updatePersonaje)
        {
            if (ModelState.IsValid)
            {
                PersonajeService.UpdateCharacter(updatePersonaje);
                return RedirectToAction("ReadAll");
            }

            return View(updatePersonaje);
        }


        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int idDelete)
        {
            PersonajeService.DeleteCharacter(idDelete);
            return RedirectToAction("ReadAll");
        }

    }
}
