using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtNum1.Text);
            double n2 = double.Parse(txtNum2.Text);
            lblSuma.Text = (n1 + n2).ToString();
            lblResta.Text = (n1 - n2).ToString();
            lblMultiplicacion.Text = (n1 * n2).ToString();
            lblDivision.Text = (n1 / n2).ToString();

        }
    }
}
