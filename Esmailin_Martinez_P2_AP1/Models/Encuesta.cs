using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esmailin_Martinez_P2_AP1.Models
{
    public class Encuesta

    {
        [Key]
        public int EncuestaId { get; set; }
        [Required(ErrorMessage = "El campo Nombre no puede estar vacío")]
        public string Asignatura { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;

        public virtual ICollection<Detalle> Detalle { get; set; } = new List<Detalle>();
    }
}

