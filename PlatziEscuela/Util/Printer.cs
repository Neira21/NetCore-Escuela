namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tamaño = 10)
        {
            var line = "".PadLeft(tamaño, '=');
            Console.WriteLine(line);
        }
        public static void WriteTitulo(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DibujarLinea(tamaño);
            Console.WriteLine($"| {titulo} |");
            DibujarLinea(tamaño);
        }
        public static void Beep(int hz = 2000, int tiempo=500, int cantidad =1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }
    }
}