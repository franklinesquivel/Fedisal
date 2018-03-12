using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestionProgramaBecas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static object ObtenerProgramas(object peticion)
    {
        try {
            return ProgramaBeca_Model.Obtener();
        }
        catch (Exception e)
        {
            return false;
        }
    } //Fin metodo ObtenerProgramas

    [System.Web.Services.WebMethod]
    public static object EliminarPrograma(string idPrograma)
    {
        try
        {
           return ProgramaBeca_Model.Eliminar(idPrograma.ToString());
        }
        catch (Exception e)
        {
            return false;
        }
    }
}