using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    public class Calculadora
    {
        
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double numer1 = numero1.getNumero();
            double numer2 = numero2.getNumero();
            double devolucion=0;

            //Buscar como castear el operador directamente.
            switch (operador)
            {
                case "*":
                    devolucion = numer1 * numer2;
                break;

                case "-":
                    devolucion = numer1 - numer2;
                break;

                case "+":
                    devolucion = numer1 + numer2;
                break;

                case "/":
                if (numer2 == 0)
                    devolucion = 0;
                else
                    devolucion = numer1 / numer2;
                break;
            }

            return devolucion;

        }

        public static string validarOperador(string operador)
        {
            string devolucion = "+";

            if (operador == "-" || operador == "*" || operador == "/")
            {
                devolucion = operador;
            }

            return devolucion;
        }

    }
}
