using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1;

namespace TrabajoPractico1WindowsForm
{
    public partial class Form1 : Form
    {
        
        

        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double auxDouble;

            Numero a = new Numero(txtNumero1.Text);
            Numero b = new Numero(txtNumero2.Text);
            
            
            auxDouble = Calculadora.operar(a, b,Calculadora.validarOperador(cmbOperacion.Text)); //Si no se selecciona operador, el metodo validarOperador devuelve un + y realiza la operación con dicho operador.
            cmbOperacion.Text = Calculadora.validarOperador(cmbOperacion.Text); //Coloca en el texto del cmb el operador actual que se está utilizando.
            lblResultado.Text = auxDouble.ToString();
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "";
        }

        
    }
}
