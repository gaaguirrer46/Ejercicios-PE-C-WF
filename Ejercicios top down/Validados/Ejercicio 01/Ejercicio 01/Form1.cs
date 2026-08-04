using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaludar_Click(object sender, EventArgs e)
        {
            // El try es como un "inténtalo, pero si algo falla, lo capturamos y validamos"
            try
            {
                // Obtenemos lo que el usuario escribió
                string nombre = txtNombre.Text;

                // ------------------------------------------------------------------
                // 1. Validación de obligatoriedad (¿dejó el campo vacío?)
                //    IsNullOrWhiteSpace detecta null, vacío o solo espacios.
                //    Esto evita que el saludo sea "Hola, " o "Hola,    ".
                // ------------------------------------------------------------------
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }

                // ------------------------------------------------------------------
                // 2. Validación de longitud (¿escribió demasiado?)
                //    Ponemos un límite de 50 caracteres para que no se desborde el Label.
                // ------------------------------------------------------------------
                if (nombre.Length > 50)
                {
                    throw new ArgumentException("El nombre es demasiado largo (máx 50 caracteres).");
                }

                // ------------------------------------------------------------------
                // 3. Validación de caracteres permitidos (solo letras, espacios y guiones)
                //    Usamos una expresión regular que acepta CUALQUIER letra con acentos,
                //    eñes, diéresis, etc. gracias a la clase \p{L} que significa "letra"
                //    en cualquier idioma. También permitimos espacios y guiones.
                //    Así aceptamos: José, María, Ñuñez, Möller, etc.
                //    No usamos ciclos ni arreglos, solo una comprobación con IsMatch.
                // ------------------------------------------------------------------
                if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[\p{L}\s\-]+$"))
                {
                    throw new ArgumentException("El nombre solo puede contener letras, espacios y guiones.");
                }

                // ------------------------------------------------------------------
                // Si llegamos hasta aquí, el nombre es válido.
                // Ahora sí, ejecutamos la línea original que queríamos.
                // Además, le quitamos los espacios de los extremos por estética.
                // ------------------------------------------------------------------
                nombre = nombre.Trim();
                lblMensaje.Text = "Hola, " + nombre;
            }
            // Atrapamos primero los errores de validación (los que lanzamos nosotros)
            catch (ArgumentException ex)
            {
                MessageBox.Show("DATO INCORRECTO: " + ex.Message,
                                "Validación fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Ayudamos al usuario a corregir: foco y selección de todo
                txtNombre.Focus();
                txtNombre.SelectAll();

                // Limpiamos el mensaje para que no quede basura
                lblMensaje.Text = "Ingresa un nombre válido.";
            }
            // Red de seguridad para errores imprevistos del sistema
            catch (Exception ex)
            {
                MessageBox.Show("ERROR INESPERADO: " + ex.Message,
                                "Error crítico",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
