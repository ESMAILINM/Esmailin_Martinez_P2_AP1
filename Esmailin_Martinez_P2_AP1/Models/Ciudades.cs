using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esmailin_Martinez_P2_AP1.Models
{
    public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }
        [Required(ErrorMessage ="Debe elegir una Ciudad")]
        public string Nombre { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Debe introducir un monto válido")]
        public double Monto { get; set; } = 0;

        public List<Detalle> Detalles { get; set; }
    }
}
