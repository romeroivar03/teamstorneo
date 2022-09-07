using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
       // public Partido AddPartido(Partido partido, int idequipolocal, int idequipovisitante, int idEquipo);
        public Partido AddPartido(Partido partido, int local, int Visitante);
        public IEnumerable<Partido> GetAllPartidos();
    }
}