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
            // El try es nuestro "inténtalo, pero si algo falla lo vamos a validar"
            try
            {
                // ------------------------------------------------------------------
                // 1. Validación de obligatoriedad (¿dejaron los campos vacíos?)
                //    IsNullOrWhiteSpace detecta null, vacío o solo espacios.
                //    Si alguno está vacío, lanzamos error.
                // ------------------------------------------------------------------
                if (string.IsNullOrWhiteSpace(txtBase.Text))
                {
                    throw new ArgumentException("La base no puede estar vacía.");
                }
                if (string.IsNullOrWhiteSpace(txtAltura.Text))
                {
                    throw new ArgumentException("La altura no puede estar vacía.");
                }

                // ------------------------------------------------------------------
                // 2. Validación de tipo de dato (¿escribieron números?)
                //    Usamos double.TryParse en lugar de double.Parse.
                //    Si la conversión falla, lanzamos nuestro propio error.
                //    Esto es más seguro y evita que el programa se caiga.
                // ------------------------------------------------------------------
                if (!double.TryParse(txtBase.Text, out double baseVal))
                {
                    throw new ArgumentException("La base debe ser un número decimal válido (usa punto para decimales).");
                }
                if (!double.TryParse(txtAltura.Text, out double altura))
                {
                    throw new ArgumentException("La altura debe ser un número decimal válido (usa punto para decimales).");
                }

                // ------------------------------------------------------------------
                // 3. Validación de rango (¿son números positivos?)
                //    En geometría, base y altura deben ser mayores que cero.
                //    También ponemos un límite superior razonable (por ejemplo, 1e6)
                //    para evitar números desorbitados.
                // ------------------------------------------------------------------
                if (baseVal <= 0)
                {
                    throw new ArgumentException("La base debe ser un número positivo (mayor que 0).");
                }
                if (altura <= 0)
                {
                    throw new ArgumentException("La altura debe ser un número positivo (mayor que 0).");
                }
                if (baseVal > 1e6 || altura > 1e6)
                {
                    throw new ArgumentException("Los valores son demasiado grandes (máximo 1,000,000).");
                }

                // ------------------------------------------------------------------
                // Si llegamos hasta aquí, los datos son válidos.
                // Ahora sí, hacemos los cálculos y mostramos los resultados.
                // ------------------------------------------------------------------
                double perimetro = 2 * baseVal + 2 * altura;
                double area = baseVal * altura;

                // Mostramos con dos decimales (F2) como en tu código original
                lblPerimetro.Text = perimetro.ToString("F2");
                lblArea.Text = area.ToString("F2");
            }
            // ------------------------------------------------------------------
            // Atrapamos primero los errores que nosotros lanzamos (ArgumentException)
            // y mostramos un mensaje claro para el usuario.
            // ------------------------------------------------------------------
            catch (ArgumentException ex)
            {
                MessageBox.Show("DATO INCORRECTO: " + ex.Message,
                                "Validación fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Ponemos el foco en el primer campo para que corrija rápidamente
                txtBase.Focus();
                txtBase.SelectAll();

                // Limpiamos los resultados para que no queden valores de intentos anteriores
                lblPerimetro.Text = "";
                lblArea.Text = "";
            }
            // ------------------------------------------------------------------
            // Atrapamos cualquier otro error imprevisto (red de seguridad)
            // ------------------------------------------------------------------
            catch (Exception ex)
            {
                MessageBox.Show("ERROR INESPERADO: " + ex.Message,
                                "Error crítico",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // También limpiamos los resultados por si acaso
                lblPerimetro.Text = "";
                lblArea.Text = "";
            }
        }
    }
}
