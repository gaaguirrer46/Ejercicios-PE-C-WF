using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double baseVal = double.Parse(txtBase.Text);
            double altura = double.Parse(txtAltura.Text);
            double perimetro = 2 * baseVal + 2 * altura;
            double area = baseVal * altura;
            lblPerimetro.Text = perimetro.ToString("F2");
            lblArea.Text = area.ToString("F2");
        }
    }
}
