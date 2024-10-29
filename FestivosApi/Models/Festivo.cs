using FestivosApi.Models;

namespace FestivosAPI.Models
{
    public class Festivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int DiasPascua { get; set; }
        public int IdTipo { get; set; }
        public Tipo Tipo { get; set; }  // Relación con la tabla Tipo
    }
}
