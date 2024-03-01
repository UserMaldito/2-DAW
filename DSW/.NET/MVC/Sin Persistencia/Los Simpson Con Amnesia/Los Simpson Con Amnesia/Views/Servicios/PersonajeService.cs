using Los_Simpson_Con_Amnesia.Models;

namespace Los_Simpson_Con_Amnesia.Views.Servicios
{
    public class PersonajeService
    {
        //Sin Persistencia = Necesidad de Guardar En Alguna Parte
        // = Lista Por Defecto0
        private static List<Personaje> characters = new List<Personaje>
        {
            new Personaje { Id = 1, Name = "Bart", Age = 8 , Job = "Grafitero"},
            new Personaje { Id = 2, Name = "Homer", Age = 39 , Job = "Ingeniero"},
            new Personaje { Id = 3, Name = "Marge", Age = 42 , Job = "Ama de Casa"}
        };
        private static int contadorID = characters.Count;

        /*Servicio (Se ENCARGA de TODA la LÓGICA del programa) = CRUD */

        //Create
        public static void CreateCharacter(Personaje newCharacter)
        {
            newCharacter.Id = contadorID + 1;
            characters.Add(newCharacter);
        }

        //Read (All)
        public static List<Personaje> ListCharacter()
        {
            return characters;
        }

        //Read (Single)
        public static Personaje SearchCharacter(int id)
        {
            Personaje searchCharacter = null;

            bool exists = ExistCharacter(id);
            if (exists)
            {
                searchCharacter = GetPersonaje(id);
            }

            return searchCharacter;
        }

        //Update
        public static void UpdateCharacter(Personaje updateCharacter)
        {
            //Elimino el antiguo e inserto el nuevo (en el mismo lugar)
            characters.RemoveAt(updateCharacter.Id - 1);
            characters.Insert(updateCharacter.Id - 1, updateCharacter);
        }

        //Delete
        public static void DeleteCharacter(int id)
        {
            characters.RemoveAt(id);
        }

        //Funciones Auxiliares (E+G)
        public static bool ExistCharacter(int idCharacter)
        {
            return characters.Exists(character => character.Id == idCharacter);
        }
    
        public static Personaje GetPersonaje(int id)
        {
            return characters[id];
        }
    }
}
