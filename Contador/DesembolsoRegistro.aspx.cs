using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesembolsoRegistro : System.Web.UI.Page
{
    private object fucFile;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack) && Request.QueryString["idBecario"] != null && Request.QueryString["idCiclo"] != null)
        {
            if (Becario_Model.ExistenciaCiclo(Request.QueryString["idCiclo"], Request.QueryString["idBecario"]) == 1)
            {
                string sqlTipos = "SELECT nombre, idTipoDesembolso FROM TipoDesembolso"
                + " WHERE idTipoDesembolso NOT IN ("
                + " SELECT TD.idTipoDesembolso FROM Desembolso D"
                + " INNER JOIN TipoDesembolso TD ON D.idTipoDesembolso = TD.idTipoDesembolso WHERE D.idCiclo = "+ Request.QueryString["idCiclo"] + "";
                DBConnection.FillCmb(ref ddlType, sqlTipos, "nombre", "idTipoDesembolso");
                ddlType.Items.Insert(0, new ListItem("[Tipo de desembolso]", "0"));
                idBecario.Value = Request.QueryString["idBecario"];
                idCiclo.Value = Request.QueryString["idCiclo"];
                //DBConnection.FillCmb(ref ddlScholar, "SELECT Becario.idBecario, CONCAT(InformacionPersonal.apellidos, ', ', InformacionPersonal.nombres) AS display FROM (Becario INNER JOIN InformacionPersonal ON InformacionPersonal.idInformacion = Becario.idInformacion)", "display", "idBecario");
                //ddlScholar.Items.Insert(0, new ListItem("[Becario]", "0"));
            }
            else
            {
                Response.Redirect("/Contador/ControlBecario.aspx");
            }
        }else
        {
            Response.Redirect("/Contador/ControlBecario.aspx");
        }
    }

    protected void btnRegisterData_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String scriptstring;
            Desembolso _d = new Desembolso(0, double.Parse(txtAmount.Text), txtDate.Text, int.Parse(ddlType.SelectedValue), int.Parse(idCiclo.Value));

            if (Desembolso_Model.Insert(_d))
            {
                scriptstring = "Materialize.toast('El desembolso ha sido registrado éxitosamente', 2000, '', function(){location.href = 'DesembolsoRegistro.aspx?idCiclo="+ idCiclo.Value + "&idBecario="+ idBecario.Value +"'});";
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

    private bool ValidarCantidad() {
        bool response = true;
        Presupuesto presupuesto = Presupuesto_Model.Obetener(idBecario.Value);
        return response;
    }
}