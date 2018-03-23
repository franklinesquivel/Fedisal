using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Universidad_Model
/// </summary>
public class Universidad_Model
{
    public Universidad_Model()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static int VerificarExistencia(int id)
    { //Verifica la existencia por id
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM Universidad WHERE idUniversidad = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static int VerificarExistencia(string nombre)
    { //Verifica la existencia por nombre
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(LOWER(nombre)) FROM Universidad WHERE Nombre = LOWER(@nombre)");
        cmd.Parameters.Add("@nombre", SqlDbType.Int);

        cmd.Parameters["@nombre"].Value = nombre;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Insertar(Carrera _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO Universidad(nombre direccion, telefono) VALUES(@nombre, @direccion, @telefono)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar);
        cmd.Parameters.Add("@telefono", SqlDbType.Int);

        cmd.Parameters["@nombre"].Value = _c.Nombre;
        if (DBConnection.ExecuteCommandIUD(cmd)) //Registramos en tabla Carrera
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Universidad ObtenerUniversidad(int id)
    {//Obtiene los datos de la carrera segun id
        string sql = "SELECT * FROM Universidad WHERE idUniversidad = " + id + ";";
        SqlDataReader data = DBConnection.GetData(sql);
        data.Read();
         Universidad _c = new Universidad(Int32.Parse(data["idUniversidad"].ToString()), data["nombre"].ToString(), data["direccion"].ToString(), Int32.Parse(data["telefono"].ToString()));
        data.Close();
        return _c;
    }

    public static Boolean Modificar(Universidad _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE Universidad SET nombre = @nombre WHERE idUniversidad = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar);
        cmd.Parameters.Add("@telefono", SqlDbType.Int);

        cmd.Parameters["@id"].Value = _c.id;
        cmd.Parameters["@nombre"].Value = _c.nombre;
        cmd.Parameters["@direccion"].Value = _c.direccion;
        cmd.Parameters["@telefono"].Value = _c.telefono;    
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static Boolean Eliminar(int id)
    {
        SqlCommand cmd = DBConnection.GetCommand("DELETE FROM Universidad WHERE idUniversidad = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return DBConnection.ExecuteCommandIUD(cmd);
    }
}