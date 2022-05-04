// See https://aka.ms/new-console-template for more information
using CoreEscuela.Util;

using CoreEscuela.Entidades;    
using static System.Console;
using CoreEscuela.App;

var engine = new EscuelaEngine(); 
engine.Inicializar();
Printer.DibujarLinea();

ImprimirCursosEscuela(engine.Escuela);


Dictionary<int, string> diccionario = new Dictionary<int, string>();
diccionario.Add(10, "JuanK");
diccionario.Add(23, "Lorem Ipsum");

foreach (var keyValuePair in diccionario)
{
    WriteLine($"key:{keyValuePair.Key} Valor:{keyValuePair.Value}");
}

var dic = engine.GetDiccionarioObjetos();

Printer.DibujarLinea();

engine.imprimirDiccionario(dic);




void ImprimirCursosEscuela(Escuela escuela)
{
    Printer.DibujarLinea(20);
    Printer.WriteTitulo("Cursos de la Escuela");
    Printer.DibujarLinea(20);
    if(escuela!=null && escuela.Cursos!= null){
        foreach (var curso in escuela.Cursos)
        {
            WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
        }
    }    
}




