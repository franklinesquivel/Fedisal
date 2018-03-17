using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresupuestoRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DBConnection.FillCmb(ref ddlScholar, "SELECT Becario.idBecario, CONCAT(InformacionPersonal.apellidos, ', ', InformacionPersonal.nombres) AS display FROM (Becario INNER JOIN InformacionPersonal ON InformacionPersonal.idInformacion = Becario.idInformacion)", "display", "idBecario");
            ddlScholar.Items.Insert(0, new ListItem("[Becario]", "0"));
        }
    }

    protected void btnRegisterData_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String scriptstring;
            Presupuesto _p = new Presupuesto(double.Parse(txtLibro.Text), double.Parse(txtColegiatura.Text), double.Parse(txtManutencion.Text), double.Parse(txtMatricula.Text), double.Parse(txtOtros.Text), double.Parse(txtGraduacion.Text), ddlScholar.SelectedValue);

            if (Presupuesto_Model.Insert(_p))
            {
                scriptstring = "Materialize.toast('El presupuesto ha sido registrado éxitosamente', 2000, '', function(){location.href = 'PresupuestoRegistro.aspx'});";
            }
            else
            {
                scriptstring = "Materialize.toast(Ha ocurrido un error :(', 2000);";

            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", scriptstring, true);
        }
    }

    protected void validate_positiveValue(object source, ServerValidateEventArgs args)
    {
        args.IsValid = double.Parse(args.Value) > 0;
    }
}