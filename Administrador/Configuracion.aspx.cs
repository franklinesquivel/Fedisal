using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_Configuracion : System.Web.UI.Page
{
    string mensaje = "";
    private static int idIn = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            GenerarInformacion();
        }
    }

    protected void GenerarInformacion()
    {
        SqlDataReader dataID = DBConnection.GetData("SELECT * FROM InformacionPersonal IP INNER JOIN Usuario U ON U.idInformacion = IP.idInformacion WHERE U.idUsuario = '"+ HttpContext.Current.Session["ID"].ToString() + "'");
        dataID.Read();
        int cadenaID = Int32.Parse(dataID["idInformacion"].ToString());
        idIn = cadenaID;
        Usuario _u = Usuario_Model.ObtenerUsuario(HttpContext.Current.Session["ID"].ToString(), cadenaID);

        txtNombre.Value = _u.Nombre.Trim();
        txtApellido.Value = _u.Apellido.Trim();
        txtDui.Value = _u.Dui.Trim();
        txtTel.Value = _u.Telefono.Trim();
        txtFechaNac.Value = DateTime.Parse(dataID["fechaNacimiento"].ToString()).ToString("yyyy-MM-dd");
        txtEmail.Value = _u.Correo.Trim();
        txtResidencia.Value = _u.Residencia.Trim();
        dataID.Close();
    }

    protected void btnUsuarios_Click(object sender, EventArgs e)
    {
        string name = txtNombre.Value;
        string apellido = txtApellido.Value;
        string telefono = txtTel.Value;
        string dui = txtDui.Value;
        string email = txtEmail.Value;
        DateTime fechaNac = DateTime.Parse(txtFechaNac.Value);
        string residencia = txtResidencia.Value;
        string contra = "";
        if (txtcontra2.Value == "" && txtcontra1.Value == "") {
            contra = Usuario_Model.obtenerCon(HttpContext.Current.Session["ID"].ToString());
            if (Usuario_Model.modificarCuenta(new Usuario(name, apellido, dui, fechaNac, residencia, telefono, email), HttpContext.Current.Session["ID"].ToString(), contra))
            {
                mensaje = "Materialize.toast('Tu usuario fue modificado con exito', 2000, '', function(){ location.href = '/Administrador/'})";
            }
            else
            {
                mensaje = "Materialize.toast('Error al modificar tu usuario', 2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }
        else{
            if (txtcontra1.Value == txtcontra2.Value)
            {
                contra = txtcontra2.Value;
                if (Usuario_Model.modificarCuenta(new Usuario(name, apellido, dui, fechaNac, residencia, telefono, email), HttpContext.Current.Session["ID"].ToString(), contra))
                {
                    if (Correo.EnviarCorreoUsuario(new Usuario(email,name,contra,Usuario_Model.obtenerId(HttpContext.Current.Session["ID"].ToString())))) {
                        mensaje = "Materialize.toast('Tu usuario fue modificado con exito', 2000, '', function(){ location.href = '/Administrador/'})";
                    } else {
                        mensaje = "Materialize.toast('Error al modificar tu usuario', 2000)";
                    }
                    
                }
                else
                {
                    mensaje = "Materialize.toast('Error al modificar tu usuario', 2000)";
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
            }
            else {
                mensaje = "Materialize.toast('Las contraseñas no coinciden', 2000)";
            }
        }
    }

    protected void cv1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (txtcontra1.Value.ToString() == txtcontra2.Value.ToString());
    }
}