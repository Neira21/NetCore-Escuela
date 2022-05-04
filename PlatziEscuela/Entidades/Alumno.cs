
namespace CoreEscuela.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; } = new List<Evaluación>();

        public Alumno(string nombre){
            this.Nombre = nombre;
        }
    }
}