using Los_Simpson_Con_Amnesia.Models;
using Los_Simpson_Con_Amnesia.Views.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Los_Simpson_Con_Amnesia.Controllers
{
    //Se encarga de ofrecer rutas (endpoints)
    public class PersonajeController : Controller
    {
        //Sin Persistencia = Necesidad de Guardar En Alguna Parte
        // = Lista Por Defecto
        private static List<Personaje> characters = new List<Personaje>
        {
            new Personaje { Id = 1, Name = "Bart", Age = 8 , Job = "Grafitero"},
            new Personaje { Id = 2, Name = "Marge", Age = 42 , Job = "Ama de Casa"},
            new Personaje { Id = 3, Name = "Homer", Age = 39 , Job = "Ingeniero"}
        };
        private static int contadorID = characters.Count;


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
                this.CreateCharacter(createPersonaje);

                return RedirectToAction("ReadAll");
            }

            return View();
        }


        [HttpGet]
        public IActionResult ReadAll()
        {
            //Forma 2: uso del ViewBag/ViewData[""]
            ViewBag.listaPersonaje = this.ListCharacter();
            return View();
        }

        [HttpGet]
        public IActionResult ReadSingle(int id)
        {
            Personaje readChar = this.ReadCharacter(id);
            return View(readChar);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(this.ReadCharacter(id));
        }

        [HttpPost]
        public IActionResult Update(Personaje updatePersonaje)
        {
            if (ModelState.IsValid)
            {
                this.UpdateCharacter(updatePersonaje);
                return RedirectToAction("ReadAll");
            }

            return View(updatePersonaje);
        }


        [HttpGet]
        public IActionResult GetDelete(int id)
        {
            return View(this.ReadCharacter(id));
        }

        [HttpPost]
        public IActionResult PostDelete(int id)
        {
            this.DeleteCharacter(id);
            return RedirectToAction("ReadAll");
        }


        /*Servicio (Se ENCARGA de TODA la LÓGICA del programa) = CRUD */

        //Create
        public void CreateCharacter(Personaje createCharacter)
        {
            contadorID++;
            createCharacter.Id = contadorID;
            characters.Add(createCharacter);
        }

        //Read All
        public List<Personaje> ListCharacter()
        {
            return characters;
        }

        //Read Single

        public Personaje ReadCharacter(int idRead)
        {
            Personaje getCharacter = null;
            bool existCharacter = this.ExistCharacter(idRead);

            if (existCharacter)
            {
                getCharacter = this.GetCharacter(idRead);
            }

            return getCharacter;
        }

        //Update
        public void UpdateCharacter(Personaje updateCharacter)
        {
            Personaje oldCharacter = this.ReadCharacter(updateCharacter.Id);
            int indexOldChar = characters.IndexOf(oldCharacter);

            characters.Insert(indexOldChar, updateCharacter);
            characters.RemoveAt(indexOldChar + 1);
        }

        //Delete
        public void DeleteCharacter(int idDelete)
        {
            Personaje deleteCharacter = this.ReadCharacter(idDelete);
            characters.Remove(deleteCharacter);
        }

        //Exist
        public bool ExistCharacter(int idExist)
        {
            return characters.Exists(character => character.Id == idExist);
        }

        //Get
        public Personaje GetCharacter(int idGet)
        {
            return characters.FirstOrDefault(character => character.Id == idGet);
        }



    }
}
