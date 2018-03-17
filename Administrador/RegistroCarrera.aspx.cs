using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_RegistroCarrera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack) && Request.QueryString["id"] != null)
        {
            if (Carrera_Model.VerificarExistencia(Int32.Parse(Request.QueryString["id"])) > 0) { //Se verifica la existencia de la carrera a modificar
                EstablecerInformacion();
            }
        }else
        {
            title.InnerHtml = "Registro Carrera";
        }
    }

    protected void EstablecerInformacion() {//Recupera y establece la informacion en los campos
        Carrera _c = Carrera_Model.ObtenerCarrera(Int32.Parse(Request.QueryString["id"]));
        txtName.Text = _c.Nombre;
        title.InnerHtml = "Modificar Carrera";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string nombre = txtName.Text, mensaje = "";

        if (Request.QueryString["id"] == null)
        {
            if (Carrera_Model.VerificarExistencia(nombre) == 0)
            {
                if (Carrera_Model.Insertar(new Carrera(nombre))) //Proceso para agregar nueva carrea
                {
                    mensaje = "Materialize.toast('Carrera Registrada con exito', 1000, '', function(){ location.href = 'RegistroCarrera.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error al registrar', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Carrera ya existe', 2000)";
            }//Fin proceso para agregar nueva carrera
        }else
        {
            if (Carrera_Model.VerificarExistencia(nombre) == 0)//Proceso para modificar carrera
            {
                try
                {
                    if (Carrera_Model.Modificar(new Carrera(Int32.Parse(Request.QueryString["id"]), nombre)))
                    {
                        mensaje = "Materialize.toast('Carrera modificada con exito', 1000, '', function(){ location.href = '/Administrador/GestionCarreras.aspx'})";
                    }
                    else {
                        mensaje = "Materialize.toast('Error al modificar', 2000)";
                    }
                }
                catch (Exception Err) {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }
            else {
                mensaje = "Materialize.toast('Carrera ya existe', 2000)";
            }//Fin proceso para modificar carrera
        }
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
    }
}