using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_GestionTipoIncidente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static object EliminarTipo(string idTipo)
    {
        try
        {
            return TipoIncidente_Model.Eliminar(Int32.Parse(idTipo.ToString()));
        }
        catch (Exception e)
        {
            return false;
        }
    }
}