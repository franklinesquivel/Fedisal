using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public static bool InsertarIncidente(Incidentes incidentes)
    {
        SqlCommand comando = DBConnection.GetCommand("INSERT INTO BitacoraIncidentes(idTipoIncidente,idBecario) VALUES(@idTipo,@idBeca)");
        comando.Parameters.Add("@idTipo", SqlDbType.Int);
        comando.Parameters.Add("@idBeca", SqlDbType.VarChar);

        comando.Parameters["@idTipo"].Value = incidentes.IdTipoIncidente;
        comando.Parameters["@idBeca"].Value = incidentes.IdBecario;
        

        if (DBConnection.ExecuteCommandIUD(comando))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        string idBecario;
        idBecario = txtIdBecario.Text;

        Page.Validate();
        if (Page.IsValid)
        {
            string msg;

            Incidentes incidente = new Incidentes(idBecario , int.Parse(ddlIncidentes.SelectedValue));

            if (InsertarIncidente(incidente))
            {
                msg = "Materialize.toast('Incidente aplicado con exito', 2000, '')";
            }
            else
            {
                msg = "Materialize.toast('Ha ocurrido un Error',2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", msg, true);
        }
    }
}