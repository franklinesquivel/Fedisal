using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_ModificarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack) && Request.QueryString["idUsuario"] != null)
        {
            SqlDataReader dataID = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
            dataID.Read();
            string cadenaID = dataID["idInformacion"].ToString();
            if (Usuario_Model.VerificarExistencia(Int32.Parse(cadenaID)) > 0)
            { 
                GenerarInformacion();
                tituloF.InnerHtml = "Modificar Usuario";
                btnUsuarios.Text = "Editar";
                DBConnection.FillCmb(ref ddlTipoUsuario, "SELECT * FROM TipoUsuario AS TU INNER JOIN Usuario AS U ON U.idTipoUsuario = TU.idTipoUsuario AND idUsuario = '" + Request.QueryString["idUsuario"] + "';", "descripcion", "idTipoUsuario");
            }
        }
        else
        {
            ddlTipoUsuario.Items.Insert(0, new ListItem("[TipoUsuario]", "0"));
            tituloF.InnerHtml = "Registro de Usuario";
            btnUsuarios.Text = "Registrar";
            DBConnection.FillCmb(ref ddlTipoUsuario, "SELECT * FROM TipoUsuario", "descripcion", "idTipoUsuario");
        }
    }
    protected void GenerarInformacion()
    {
        SqlDataReader data = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
        data.Read();
        txtNombre.Value = data["nombres"].ToString();
        txtApellido.Value = data["apellidos"].ToString();
        txtDui.Value = data["dui"].ToString();
        txtTel.Value = data["telefono"].ToString();
        txtFechaNac.Value = DateTime.Parse(data["fechaNacimiento"].ToString()).ToString("yyyy-MM-dd");
        txtEmail.Value = data["correoElectronico"].ToString();
        txtResidencia.Value = data["direccionResidencia"].ToString();
        data.Close();
    }

    protected void btnUsuarios_Click(object sender, EventArgs e)
    {
        SqlDataReader dataID = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
        dataID.Read();
        string name = txtNombre.Value;
        string apellido = txtApellido.Value;
        string telefono = txtTel.Value;
        string dui = txtDui.Value;
        string email = txtEmail.Value;
        DateTime fechaNac = DateTime.Parse(txtFechaNac.Value);
        string residencia = txtResidencia.Value;
        string tipoUser = ddlTipoUsuario.SelectedValue;
        string mensaje = "";
        
        
        string cadenaID = dataID["idInformacion"].ToString();
        if (Request.QueryString["idUsuario"] != null)
        {
            if (Usuario_Model.VerificarExistencia(Int32.Parse(cadenaID)) == 0)
            {
                if (Usuario_Model.Modificar(new Usuario(tipoUser,name,apellido,dui,fechaNac,residencia,telefono,email), Request.QueryString["idUsuario"]))
                {
                    mensaje = "Materialize.toast('Usuario modificado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuario.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error al modificar usuario', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Usuario ya existe', 2000)";
            }
        }
        else
        {
            if (Usuario_Model.VerificarExistencia(Int32.Parse(cadenaID)) == 0)
            {
                try
                {
                    if (Usuario_Model.Modificar(new Usuario(tipoUser, name, apellido, dui, fechaNac, residencia, telefono, email), Request.QueryString["idUsuario"]))
                    {
                        mensaje = "Materialize.toast('Usuario ingresado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuario.aspx'})";
                    }
                }
                catch (Exception E)
                {
                    mensaje = "Materialize.toast('Error al modificar usuario', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Usuario ya existe', 2000)";
            }
        }
        dataID.Close();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
    }
}