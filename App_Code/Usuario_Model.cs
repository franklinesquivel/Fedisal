using System;
using System.Collections.Generic;
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
}