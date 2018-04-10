using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_GestionUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            idH.Text = HttpContext.Current.Session["ID"].ToString();
        }
    }

    [System.Web.Services.WebMethod]
    public static object EliminarUsuario(string idUsuario)
    {
        try
        {
            return Usuario_Model.Eliminar(idUsuario.ToString());
        }
        catch (Exception e)
        {
            return false;
        }
    }
}