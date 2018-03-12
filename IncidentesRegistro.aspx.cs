using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncidentesRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DBConnection.FillCmb(ref ddlIncidentes, "SELECT * FROM TipoIncidente", "nombre", "idTipoIncidente");
            ddlIncidentes.Items.Insert(0, new ListItem("[Incidentes]", "0"));
        }
    }
    [System.Web.Services.WebMethod]
    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        string idBecario = "";
        Page.Validate();
        if (Page.IsValid)
        {
            string msg;

            Incidentes incidente = new Incidentes(idBecario,Convert.ToInt32(ddlIncidentes.SelectedValue));

            if (Incidentes.InsertarIncidente(incidente))
            {
                msg = "Materialize.toast('Nota agregada con exito', 2000, '', function(){ location.href = 'NotasRegistro.aspx'})";
            }
            else
            {
                msg = "Materialize.toast('Ha ocurrido un Error',2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", msg, true);
        }
    }
}