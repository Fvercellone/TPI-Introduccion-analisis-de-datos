<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="Simulador.Inicio" ResponseEncoding="utf-8" %>
<!doctype html>
<html lang="es-AR">
<head><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/><title>Simulador de plazos fijos</title><link rel="stylesheet" href="estilos.css"/></head>
<body><main>
<header><small>UTN · Análisis de datos</small><h1>Simulador de plazos fijos</h1></header>
<form id="formulario" runat="server">
<p><asp:Label ID="lblCapital" runat="server" AssociatedControlID="txtCapital" Text="Capital inicial en pesos"/>
<asp:TextBox ID="txtCapital" runat="server" Text="850000"/></p>
<h2>Tasas nominales anuales (%)</h2>
<p>Ingresá los valores sin separador de miles. Para decimales usá coma (por ejemplo, 12,5).</p>
<table><thead><tr><th>Banco</th><th><%= DateTime.Today.Year - 3 %></th><th><%= DateTime.Today.Year - 2 %></th><th><%= DateTime.Today.Year - 1 %></th></tr></thead><tbody>
<tr><th scope="row">Banco Nación</th>
  <td><asp:TextBox ID="txtNacion1" runat="server" aria-label="Banco Nación, año 1 de tres"/></td>
  <td><asp:TextBox ID="txtNacion2" runat="server" aria-label="Banco Nación, año 2 de tres"/></td>
  <td><asp:TextBox ID="txtNacion3" runat="server" aria-label="Banco Nación, año 3 de tres"/></td>
</tr>
<tr><th scope="row">Banco Provincia</th>
  <td><asp:TextBox ID="txtProvincia1" runat="server" aria-label="Banco Provincia, año 1 de tres"/></td>
  <td><asp:TextBox ID="txtProvincia2" runat="server" aria-label="Banco Provincia, año 2 de tres"/></td>
  <td><asp:TextBox ID="txtProvincia3" runat="server" aria-label="Banco Provincia, año 3 de tres"/></td>
</tr>
<tr><th scope="row">Banco Hipotecario</th>
  <td><asp:TextBox ID="txtHipotecario1" runat="server" aria-label="Banco Hipotecario, año 1 de tres"/></td>
  <td><asp:TextBox ID="txtHipotecario2" runat="server" aria-label="Banco Hipotecario, año 2 de tres"/></td>
  <td><asp:TextBox ID="txtHipotecario3" runat="server" aria-label="Banco Hipotecario, año 3 de tres"/></td>
</tr>
</tbody></table>
<asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click"/>
<p role="status"><asp:Label ID="lblMensaje" runat="server"/></p>

</form>
</main></body></html>
