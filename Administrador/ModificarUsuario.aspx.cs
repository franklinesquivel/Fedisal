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
        if(!IsPostBack)
        {
            
            SqlDataReader data = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + Request.QueryString["idUsuario"] + "';");
            data.Read();

            txtNombre.Value = data["nombres"].ToString();
            txtApellido.Value = data["apellidos"].ToString();
            txtTel.Value = data["telefono"].ToString();
            txtFechaNac.Value = DateTime.Parse(data["fechaNacimiento"].ToString()).ToString("yyyy-MM-dd");
            txtEmail.Value = data["correoElectronico"].ToString();
            txtResidencia.Value = data["direccionResidencia"].ToString();
            data.Close();
        }
    }
}