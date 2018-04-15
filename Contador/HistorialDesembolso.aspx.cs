using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contador_HistorialDesembolso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (Becario_Model.VerificarExistencia(Request.QueryString["id"]) > 0)
            {
                //Recupreramos la informacion
                RecuperarInformacion(Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("/Contador/listBecarios.aspx");
            }
        }
        else
        {
            Response.Redirect("/Contador/listBecarios.aspx");
        }
    }

    private void RecuperarInformacion(string id)
    {
        SqlDataSource1.SelectCommand = "SELECT D.idDesembolso, D.fecha, D.monto, TD.nombre FROM Desembolso D "
                + " INNER JOIN TipoDesembolso TD ON D.idTipoDesembolso = TD.idTipoDesembolso INNER JOIN Ciclo C ON D.idCiclo = C.idCiclo"
                + " WHERE C.idBecario = '" + id + "' ORDER BY fecha DESC ";
        DGV.DataBind();
    }
}