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

    public static bool Insertar(Universidad _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO Universidad(nombre, direccion, telefono) VALUES(@nombre, @direccion, @telefono)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar);
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = _c.Nombre;
        cmd.Parameters["@direccion"].Value = _c.Direccion;
        cmd.Parameters["@telefono"].Value = _c.Telefono;
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
        String sql = "SELECT * FROM Universidad WHERE idUniversidad = " + id + ";";
        SqlDataReader data = DBConnection.GetData(sql);
        
        if (data != null)
        {
            if (data.HasRows)
            {
                data.Read();
                Universidad _c = new Universidad(Int32.Parse(data["idUniversidad"].ToString()), data["nombre"].ToString(), data["direccion"].ToString(), data["telefono"].ToString());
                data.Close();
                return _c;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public static Boolean Modificar(Universidad _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE Universidad SET nombre = @nombre, direccion = @direccion, telefono = @telefono WHERE idUniversidad = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar);
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar);

        cmd.Parameters["@id"].Value = _c.IdUniversidad;
        cmd.Parameters["@nombre"].Value = _c.Nombre;
        cmd.Parameters["@direccion"].Value = _c.Direccion;
        cmd.Parameters["@telefono"].Value = _c.Telefono;    
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