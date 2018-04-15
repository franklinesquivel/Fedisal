using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contador_PresupuestoInicial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (Becario_Model.VerificarExistencia(Request.QueryString["id"]) == 0)
            {
                Response.Redirect("/Contador/listaBecarios.aspx");
            }
        }
        else
        {
            Response.Redirect("/Contador/listaBecarios.aspx");
        }
    }
}