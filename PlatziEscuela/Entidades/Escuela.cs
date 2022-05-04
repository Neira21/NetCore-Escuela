using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {
        public int AñoCreación { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Dirección { get; set; }
        public TipoEscuela tipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        public Escuela(string nombre, int año, TipoEscuela tipoEscuela, string pais="", string ciudad="")
        {
            this.Nombre = nombre;
            this.AñoCreación = año;
            this.Pais = pais;
            this.Ciudad = ciudad;
        }
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {tipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar(){
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitulo($"Escuela: {Nombre} está limpia");
            Printer.Beep(1000, cantidad: 3);
        }
    }
}