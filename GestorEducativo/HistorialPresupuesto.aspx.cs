using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestorEducativo_HistorialPresupuesto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            //Verificar Existencia de becario
            //try
            //{
                if (Becario_Model.VerificarExistencia(Request.QueryString["id"]) > 0)
                {
                    //Recupreramos la informacion
                    RecuperarInformacion(Request.QueryString["id"]);
                }
                else
                {
                    Response.Redirect("/GestorEducativo/IncidentesRegistro.aspx");
                }
            //}
            //catch (Exception err)
            //{
            //    Response.Redirect("/GestorEducativo/IncidentesRegistro.aspx");
            //}
        }
        else
        {
            Response.Redirect("/GestorEducativo/IncidentesRegistro.aspx");
        }
    }

    private void RecuperarInformacion(string id) {
        SqlDataSource1.SelectCommand = "SELECT D.idDesembolso, D.fecha, D.monto, TD.nombre FROM Desembolso D "
                +" INNER JOIN TipoDesembolso TD ON D.idTipoDesembolso = TD.idTipoDesembolso INNER JOIN Ciclo C ON D.idCiclo = C.idBecario"
                +" WHERE C.idBecario = '"+ id +"' ORDER BY fecha DESC ";
        DGV.DataBind();
    }
}