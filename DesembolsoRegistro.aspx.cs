using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesembolsoRegistro : System.Web.UI.Page
{
    private object fucFile;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DBConnection.FillCmb(ref ddlType, "SELECT * FROM TipoDesembolso", "nombre", "idTipoDesembolso");
            ddlType.Items.Insert(0, new ListItem("[Tipo de desembolso]", "0"));

            DBConnection.FillCmb(ref ddlScholar, "SELECT Becarios.idBecario, CONCAT(InformacionPersonal.apellidos, ', ', InformacionPersonal.nombres) AS display FROM (Becarios INNER JOIN InformacionPersonal ON InformacionPersonal.idInformacion = Becarios.idInformacion)", "display", "idBecario");
            ddlScholar.Items.Insert(0, new ListItem("[Becario]", "0"));
        }
    }

    protected void btnRegisterData_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String scriptstring;
            Desembolso _d = new Desembolso(0, double.Parse(txtAmount.Text), txtDate.Text, int.Parse(ddlType.SelectedValue), ddlScholar.SelectedValue);

            if (Desembolso_Model.Insert(_d))
            {
                scriptstring = "Materialize.toast('El desembolso ha sido registrado éxitosamente', 2000, '', function(){location.href = 'DesembolsoRegistro.aspx'});";
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