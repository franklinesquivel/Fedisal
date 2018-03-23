using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_ModificarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack) && Request.QueryString["idUsuario"] != null)
        {
            SqlDataReader dataID = DBConnection.GetData("SELECT ip.idInformacion FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
            if(dataID != null)
            {
                dataID.Read();
                string cadenaID = dataID["idInformacion"].ToString();
                dataID.Close();
                if (Usuario_Model.VerificarExistencia(Int32.Parse(cadenaID)) > 0)
                {
                    GenerarInformacion();
                    btnUsuarios.Text = "Editar";
                    DBConnection.FillCmb(ref ddlTipoUsuario, "SELECT * FROM TipoUsuario", "descripcion", "idTipoUsuario");
                    SqlDataReader dataDDL = DBConnection.GetData("SELECT idTipoUsuario FROM Usuario WHERE idUsuario = '" + Request.QueryString["idUsuario"] + "'");
                    dataDDL.Read();
                    string ddlvalue = dataDDL["idTipoUsuario"].ToString();
                    ddlTipoUsuario.SelectedValue = ddlvalue;
                    idUsuario.Value = Request.QueryString["idUsuario"];
                    verificarAccion.Visible = false;
                    verificarAcciones2.Visible = false;
                    dataDDL.Close();
                }
            }else
            {
                Response.Redirect("GestionUsuarios.aspx");
            }
        }
        else
        {
            btnUsuarios.Text = "Registrar";
            DBConnection.FillCmb(ref ddlTipoUsuario, "SELECT * FROM TipoUsuario WHERE descripcion = 'Contador' OR descripcion = 'GestorEducativo'", "descripcion", "idTipoUsuario");
            ddlTipoUsuario.DataBind();
            verificarAccion.Visible = true;
            verificarAcciones2.Visible = true;
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
        string patternG = "(G[0-9]{4})";
        string patternC = "(C[0-9]{4})";
        string patternA = "(A[0-9]{4})";
        string name = txtNombre.Value;
        string apellido = txtApellido.Value;
        string telefono = txtTel.Value;
        string dui = txtDui.Value;
        string email = txtEmail.Value;
        DateTime fechaNac = DateTime.Parse(txtFechaNac.Value);
        string residencia = txtResidencia.Value;
        string tipoUser = "";
        string codigoUser = Request.QueryString["idUsuario"] != null ? idUsuario.Value : txtUsername.Text;
        if (Regex.IsMatch(codigoUser.ToUpper(), patternC))
        {
            tipoUser = "C";
        }
        else if(Regex.IsMatch(codigoUser.ToUpper(), patternG))
        {
            tipoUser = "G";
        }
        else if (Regex.IsMatch(codigoUser.ToUpper(), patternA))
        {
            tipoUser = "A";
        }

        string nombreUser = txtNameUser.Text;
        string mensaje = "";

        if (Request.QueryString["idUsuario"] != null)
        {
            SqlDataReader dataObtenerID = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
            dataObtenerID.Read();
            string cadenaID = dataObtenerID["idInformacion"].ToString();
            string idUser = dataObtenerID["idUsuario"].ToString();

            if (Regex.IsMatch(idUser.ToUpper(), patternC))
            {
                tipoUser = "C";
            }
            else if (Regex.IsMatch(idUser.ToUpper(), patternG))
            {
                tipoUser = "G";
            }
            if (Usuario_Model.Modificar(new Usuario(Int32.Parse(cadenaID), tipoUser, name,apellido,dui,fechaNac,residencia,telefono,email), Request.QueryString["idUsuario"]))
                {
                    mensaje = "Materialize.toast('Usuario modificado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuarios.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error al modificar usuario', 2000)";
                }
            dataObtenerID.Close();
        }
        else
        {
            if (Usuario_Model.VerificarExistencia(codigoUser) == 0)
            {
                string cadenaID = "0";
                try
                {
                    if (Usuario_Model.Insertar(new Usuario(Int32.Parse(cadenaID),tipoUser, name, apellido, dui, fechaNac, residencia, telefono, email)))
                    {
                        if (Usuario_Model.Insertar(dui, email, tipoUser, codigoUser, nombreUser, GenerarContrasenna()))
                        {
                            mensaje = "Materialize.toast('Usuario ingresado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuarios.aspx'})";
                        }
                    }
                }
                catch (Exception E)
                {
                    mensaje = "Materialize.toast('Error al ingresar usuario', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Usuario ya existe', 2000)";
            }
        }
        
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        
    }
    protected string GenerarContrasenna()
    {
        Random rnd = new Random();
        string contrasenna = "";
        string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789abcdefghijklomnopqrstuvwxyz";
        for (int i = 0; i < 9; i++)
        {
            contrasenna += caracteres.Substring(rnd.Next(0, caracteres.Length - 1), 1);
        }
        return contrasenna;
    }
}