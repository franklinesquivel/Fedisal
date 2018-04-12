using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoIncidente_Model
/// </summary>
public class TipoIncidente_Model
{
    public TipoIncidente_Model()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static int VerificarExistencia(int id)
    { //Verifica la existencia por id
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM TipoIncidente WHERE idTipoIncidente = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static int VerificarExistencia(string nombre)
    { //Verifica la existencia por nombre
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(LOWER(nombre)) FROM TipoIncidente WHERE nombre = LOWER(@nombre)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = nombre;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Insertar(TipoIncidente _t)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO TipoIncidente(nombre, descripcion) VALUES(@nombre, @descripcion)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = _t.Nombre;
        cmd.Parameters["@descripcion"].Value = _t.Descripcion;
        if (DBConnection.ExecuteCommandIUD(cmd)) //Registramos en tabla Carrera
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static TipoIncidente ObtenerTipo(int id)
    {//Obtiene los datos de la carrera segun id
        string sql = "SELECT * FROM TipoIncidente WHERE idTipoIncidente = " + id + ";";
        SqlDataReader data = DBConnection.GetData(sql);
        data.Read();
        TipoIncidente _t = new TipoIncidente(Int32.Parse(data["idTipoIncidente"].ToString()), data["nombre"].ToString(), data["descripcion"].ToString());
        data.Close();
        return _t;
    }

    public static Boolean Modificar(TipoIncidente _t)
    {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE TipoIncidente SET nombre = @nombre, descripcion = @descripcion WHERE idTipoIncidente = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);

        cmd.Parameters["@id"].Value = _t.Id;
        cmd.Parameters["@nombre"].Value = _t.Nombre;
        cmd.Parameters["@descripcion"].Value = _t.Descripcion;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static Boolean Eliminar(int id)
    {
        SqlCommand cmd = DBConnection.GetCommand("DELETE FROM TipoIncidente WHERE idTipoIncidente = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return DBConnection.ExecuteCommandIUD(cmd);
    }
}