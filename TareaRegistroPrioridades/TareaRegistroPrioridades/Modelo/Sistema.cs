using System.ComponentModel.DataAnnotations;
namespace TareaRegistroPrioridades.Modelo
{
    public class Sistema
    {
        [Key]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El Nombre del sistema es obligatorio.")]
        public string NombredeSistema { get; set; }
    }
}
