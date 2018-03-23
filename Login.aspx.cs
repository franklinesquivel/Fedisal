using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Sesion.VerificarUsuario(HttpContext.Current.Session["ID"].ToString());
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        string patternUsuario = "([A-Z]{4}[0-9]{7}|[A]{1}[0-9]{4}|[C]{1}[0-9]{4}|[G]{1}[0-9]{4})",
            patternBecario = "([A-Z]{4}[0-9]{7})", mensaje = "";

        if (Regex.IsMatch(txtUsername.Text.ToUpper(), patternBecario))
        {
            if (Becario_Model.Login(txtUsername.Text, txtPassword.Text))
            {
                mensaje = "Materialize.toast('Becario encontrado', 2000)";
            }
            else
            {
                mensaje = "Materialize.toast('Becario no encontrado', 2000)";
            }
        }
        else if (Regex.IsMatch(txtUsername.Text.ToUpper(), patternUsuario))
        {
            if (Usuario_Model.Login(txtUsername.Text, txtPassword.Text))
            {
                //Inicializar variables de sesión
                mensaje = "Materialize.toast('Usuario encontrado', 2000)";
                Response.Redirect("/Login.aspx");
            }
            else
            {
                mensaje = "Materialize.toast('Usuario no encontrado', 2000)";
            }
        }else{
            mensaje = "Materialize.toast('Hola', 2000)";
        }
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
    }
}