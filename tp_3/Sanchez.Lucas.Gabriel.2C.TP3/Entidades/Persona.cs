using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad {Argentino, Extranjero}

        #region Propiedades

        public int DNI
        {
            get { return this._dni; }
            //el value es entero en este caso
            set { this._dni = Persona.ValidarDni(this._nacionalidad, value); }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = Persona.ValidarNombreApellido(value); }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = Persona.ValidarNombreApellido(value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string StringToDni
        {
            //el value es string en este caso
            set { this._dni = Persona.ValidarDni(this._nacionalidad,value); }
        } 
        #endregion

        #region Constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        } 
        #endregion
        
        #region Métodos

        /// <summary>
        /// Valida que un DNI en formato entero ingresado pertenezca al rango válido para cada nacionalidad. En caso de éxito se retorna el dato.
        /// En caso contrario se lanza excepción.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            string aux = "El número de DNI: " + dato.ToString() + " no pertenece a los rangos de la nacionalidad: " + nacionalidad.ToString();

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(aux);
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }

            return dato;
        }

        /// <summary>
        /// Valida que un DNI ingresado en formato string, tenga la cantidad de caracteres correctos e intenga convertirlo a entero. Si lo logra llama a ValidarDni para
        /// un número entero. Caso contrario lanza excepción.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">Dni</param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            //Un dni debe tener entre 1 y 8 caracteres.
            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException("El Dni debe tener entre 1 y 8 caracteres, usted ingresó: "+dato);
            }
            
            int aux = 0;

            //Si la conversión no tiene éxito, se lanza una excepción.
            if (!int.TryParse(dato, out aux))
            {
                throw new DniInvalidoException();
            }

            return Persona.ValidarDni(nacionalidad, aux);
        }
        
        /// <summary>
        /// Valida que un string ingresado contenga solo letras para ser utilizado como Nombre y/o Apellido. En caso de éxito retorna dicho string, caso contrario retorna "".
        /// </summary>
        /// <param name="dato">String</param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            string aux = dato;

            //verifico cada caracter para ver si son letras o no. Si alguno no lo es, se retorna un string vacío: "".
            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    aux = "";
                    break;
                }
            }

            return aux;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + " " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);

            return sb.ToString();
        }
        #endregion
        
    }
}
