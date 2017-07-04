using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }

        /// <summary>
        /// Propiedad Indexadora: permite manipular en este caso la lista _jornada mediante la propiedad. Para utilizarla, un una instancia de Universidad, por ejemplo:
        /// Universidad uni = new Universidad(); | Jornada jor = new Jornada(); | uni[0] = jor; // <= Set.| Console.Writeline(uni[0].ToString()); // <= Get.
        /// </summary>
        /// <param name="i">Indice de la colección</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get 
            {
                try
                {
                    return this._jornada[i];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            set 
            {
                try
                {
                    this._jornada[i] = value; 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }
        #endregion

        #region Constructores
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        } 
        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve true si pudo serializar un objeto del tipo Universidad en el path + nombre de archivo seteados. Lanza excepción caso contrario.
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            //no es necesario un try/cath ya que se valida dentro de la clase Xml.
            Xml<Universidad> xmlgim = new Xml<Universidad>();
            xmlgim.guardar("Universidad.xml", gim);
            return true;
        }

        /// <summary>
        /// Devuelve un objeto del tipo Universidad en el path + nombre de archivo seteados. Devuelve null en caso contrario.
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns></returns>
        public static Universidad Leer()
        {
            //no es necesario un try/cath ya que se valida dentro de la clase Xml.
            Universidad uniAux = null;

            Xml<Universidad> xmlgim = new Xml<Universidad>();
            xmlgim.leer("Universidad.xml", out uniAux);

            return uniAux;
        }


        /// <summary>
        /// Devuelve un string con todos los datos de la Universidad.
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada j in gim._jornada)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();

        }

        /// <summary>
        /// Devuelve un string que hace visibles los datos de la universidad invocando al método MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Una universidad es distinta a un alumno si éste no pertenece a la misma.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Retorna al primer profesor que no pueda dar la clase. En caso de no haber ninguno, se lanza excepción.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor pro in g._profesores)
            {
                if (pro != clase)
                {
                    return pro;
                }
            }

            //si llega a esta parte es porque no se encontró un profesor que NO de la clase, en caso de si encontrarse, se lo retorna al profesor
            //y no se llega a esta instrucción.
            throw new SinProfesorException();
        }

        /// <summary>
        /// Una universidad es distinta a un alumno si éste no pertenece a la misma.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Un alumno puede agregarse a la Universidad siempre y cuando éste no pertenezca a la misma. Retorna una Universidad con el alumno en caso de éxito.
        /// Caso contrario se lanza excepción.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }

        /// <summary>
        /// Una Clase puede agregarse a una Universidad siempre y cuando exista en la misma, un profesor que dé dicha clase. Se retorna una Universidad con una jornada creada
        /// en caso de éxito. Se lanza una excepción si no hay profesores para la clase.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool bandera = false;
            Profesor proAux = null;
            Jornada j = null;

            foreach (Profesor pro in g._profesores)
            {
                if (pro == clase)
                {
                    proAux = pro;
                    bandera = true;
                    break;
                }
            }

            if (bandera)
            {
                j = new Jornada(clase, proAux);
            }
            else
            {
                throw new SinProfesorException();
            }

            //si llega hasta aquí es porque la jornada se instanció ya que no se lanzó la excepción "SinProferosException", por lo tanto, no es necesario validar que j no sea null.
            foreach (Alumno al in g._alumnos)
            {
                if (al == clase)
                {
                    j += al;
                }
            }

            g._jornada.Add(j);

            return g;
        }

        /// <summary>
        /// Se puede agregar un Profesor a una Universidad siempre y cuando éste no pertenezca a la misma. Se retorna la universidad con o sin cambios dependiendo
        /// el resultado.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g._profesores.Add(i);

            return g;
        }

        /// <summary>
        /// Una universidad es igual a un alumno si éste pertenece a la misma.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool aux = false;

            foreach (Alumno al in g._alumnos)
            {
                if (al == a)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Una universidad es igual a una clase si dentro de la misma, existe un profesor que puede dar dicha clase. En caso de darse la igualdad, se devuelve el profesor.
        /// Caso contrario se lanza una excepción.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor pro in g._profesores)
            {
                if (pro == clase)
                {
                    return pro;
                }
            }

            //si llega a esta parte es porque no se encontró igualdad entre los profesores y la clase, en caso de si encontrarse, se lo retorna al profesor
            //y no se llega a esta instrucción.
            throw new SinProfesorException();
        }


        /// <summary>
        /// Una universidad es igual a un profesor, si éste pertenece a la misma.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool aux = false;

            foreach (Profesor pro in g._profesores)
            {
                if (pro == i)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        } 
        #endregion

        public enum EClases { Laboratorio, Legislacion, Programacion, SPD}
    }
}
