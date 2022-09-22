using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
    public class DirectorTecnico
    {
        public int Id { get; set; }       
        [Display(Name = "Nombre del Director Tecnico")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "El Documetno es obligatorio")]
        public string Documento { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }
    }
}
