﻿using System;
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
                    Menu.Titulo = "Modificar Usuario";
                    DBConnection.FillCmb(ref ddlTipoUsuario, "SELECT * FROM TipoUsuario WHERE descripcion = 'Contador' OR descripcion = 'GestorEducativo'", "descripcion", "idTipoUsuario");
                    SqlDataReader dataDDL = DBConnection.GetData("SELECT idTipoUsuario FROM Usuario WHERE idUsuario = '" + Request.QueryString["idUsuario"] + "'");
                    dataDDL.Read();
                    ddlTipoUsuario.Enabled = false;
                    string ddlvalue = dataDDL["idTipoUsuario"].ToString();
                    ddlTipoUsuario.SelectedValue = ddlvalue;
                    idUsuario.Value = Request.QueryString["idUsuario"];
                    dataDDL.Close();
                }
            }else
            {
                Response.Redirect("GestionUsuarios.aspx");
            }
        }
        else
        {
            if (!Page.IsPostBack)
            {
                btnUsuarios.Text = "Registrar";
                DBConnection.FillCmb(ref ddlTipoUsuario, "SELECT * FROM TipoUsuario WHERE descripcion = 'Contador' OR descripcion = 'GestorEducativo'", "descripcion", "idTipoUsuario");
                ddlTipoUsuario.DataBind();
                ddlTipoUsuario.Enabled = true;
            }
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
        string name = txtNombre.Value;
        string apellido = txtApellido.Value;
        string telefono = txtTel.Value;
        string dui = txtDui.Value;
        string email = txtEmail.Value;
        DateTime fechaNac = DateTime.Parse(txtFechaNac.Value);
        string residencia = txtResidencia.Value;
        string tipoUser = "";
        string nombreUser = "";
        string mensaje = "";
        string codigoUser = Request.QueryString["idUsuario"];

        if (Request.QueryString["idUsuario"] != null)
        {
            SqlDataReader dataObtenerID = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
            dataObtenerID.Read();
            string cadenaID = dataObtenerID["idInformacion"].ToString();
            string idUser = dataObtenerID["idUsuario"].ToString();
            tipoUser = ddlTipoUsuario.SelectedValue.ToString();
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
            if (Usuario_Model.verificarCorreo(email))
            {
                if (Usuario_Model.VerificarExistencia(codigoUser) == 0)
                {
                    try
                    {
                        string codiGen = "";
                        codigoUser = ddlTipoUsuario.SelectedItem.Value;
                        if (codigoUser == "C") { codiGen = Usuario_Model.genCodigo("Contador"); }
                        else if (codigoUser == "G") { codiGen = Usuario_Model.genCodigo("GestorEducativo"); }
                        if (Usuario_Model.Insertar(new Usuario(0, codiGen, name, apellido, dui, fechaNac, residencia, telefono, email)))
                        {
                            string contra = GenerarContrasenna();
                            if (Usuario_Model.Insertar(dui, email, codigoUser, codiGen, nombreUser, contra))
                            {
                                SqlDataReader reader = DBConnection.GetData("SELECT idInformacion FROM InformacionPersonal WHERE correoElectronico = '"+ email+"'");
                                reader.Read();
                                int id = Convert.ToInt32(reader["idInformacion"].ToString());
                                reader.Close();
                                if (Correo.EnviarCorreoUsuario(new Usuario(email, codiGen, contra, id))) {
                                    mensaje = "Materialize.toast('Usuario ingresado con exito', 1000, '', function(){ location.href = '/Administrador/GestionUsuarios.aspx'})";
                                }
                                else {
                                    mensaje = "Materialize.toast('Error al ingresar usuario', 2000)";
                                }
                                
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
            else {
                mensaje = "Materialize.toast('Usuario ya existe con ese correo', 2000)";
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