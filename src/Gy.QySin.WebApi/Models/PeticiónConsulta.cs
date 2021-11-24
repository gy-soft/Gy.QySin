using System.Text.Json.Serialization;
using Gy.QySin.WebApi.Serialization;

namespace Gy.QySin.WebApi.Models
{
    public class PeticiónConsulta
    {
        public string Entidad { get; set; }
        public string Comando { get; set; }
        [JsonConverter(typeof(ComandoValorConverter))]
        public string Valor { get; set; }
        public string NombreTipo()
        {
            return $"Gy.QySin.Application.{Entidad}.Consultas.{Comando}.{Comando}Con, Gy.QySin.Application";
        }
    }
}