using System.ComponentModel.DataAnnotations;

namespace TareaRegistroPrioridades.Modelo
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(70, ErrorMessage = "No se puede exceder el limite de 70 caracteres")]
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public string Nombres { get; set; }

        [StringLength(10, ErrorMessage = "No se puede exceder el limite de 10 caracteres numericos")]
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public int Telefono { get; set; }

        [StringLength(10, ErrorMessage ="No se puede exceder el limite de 10 caracteres numericos")]
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public int Celular { get; set; }

        [StringLength(11, ErrorMessage = "No se puede exceder el limite de 11 caracteres numericos")]
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public int RNC { get; set; }

        [StringLength(50, ErrorMessage = "No se puede exceder el limite de 50 caracteres")]
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "No se puede exceder el limite de 100 caracteres")]
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public string Direccion { get; set; }
    }
}
