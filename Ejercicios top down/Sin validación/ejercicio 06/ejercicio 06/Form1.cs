using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtNum1.Text);
            double n2 = double.Parse(txtNum2.Text);
            double n3 = double.Parse(txtNum3.Text);
            double promedio = (n1 + n2 + n3) / 3;
            lblPromedio.Text = promedio.ToString("F2");
        }
    }
}
