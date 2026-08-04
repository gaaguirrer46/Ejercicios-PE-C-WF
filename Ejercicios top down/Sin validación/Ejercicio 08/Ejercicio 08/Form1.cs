using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double sBase = double.Parse(txtSueldoBase.Text);
            double v1 = double.Parse(txtVenta1.Text);
            double v2 = double.Parse(txtVenta2.Text);
            double v3 = double.Parse(txtVenta3.Text);
            double comision = (v1 + v2 + v3) * 0.1;
            double total = sBase + comision;
            lblComision.Text = "$" + comision.ToString("F2");
            lblTotal.Text = "$" + total.ToString("F2");
        }
    }
}
