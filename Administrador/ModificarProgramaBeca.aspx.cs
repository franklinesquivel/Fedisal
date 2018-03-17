using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificarProgramaBeca : System.Web.UI.Page
{
    private string idPrograma;
    private ProgramaBeca programa;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            
        }
        
        if (Request.QueryString["idPrograma"] != null && (!Page.IsPostBack))
        {
            if (ProgramaBeca_Model.VerificarCodigo(Request.QueryString["idPrograma"]) > 0)
            {
                idPrograma = Request.QueryString["idPrograma"];
                //Se establece la informacion en los controles
                EstablecerInformacion();
            }
            else
            {
                Response.Redirect("GestionProgramaBecas.aspx");
            }
        }else
        {
            if (Request.QueryString["idPrograma"] == null)
            {
                Response.Redirect("GestionProgramaBecas.aspx");
            }
        }
    }

    protected void EstablecerInformacion()
    {
        programa = ProgramaBeca_Model.Obtener(idPrograma);
        resultCode.InnerHtml = "<h5 class='center-align  deep-purple-text text-lighten-2'>Código: " + programa.IdPrograma + "</h5>";
        txtName.Text = programa.Nombre;
        txtDescription.Text = programa.Descripcion;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) {
            string mensaje = "";
            try
            {
                programa = new ProgramaBeca(Request.QueryString["idPrograma"], txtName.Text, txtDescription.Text);
                if (ProgramaBeca_Model.Modificar(programa))
                {
                    mensaje = "Materialize.toast('Modifiación exitosa!', 1000, '' ,function(){location.href = 'GestionProgramaBecas.aspx';})";
                }
                else
                {
                    mensaje = "Materialize.toast('No se ha poodido Modificar :(', 2000)";
                }
            }
            catch (Exception err)
            {
                mensaje = "Materialize.toast('Error :(', 2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }
    }
}