using Newtonsoft.Json;
public class Usuario
{
    public string Nombre { get; set; }
    public string Clave { get; set; }

    [JsonProperty]
    private string Dni { get; set; }

    public Usuario(string nombre, string clave, string dni)
    {
        Nombre = nombre;
        Clave = clave;
        Dni = dni;
    }

    // Método opcional para mostrar el DNI solo desde dentro
    public string ObtenerDni()
    {
        return Dni;
    }
}
