using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _path;

        public Texto(string archivo)
        {
            this._path = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this._path, true))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            { 
                throw e;
            }
        }

        public bool leer(out List<string> datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(this._path))
                {
                    List<string> listaAux = new List<string>();

                    //Mientras NO sea el final del archivo, voy guardando línea por línea hasta que SI sea el final del archivo.
                    while (!sr.EndOfStream)
                    {
                        listaAux.Add(sr.ReadLine());
                    }
                    datos = listaAux;
                }
                return true;
            }
            catch (Exception e)
            {
                throw e; 
            }
        }


    }
}
