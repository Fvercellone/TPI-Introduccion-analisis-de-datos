using System;
using System.Globalization;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simulador
{
    public partial class Inicio : Page
    {
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "";
            
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

            
            lblMensaje.Text = "Datos válidos.";
        }

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
       
    }
}
