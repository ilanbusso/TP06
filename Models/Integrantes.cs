using Newtonsoft.Json;
namespace TP06.Models;

public class Integrantes
{
    [JsonProperty]
    public string nombre { get; set; }

    [JsonProperty]
    public string email { get; set; }
    [JsonProperty]
    public string password { get; set; }

    [JsonProperty]
    public double estatura { get; set; }
    [JsonProperty]
    public string orientacion { get; set; }
    [JsonProperty]
    public string peliculaFav { get; set; }

    [JsonProperty]
    public string sexo { get; set; }
    [JsonProperty]
    public string edad { get; set; }

    public Integrantes()
    {

    }



}