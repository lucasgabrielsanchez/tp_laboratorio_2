using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo de texto y se valida con try/catch si se produce un error en el proceso. De producirse se lanza la excepción.
        /// </summary>
        /// <param name="archivo">path y nombre del archivo</param>
        /// <param name="datos">La cadena a ser guardada en el archivo</param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                //con el bloque using, si se produce un error, o si se cumple correctamente lo que esta dentro, luego elimina todas las dependencias, es decir, cierra los
                //archivos abiertos, etc. Evito tener que poner sw.Close();. Con true en el StreamWriter, appendeo.
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo de texto y se valida con try/catch si se produce un error en el proceso. De producirse se lanza la excepción.
        /// </summary>
        /// <param name="archivo">path y nombre del archivo a ser leído</param>
        /// <param name="datos">parámetro out en el cual debemos pasarle el objeto donde se guardará el texto traído si fué exitoso.</param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                using(StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            
            catch(Exception e)
            {
                datos = "";
                throw new ArchivosException(e);
            }
        }
    }
}
