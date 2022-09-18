using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio
{
public class Partido
    {
        public int Id { get; set; }
        [Display(Name = "Fecha y hora del partido")]       
        public DateTime FechaHora { get; set; }
        [Display(Name = "Equipo local:")]
        public Equipo Local { get; set; }
        [Display(Name = "Marcador del equipo local:")]
        public int MarcadorLocal { get; set; }
        [Display(Name = "Equipo visitante:")]
        public Equipo Visitante { get; set; }
        [Display(Name = "Marcador del equipo visitante:")]
        public int MarcadorVisitante { get; set; }
    }
} 