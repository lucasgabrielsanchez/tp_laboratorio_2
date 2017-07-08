using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.html = direccion.AbsoluteUri;
        }

        //creo delegados que posean la firma de los eventos que necesito
        public delegate void ProgresoDescarga(int cantidad);
        public delegate void FinDescarga(string html);

        //creo eventos que luego lanzaré cuando se produzca otro evento
        public event ProgresoDescarga progreso;
        public event FinDescarga fin;

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //lanzo evento con información sobre el porcentaje actual del progreso de la descarga, es un int que permite identificar la posición
            //de carga de la ProgressBar. Este evento será lanzado cuando ocurra un cambio en el progreso de la descarga.
            progreso(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                //lanzo evento con el string final obtenido de la descarga. Este evento será lanzado cuando se llegue al final de la descarga de la página.
                this.html = e.Result;
                fin(html);
            }
            catch
            {
                //si hay un error, deseo que el mismo se muestre en el rtxtHtmlCode del formulario para que se vea su causa.
                fin(e.Error.Message);
            }
        }
    }
}
