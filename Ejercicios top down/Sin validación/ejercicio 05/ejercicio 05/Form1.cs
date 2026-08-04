using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            double f = double.Parse(txtFahrenheit.Text);
            double c = (f - 32) * 5 / 9;
            lblCelsius.Text = c.ToString("F2") + " °C";

        }
    }
}
