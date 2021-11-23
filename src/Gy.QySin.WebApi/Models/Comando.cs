using System.Text.Json;
using System.Text.Json.Serialization;
using Gy.QySin.WebApi.Serialization;

namespace Gy.QySin.WebApi.Models
{
    public class PeticiónComando
    {
        public string Entidad { get; set; }
        public string Comando { get; set; }
        [JsonConverter(typeof(ComandoValorConverter))]
        public string Valor { get; set; }
        public string NombreTipo()
        {
            return $"Gy.QySin.Application.{Entidad}.Comandos.{Comando}.{Comando}Cmd, Gy.QySin.Application";
        }
    }
}