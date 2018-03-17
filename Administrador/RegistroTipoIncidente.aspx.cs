using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_RegistroTipoIncidente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack) && Request.QueryString["id"] != null)
        {
            if (TipoIncidente_Model.VerificarExistencia(Int32.Parse(Request.QueryString["id"])) > 0)
            { //Se verifica la existencia de la carrera a modificar
                EstablecerInformacion();
            }
        }
        else
        {
            title.InnerHtml = "Registro";
        }
    }

    protected void EstablecerInformacion() {
        TipoIncidente _t = TipoIncidente_Model.ObtenerTipo(Int32.Parse(Request.QueryString["id"]));
        txtName.Text = _t.Nombre;
        txtDescription.Text = _t.Descripcion;
        title.InnerHtml = "Modificar";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string nombre = txtName.Text, mensaje = "", descripcion = txtDescription.Text;

        if (Request.QueryString["id"] == null)
        {
            if (TipoIncidente_Model.VerificarExistencia(nombre) == 0)
            {
                if (TipoIncidente_Model.Insertar(new TipoIncidente(nombre, descripcion))) //Proceso para agregar nuevo tipo incidente
                {
                    mensaje = "Materialize.toast('Tipo de Incidente registrado con exito', 1000, '', function(){ location.href = '/Administrador/RegistroTipoIncidente.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error al registrar', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Tipo Incidente ya existe', 2000)";
            }//Fin proceso para agregar nuevo tipo Inicidente
        }
        else
        {
            if (TipoIncidente_Model.VerificarExistencia(nombre) == 0)//Proceso para modificar Tipo Incidente
            {
                try
                {
                    if (TipoIncidente_Model.Modificar(new TipoIncidente(Int32.Parse(Request.QueryString["id"]), nombre, descripcion)))
                    {
                        mensaje = "Materialize.toast('Tipo Incidente modificado con exito', 1000, '', function(){ location.href = '/Administrador/GestionTipoIncidente.aspx'})";
                    }
                    else
                    {
                        mensaje = "Materialize.toast('Error al modificar', 2000)";
                    }
                }
                catch (Exception Err)
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Tipo Incidente ya existe', 2000)";
            }//Fin proceso para modificar Tipo Incidente
        }
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
    }
}