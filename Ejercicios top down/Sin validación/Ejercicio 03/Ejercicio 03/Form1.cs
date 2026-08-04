using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double c1 = double.Parse(txtCateto1.Text);
            double c2 = double.Parse(txtCateto2.Text);
            double hip = Math.Sqrt(c1 * c1 + c2 * c2);
            lblHipotenusa.Text = hip.ToString("F2");
        }
    }
}
