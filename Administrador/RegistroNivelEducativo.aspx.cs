using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_RegistroNivelEducativo : System.Web.UI.Page
{
    private string idNuevoNivel; //Atributo que guarda el codigo generado al cargar la página
    private object resultCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["idNivel"] != null)
            {
                NivelEducativo _n = NivelEducativo_Model.ObtenerNivelEducativo(int.Parse(Request.QueryString["idNivel"]));
                Menu.Titulo = "Modificar Nivel Educativo";
                btnRegister.Text = "Modificar";
                if(_n != null)
                {
                    idNivel.Value = _n.IdNivelEducativo.ToString();
                    txtName.Text = _n.Nombre;
                    txtDescripcion.Text = _n.Descripcion;
                }else
                {
                    Response.Redirect("GestionNivelEducativo.aspx");
                }
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string mensaje = "";
            NivelEducativo nivel = new NivelEducativo(txtName.Text, txtDescripcion.Text);
            if(idNivel.Value.Trim().Length > 0){
                nivel.IdNivelEducativo = int.Parse(idNivel.Value);
                if (NivelEducativo_Model.Modificar(nivel))
                {
                    mensaje = "Materialize.toast('Nivel modificado exitosamente!', 1000, '', function(){ location.href = '/Administrador/GestionNivelEducativo.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }else{
                if (NivelEducativo_Model.Insertar(nivel))
                {
                    mensaje = "Materialize.toast('Nivel registado exitosamente!', 1000, '', function(){ location.href = '/Administrador/GestionNivelEducativo.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }
    }
}