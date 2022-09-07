using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();

       // public Partido AddPartido(Partido partido, int idequipolocal, int idequipovisitante, int idEquipo)
        public Partido AddPartido(Partido partido, int local, int Visitante)
        {
            var equipolocalencontrado = _dataContext.Equipos.Find(local);
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
    }
} 