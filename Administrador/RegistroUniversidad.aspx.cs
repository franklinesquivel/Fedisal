using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_RegistroUniversidad : System.Web.UI.Page
{
    private object resultCode;
    private string idNuevaUniversidad;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["idUniversidad"] != null)
            {
                Universidad _n = Universidad_Model.ObtenerUniversidad(int.Parse(Request.QueryString["idUniversidad"]));
                if(_n != null)
                {
                    idUniversidad.Value = _n.IdUniversidad.ToString();
                    txtName.Text = _n.Nombre;
                    txtDireccion.Text = _n.Direccion;
                    txtTelefono.Text = _n.Telefono;
                }
                else
                {
                    Response.Redirect("GestionUniversidad.aspx");
                }
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string mensaje;
            Universidad universidad = new Universidad(txtName.Text, txtDireccion.Text, txtTelefono.Text);
            if(idUniversidad.Value.Trim().Length > 0)
            {
                universidad.IdUniversidad = int.Parse(idUniversidad.Value);
                if (Universidad_Model.Modificar(universidad))
                {
                    mensaje = "Materialize.toast('Universidad modificada exitosamente!', 2000, '', function(){ location.href = '/Administrador/GestionUniversidad.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }
            else
            {
                if (Universidad_Model.Insertar(universidad))
                {
                    mensaje = "Materialize.toast('Universidad registrada exitosamente!', 2000, '', function(){ location.href = '/Administrador/GestionUniversidad.aspx'})";
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