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
        SqlDataReader dataID = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
        dataID.Read();
        int cadenaID = Int32.Parse(dataID["idInformacion"].ToString());
        Usuario _u = Usuario_Model.ObtenerUsuario(Request.QueryString["idUsuario"],cadenaID);

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
                if (Usuario_Model.Modificar(new Usuario(Int32.Parse(cadenaID), tipoUser,name,apellido,dui,fechaNac,residencia,telefono,email), Request.QueryString["idUsuario"]))
                {
                    mensaje = "Materialize.toast('Usuario modificado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuarios.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error al modificar usuario', 2000)";
                }
        }
        else
        {
            if (Usuario_Model.VerificarExistencia(Int32.Parse(cadenaID)) == 0)
            {
                try
                {
                    if (Usuario_Model.Modificar(new Usuario(Int32.Parse(cadenaID),tipoUser, name, apellido, dui, fechaNac, residencia, telefono, email), Request.QueryString["idUsuario"]))
                    {
                        mensaje = "Materialize.toast('Usuario ingresado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuarios.aspx'})";
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