
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TipoJornada tipoJornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Dirección { get; set; }

        public void LimpiarLugar(){
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} está limpio");
        }
    }
}