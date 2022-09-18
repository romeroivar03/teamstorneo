using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        
        public Partido partido {get;set;}
        public SelectList LocalOptions {get;set;}    
        public int LocalSelected {get;set;}
        public SelectList VisitanteOptions {get;set;}
        public int VisitanteSelected {get;set;}
                
        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }
        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            LocalOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            LocalSelected = partido.Local.Id;
            VisitanteOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            VisitanteSelected = partido.Visitante.Id;
            if(partido == null){
                return NotFound();
            }
            else{
                return Page();
            }
        }
        public IActionResult OnPost(Partido partido, int Local, int Visitante)
        {
            _repoPartido.UpdatePartido(partido, Local, Visitante);
            return RedirectToPage("Index");
        }
    }
}
