using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Esmailin_Martinez_P2_AP1.Models
{
    public class Detalle
    {
            [Key]
            public int DestallesId { get; set; }

            public int EncuestaId { get; set; }

            public int CiudadId { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Debe introducir un monto válido")]
        public double MontoEncuesta { get; set; }

            [ForeignKey("CiudadId")]
            public virtual Ciudades Ciudades { get; set; } = null!;
        public  Encuesta Encuesta { get; set; } 
      

    }
}
