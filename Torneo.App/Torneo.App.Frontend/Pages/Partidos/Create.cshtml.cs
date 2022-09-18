using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
       
        public Partido partido {get; set;}
        public IEnumerable<Equipo> Local { get; set;}
        public IEnumerable<Equipo> Visitante { get; set;}
        
        public CreateModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }

        public void OnGet()
        {
            partido = new Partido();
            Local = _repoEquipo.GetAllEquipos();  
            Visitante = _repoEquipo.GetAllEquipos();           
        }

        public IActionResult OnPost(Partido partido, int Local, int Visitante)
        {
            _repoPartido.AddPartido(partido, Local, Visitante);
            return RedirectToPage("Index");                                       
        }
    }
}
