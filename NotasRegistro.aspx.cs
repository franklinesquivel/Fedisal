using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotasRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string becario = "ATDS20180001";//cambiar por variable de sesion del codigo

            DBConnection.FillCmb(ref ddlCiclo, "SELECT * FROM Ciclo WHERE idBecario='"+ becario +"'","nCiclo","idCiclo");
            ddlCiclo.Items.Insert(0, new ListItem("[Ciclo]", "0"));
            ddlTercioSuperior.Items.Insert(0, new ListItem("[Tercio Superior]","0"));
            }
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int TS;
            string msg;
            if (Convert.ToBoolean(ddlTercioSuperior.SelectedValue) == true){ TS = 1;}
            else{ TS = 0;}

            Notas Nota = new Notas(txtNombreMateria.Text, Convert.ToDecimal(txtNotaMateria.Text),Convert.ToByte(TS),int.Parse(ddlCiclo.SelectedValue));
            if (Notas_Model.Insertar(Nota))
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