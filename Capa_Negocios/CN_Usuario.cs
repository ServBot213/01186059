using Capa_Persistencias;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Negocios
{
    public class CN_Usuario
    {
        private CD_Usuario objetoCD = new CD_Usuario();
        private static readonly HttpClient client = new HttpClient();
        public DataTable MostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarUsuario(string nombre, string usuario, string contrasena, string correo)
        {
            objetoCD.Insertar(nombre, usuario, contrasena, correo);
        }

        public void InsertarPokemon(string nombreP, string descripcion, string objeto, string habilidad, string ataque1, string ataque2, string ataque3, string ataque4, int hP, int ataque, int defensa, int ataqueE, int defensaE, int velocidad, string tipo, int equipoId)
        {
            objetoCD.InsertarPokemon(nombreP, descripcion, objeto, habilidad, ataque1, ataque2, ataque3, ataque4, hP, ataque, defensa, ataqueE, defensaE, velocidad, tipo, equipoId);
        }

        public DataTable MostrarEquipos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEquipos();
            return tabla;
        }

        public void EditarUsuario(string nombre, string contrasena, string correo, string id)
        {
            objetoCD.Editar(nombre, contrasena, correo, Convert.ToInt32(id));
        }

        public void EliminarUsuario(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
        public async Task InsertarPokemon(string nombre, string objeto, string habilidad, string ataque1, string ataque2, string ataque3, string ataque4, int hp, int ataque, int defensa, int ataqueE, int defensaE, int velocidad, string tipo)
        {
            var pokemonData = new
            {
                Nombre = nombre,
                Objeto = objeto,
                Habilidad = habilidad,
                Ataque1 = ataque1,
                Ataque2 = ataque2,
                Ataque3 = ataque3,
                Ataque4 = ataque4,
                HP = hp,
                Ataque = ataque,
                Defensa = defensa,
                AtaqueE = ataqueE,
                DefensaE = defensaE,
                Velocidad = velocidad,
                Tipo = tipo
            };

            string json = JsonConvert.SerializeObject(pokemonData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                string url = "https://api.tu-servidor.com/pokemon";
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pokémon registrado exitosamente");
                }
                else
                {
                    Console.WriteLine("Error al registrar el Pokémon: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción al registrar el Pokémon: " + ex.Message);
            }
        }
    }
}


