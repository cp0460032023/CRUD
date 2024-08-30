using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadenaconexion
{
    // Clase estática Program que contiene el punto de entrada principal de la aplicación
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Atributo que indica que la aplicación utiliza un modelo de subprocesos de un solo apartamento (STA)
        static void Main()
        {
            // Habilita los estilos visuales para los formularios, aplicando el aspecto visual del sistema operativo
            Application.EnableVisualStyles();

            // Establece la configuración de renderizado de texto de los controles a predeterminado, usando GDI+ para mejor calidad
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y muestra el formulario principal (Form1)
            Application.Run(new Form1());
        }
    }
}
