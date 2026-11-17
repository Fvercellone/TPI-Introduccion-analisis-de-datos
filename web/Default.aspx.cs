using System;
using System.Globalization;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simulador
{
    // C01 - PERSONA 1: clase de la página.
    public partial class Inicio : Page
    {
        // C02 - PERSONA 1: evento que se ejecuta al presionar Calcular.
        // Las incorporaciones de las siguientes etapas están delimitadas dentro del método.
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "";
            // C05: oculta los resultados anteriores antes de validar.
            pnlResultados.Visible = false;
            // INICIO C03 - PERSONA 2: leer y validar cada entrada.
            decimal capital;
            if (LeerNumero(txtCapital, "Capital inicial", true, out capital) == false)
                return;

            decimal tasaNacion1;
            if (LeerNumero(txtNacion1, "Nación - año 1", false, out tasaNacion1) == false)
                return;

            decimal tasaNacion2;
            if (LeerNumero(txtNacion2, "Nación - año 2", false, out tasaNacion2) == false)
                return;

            decimal tasaNacion3;
            if (LeerNumero(txtNacion3, "Nación - año 3", false, out tasaNacion3) == false)
                return;

            decimal tasaProvincia1;
            if (LeerNumero(txtProvincia1, "Provincia - año 1", false, out tasaProvincia1) == false)
                return;

            decimal tasaProvincia2;
            if (LeerNumero(txtProvincia2, "Provincia - año 2", false, out tasaProvincia2) == false)
                return;

            decimal tasaProvincia3;
            if (LeerNumero(txtProvincia3, "Provincia - año 3", false, out tasaProvincia3) == false)
                return;

            decimal tasaHipotecario1;
            if (LeerNumero(txtHipotecario1, "Hipotecario - año 1", false, out tasaHipotecario1) == false)
                return;

            decimal tasaHipotecario2;
            if (LeerNumero(txtHipotecario2, "Hipotecario - año 2", false, out tasaHipotecario2) == false)
                return;

            decimal tasaHipotecario3;
            if (LeerNumero(txtHipotecario3, "Hipotecario - año 3", false, out tasaHipotecario3) == false)
                return;

            // FIN C03
            // INICIO C04 - PERSONA 2: promedios y ganancias con variables explícitas.
            try
            {
                decimal promedioNacion = Calculadora.Promediar(tasaNacion1, tasaNacion2, tasaNacion3);
                decimal gananciaAnualNacion = Calculadora.CalcularGanancia(capital, promedioNacion, 1);
                decimal gananciaTrimestralNacion = Calculadora.CalcularGanancia(capital, promedioNacion, 4);
                decimal gananciaMensualNacion = Calculadora.CalcularGanancia(capital, promedioNacion, 12);

                decimal promedioProvincia = Calculadora.Promediar(tasaProvincia1, tasaProvincia2, tasaProvincia3);
                decimal gananciaAnualProvincia = Calculadora.CalcularGanancia(capital, promedioProvincia, 1);
                decimal gananciaTrimestralProvincia = Calculadora.CalcularGanancia(capital, promedioProvincia, 4);
                decimal gananciaMensualProvincia = Calculadora.CalcularGanancia(capital, promedioProvincia, 12);

                decimal promedioHipotecario = Calculadora.Promediar(tasaHipotecario1, tasaHipotecario2, tasaHipotecario3);
                decimal gananciaAnualHipotecario = Calculadora.CalcularGanancia(capital, promedioHipotecario, 1);
                decimal gananciaTrimestralHipotecario = Calculadora.CalcularGanancia(capital, promedioHipotecario, 4);
                decimal gananciaMensualHipotecario = Calculadora.CalcularGanancia(capital, promedioHipotecario, 12);

                // INICIO C05 - PERSONA 3: una fila de la lista por banco.
                List<FilaResultado> resultados = new List<FilaResultado>();
                resultados.Add(new FilaResultado
                {
                    Banco = "Banco Nación",
                    Anual = gananciaAnualNacion,
                    Trimestral = gananciaTrimestralNacion,
                    Mensual = gananciaMensualNacion
                });
                resultados.Add(new FilaResultado
                {
                    Banco = "Banco Provincia",
                    Anual = gananciaAnualProvincia,
                    Trimestral = gananciaTrimestralProvincia,
                    Mensual = gananciaMensualProvincia
                });
                resultados.Add(new FilaResultado
                {
                    Banco = "Banco Hipotecario",
                    Anual = gananciaAnualHipotecario,
                    Trimestral = gananciaTrimestralHipotecario,
                    Mensual = gananciaMensualHipotecario
                });
                grdGanancias.DataSource = resultados;
                grdGanancias.DataBind();
                pnlResultados.Visible = true;
                // FIN C05
            }
            catch (OverflowException)
            {
                lblMensaje.Text = "Los valores superan la capacidad de cálculo. Ingresá importes o tasas menores.";
                lblMensaje.CssClass = "error";
            }
            // FIN C04
        }

        // INICIO C03 - PERSONA 2
        // Convierte el texto a decimal y muestra el primer error encontrado.
        // "out valor" entrega el número convertido a la variable de quien llama.
        private bool LeerNumero(TextBox campo, string descripcion, bool esCapital, out decimal valor)
        {
            bool valido = decimal.TryParse(campo.Text.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.GetCultureInfo("es-AR"), out valor);

            if (valido == false)
            {
                lblMensaje.Text = descripcion + ": ingresá un número válido, sin puntos de miles.";
                lblMensaje.CssClass = "error";
                return false;
            }
            if (valor < 0)
            {
                lblMensaje.Text = descripcion + ": el número debe ser igual o mayor que cero.";
                lblMensaje.CssClass = "error";
                return false;
            }
            if (esCapital && valor == 0)
            {
                lblMensaje.Text = "El capital debe ser mayor que cero.";
                lblMensaje.CssClass = "error";
                return false;
            }
            return true;
        }
        // FIN C03
    }
}
