using SithecWS.Api.Utilities.Validations;

namespace SithecWS.Api.Models
{
    public class HumanModel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Sexo { get; set; }

        public decimal Altura { get; set; }

        public int Peso { get; set; }
    }
}