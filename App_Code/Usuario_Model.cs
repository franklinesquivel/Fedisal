using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario_Model
/// </summary>
public class Usuario_Model
{
    public Usuario_Model()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static bool Insertar(Usuario usuario)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO InformacionPersonal(nombres, apellidos, dui, fechaNacimiento, direccionResidencia, telefono, correoElectronico) VALUES(@nombre, @apellido, @dui, @fecha, @residencia, @telefono, @correo)");
        cmd.Parameters.Add("@nombre", SqlDbType.Char);
        cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
        cmd.Parameters.Add("@dui", SqlDbType.VarChar);
        cmd.Parameters.Add("@fecha", SqlDbType.Date);
        cmd.Parameters.Add("@residencia", SqlDbType.VarChar);
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar);
        cmd.Parameters.Add("@correo", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = usuario.Nombre;
        cmd.Parameters["@apellido"].Value = usuario.Apellido;
        cmd.Parameters["@dui"].Value = usuario.Dui;
        cmd.Parameters["@fecha"].Value = usuario.FechaNacimiento;
        cmd.Parameters["@residencia"].Value = usuario.Residencia;
        cmd.Parameters["@telefono"].Value = usuario.Telefono;
        cmd.Parameters["@correo"].Value = usuario.Correo;
        return DBConnection.ExecuteCommandIUD(cmd);
    }
    public static bool Insertar(Usuario usuario,string tipoUsuario,string idUsuario)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO InformacionPersonal(nombres, apellidos, dui, fechaNacimiento, direccionResidencia, telefono, correoElectronico) VALUES(@nombre, @apellido, @dui, @fecha, @residencia, @telefono, @correo)");
        cmd.Parameters.Add("@nombre", SqlDbType.Char);
        cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
        cmd.Parameters.Add("@dui", SqlDbType.VarChar);
        cmd.Parameters.Add("@fecha", SqlDbType.Date);
        cmd.Parameters.Add("@residencia", SqlDbType.VarChar);
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar);
        cmd.Parameters.Add("@correo", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = usuario.Nombre;
        cmd.Parameters["@apellido"].Value = usuario.Apellido;
        cmd.Parameters["@dui"].Value = usuario.Dui;
        cmd.Parameters["@fecha"].Value = usuario.FechaNacimiento;
        cmd.Parameters["@residencia"].Value = usuario.Residencia;
        cmd.Parameters["@telefono"].Value = usuario.Telefono;
        cmd.Parameters["@correo"].Value = usuario.Correo;
        SqlDataReader data = DBConnection.GetData("SELECT idInformacion FROM InformacionPersonal WHERE dui = '"+ usuario.Dui +"'");
        int idinfo = Convert.ToInt32(data["idInformacion"]);
        SqlCommand cmd2 = DBConnection.GetCommand("INSERT INTO Usuario()");
        return DBConnection.ExecuteCommandIUD(cmd);
    }
    public static bool Modificar(Usuario usuario,string idUsuario)
    {
        SqlDataReader dataID = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + idUsuario + "';");
        dataID.Read();
        string cadenaID = dataID["idInformacion"].ToString();

            SqlCommand cmd = DBConnection.GetCommand("UPDATE InformacionPersonal SET nombres = @nombre, apellidos = @apellido, dui = @dui, fechaNacimiento = @fecha, direccionResidencia = @residencia, telefono = @telefono , correoElectronico = @correo WHERE idInformacion = @idInfo");
            cmd.Parameters.Add("@nombre", SqlDbType.Char);
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
            cmd.Parameters.Add("@dui", SqlDbType.VarChar);
            cmd.Parameters.Add("@fecha", SqlDbType.Date);
            cmd.Parameters.Add("@residencia", SqlDbType.VarChar);
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar);
            cmd.Parameters.Add("@correo", SqlDbType.VarChar);
            cmd.Parameters.Add("@idInfo", SqlDbType.Int);


            cmd.Parameters["@nombre"].Value = usuario.Nombre;
            cmd.Parameters["@apellido"].Value = usuario.Apellido;
            cmd.Parameters["@dui"].Value = usuario.Dui;
            cmd.Parameters["@fecha"].Value = usuario.FechaNacimiento;
            cmd.Parameters["@residencia"].Value = usuario.Residencia;
            cmd.Parameters["@telefono"].Value = usuario.Telefono;
            cmd.Parameters["@correo"].Value = usuario.Correo;
            cmd.Parameters["@idInfo"].Value = cadenaID;
            DBConnection.ExecuteCommandIUD(cmd);

        
        SqlCommand cmd2 = DBConnection.GetCommand("UPDATE Usuario SET idTipoUsuario = @idTipo WHERE idInformacion = @idInformacion");
        cmd2.Parameters.Add("@idTipo", SqlDbType.VarChar);
        cmd2.Parameters.Add("@idInformacion", SqlDbType.Int);
        
        cmd2.Parameters["@idTipo"].Value = usuario.TipoUsuario;
        cmd2.Parameters["@idInformacion"].Value = cadenaID;
        dataID.Close();
        return DBConnection.ExecuteCommandIUD(cmd2);
    }
    public static int VerificarDui(string dui)
    {
        /* Descripción de método
           Al momento de registrar un usuario verifica si el dui ya existe 
        */
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM InformacionPersonal WHERE dui = @dui");
        cmd.Parameters.Add("@dui", SqlDbType.VarChar);

        cmd.Parameters["@dui"].Value = dui;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }
    public static Usuario ObtenerUsuario(string idUsuario,int idInformacion)
    {
        SqlDataReader data = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario INNER JOIN InformacionPersonal AS ip ON ip.idInformacion = u.idInformacion WHERE u.idUsuario = '" + idUsuario + "';");
        data.Read();
        Usuario _U = new Usuario(idInformacion,data["idTipoUsuario"].ToString(),data["nombres"].ToString(), data["apellidos"].ToString(), data["dui"].ToString(), DateTime.Parse(data["fechaNacimiento"].ToString()), data["direccionResidencia"].ToString(), data["telefono"].ToString(), data["correoElectronico"].ToString());
        data.Close();
        return _U;
    }

    public static int VerificarExistencia(int idInformacion)
    {
        /* Descripción de método
           Verifica si existe un registro con el id especificado
        */
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM InformacionPersonal WHERE idInformacion = @id");
        cmd.Parameters.Add("@id", SqlDbType.VarChar);

        cmd.Parameters["@id"].Value = idInformacion;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Login(string nombreUsuario, string contrasenna)
    {
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM Usuario WHERE idUsuario = @idUsuario and contrasenna = @contrasenna");
        cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar);
        cmd.Parameters.Add("@contrasenna", SqlDbType.VarChar);

        cmd.Parameters["@idUsuario"].Value = nombreUsuario;
        cmd.Parameters["@contrasenna"].Value = contrasenna;

        if (Int32.Parse(DBConnection.QueryScalar(cmd)) > 0)
        {
            SqlDataReader data = DBConnection.GetData("SELECT * FROM Usuario AS u INNER JOIN TipoUsuario AS tu ON tu.idTipoUsuario = u.idTipoUsuario WHERE u.idUsuario = '" + nombreUsuario + "' and u.contrasenna = '" + contrasenna + "';");
            data.Read();
            HttpContext.Current.Session["Logged"] = "true";
            HttpContext.Current.Session["ID"] = nombreUsuario;
            Sesion.SetearUsuario(data["descripcion"].ToString(), nombreUsuario, "Usuario", "idUsuario");
            data.Close();
            return true;
        }
        else
        {
            return false;
        }
    }
}