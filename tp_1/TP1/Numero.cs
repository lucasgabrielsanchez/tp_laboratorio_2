using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Numero
    {

        private double numero;

        public double getNumero()
        {
            return this.numero;
        }

        private void setNumero(string numero)
        {
            this.numero = Numero.validarNumero(numero);

        }

        private static double validarNumero(string numeroString)
        {
            double aux;

            if (double.TryParse(numeroString, out aux))
                return aux;
            else
                return 0;
        }


        //public void setNumero()

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        public Numero(double numero1)
        {
            this.numero = numero1;
        }


    }

}
