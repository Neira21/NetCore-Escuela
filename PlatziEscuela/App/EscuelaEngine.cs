using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }
        public EscuelaEngine()
        {
        }
        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy",
                                2012,
                                TipoEscuela.Secundaria,
                                "Colombia",
                                "Bogota");
            CargarCurso();
            CargarAsignaturas();
            CargarEvaluaciones();
        }
        
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos(){
            
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] {Escuela});
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listaAlumnos = new List<Alumno>();
            var listaAsignaturas = new List<Asignatura>();
            var listaEvaluacion = new List<Evaluación>();

            /*Escuela.Cursos.ForEach(curso =>{
                listaAsignaturas.AddRange(curso.Asignaturas);
                listaAlumnos.AddRange(curso.Alumnos);
                listaAlumnos.ForEach(alum =>
                listaEvaluacion.AddRange(alum.Evaluaciones));
            });*/
            
            foreach (var cur in Escuela.Cursos)
            {
                listaAsignaturas.AddRange(cur.Asignaturas);
                listaAlumnos.AddRange(cur.Alumnos);
                foreach (var alumno in cur.Alumnos)
                {
                    listaEvaluacion.AddRange(alumno.Evaluaciones);
                }
            }
            
            diccionario.Add(LlaveDiccionario.Asignatura, listaAsignaturas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listaAlumnos.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluación, listaEvaluacion.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }

        public void imprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, 
                    bool imprEval = true){
            
            foreach (var objdic in dic)
            {
                Printer.WriteTitulo(objdic.Key.ToString());
                foreach (var val in objdic.Value)
                {
                    switch (objdic.Key)
                    {
                        case LlaveDiccionario.Evaluación:
                            if(imprEval)
                                Console.WriteLine("Evaluación: "+val);
                        break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: "+val);
                        break;
                        case LlaveDiccionario.Asignatura:
                            Console.WriteLine("Asignatura: "+val);
                        break;
                        case LlaveDiccionario.Curso:
                            var curtmp = val as Curso;
                            if(curtmp != null){
                                int count = curtmp.Alumnos.Count;
                                Console.WriteLine("Curso: "+val.Nombre + " Cantidad Alumnos: "+ count);
                            }
                        break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine("Alumno: "+val);
                        break;

                    }

                    // if(val is Evaluación){
                        
                    // }
                    // else if(val is Escuela){
                    //     Console.WriteLine("Escuela: " + val);                      
                    // }else if(val is Alumno){
                    //     Console.WriteLine("Alumno: " + val);
                    // }else if(val is Curso){
                    //     Console.WriteLine("Curso: " + val);
                    // }else if(val is Asignatura){
                    //     Console.WriteLine("Asignatura: " + val);    
                    // }else{
                    //     Console.WriteLine(val);
                    // }
                }
            }
        }



        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traerCurso= true
            )
        {
            return GetObjetoEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traerCurso= true
            )
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traerCurso= true
            )
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traerCurso= true
            )
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traerCurso= true
            )
        {
            conteoEvaluaciones=conteoAsignaturas=conteoAlumnos=0;
            var listobj = new List<ObjetoEscuelaBase>();
            listobj.Add(Escuela);
            
            if (traerCurso)
                listobj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas+= curso.Asignaturas.Count;
                conteoAlumnos+= curso.Alumnos.Count;

                if (traeAsignaturas)
                    listobj.AddRange(curso.Asignaturas);
                
                
                if (traeAlumnos)
                    listobj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listobj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return listobj.AsReadOnly();
        }

        #region Métodos de Carga...
        private void CargarCurso()
        {
            var curso1 = new Curso() { Nombre = "101", tipoJornada = TipoJornada.Mañana };
            var curso2 = new Curso() { Nombre = "201", tipoJornada = TipoJornada.Mañana };
            var curso3 = new Curso() { Nombre = "301", tipoJornada = TipoJornada.Mañana };
            var curso4 = new Curso() { Nombre = "401", tipoJornada = TipoJornada.Mañana };
            var curso5 = new Curso() { Nombre = "501", tipoJornada = TipoJornada.Mañana };
            Escuela.Cursos = new List<Curso>(){
                curso1,
                curso2,
                curso3,
                curso4,
                curso5,
            };
            foreach (var curso in Escuela.Cursos)
            {
                Random rnd = new Random();
                int cantidadAleatoria = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadAleatoria);
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno($"{n1} {n2} {a1}");
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }
        private void CargarEvaluaciones()
        {
            var rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    { 
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = MathF.Round(
                                    5*(float) rnd.NextDouble()
                                    ,2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
