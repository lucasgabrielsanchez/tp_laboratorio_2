using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        /// <summary>
        /// Método que serializa un objeto pasado por parámetro, contiene validación try/catch por si se sucede un error en el proceso. De hacerlo, se lanza una excepción.
        /// </summary>
        /// <param name="archivo">patch donde se guardará el archivo + el nombre del mismo</param>
        /// <param name="datos">Objeto a ser serializado</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(archivo);
                xs.Serialize(sw, datos);
                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            } 
        }


        /// <summary>
        /// Método que deserializa un archivo xml que se encuentre en el path indicado, contiene validación try/catch por si se sucede un error en el proceso.
        /// De hacerlo, se lanza una excepción.
        /// </summary>
        /// <param name="archivo">patch donde se leerá el archivo + el nombre del mismo</param>
        /// <param name="datos">objeto donde se alojarán los datos obtenidos del archivo</param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivo);
                datos = (T)xs.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = default(T); //El default se utiliza para devolver T en su forma original ya que se produjo un error al deserializar.
                throw new ArchivosException(e);
            }
        }
    }
}
