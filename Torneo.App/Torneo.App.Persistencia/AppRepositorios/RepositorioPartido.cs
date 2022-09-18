using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();
       
        public Partido AddPartido(Partido partido, int Local, int Visitante)
        {
            var equipolocalencontrado = _dataContext.Equipos.Find(Local);
            var equipovisitanteencontrado = _dataContext.Equipos.Find(Visitante);
            partido.Local = equipolocalencontrado;
            partido.Visitante = equipovisitanteencontrado;
            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }
        
        public IEnumerable<Partido> GetAllPartidos()
        {
        var partidos = _dataContext.Partidos
                .Include(e => e.Local)
                .Include(e => e.Visitante)
                .ToList();
            return partidos;
        }
        
        public Partido GetPartido(int idPartido)
        {
            var partidoEncontrado = _dataContext.Partidos.Find(idPartido);
            return partidoEncontrado;
        }

        public Partido UpdatePartido(Partido partido, int Local, int Visitante)
        {
            var partidoEncontrado= GetPartido(partido.Id);
            var equipoLocalEncontrado = _dataContext.Equipos.Find(Local);
            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(Visitante);
            partidoEncontrado.FechaHora = partido.FechaHora;
            partidoEncontrado.Local = equipoLocalEncontrado;
            partidoEncontrado.MarcadorLocal = partido.MarcadorLocal;
            partidoEncontrado.Visitante = equipoVisitanteEncontrado;
            partidoEncontrado.MarcadorVisitante = partido.MarcadorVisitante;            
            return partidoEncontrado;
        }
    }
}