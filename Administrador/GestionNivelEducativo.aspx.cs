using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_GestionNivelEducativo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Services.WebMethod]
    public static object EliminarNivel(String idNivel)
    {
        try
        {

            return NivelEducativo_Model.Eliminar(Int32.Parse(idNivel.ToString()));
        }
        catch (Exception e)
        {
            return false;
        }
    }
}