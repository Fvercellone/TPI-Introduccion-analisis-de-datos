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
            lblMensaje.Text = "El formulario está listo.";
        }
    }
}
