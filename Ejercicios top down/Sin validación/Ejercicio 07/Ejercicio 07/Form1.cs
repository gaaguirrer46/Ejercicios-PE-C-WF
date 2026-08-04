using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            int totalMin = int.Parse(txtMinutos.Text);
            int horas = totalMin / 60;
            int minResto = totalMin % 60;
            lblResultado.Text = horas + " horas y " + minResto + " minutos";
        }
    }
}
