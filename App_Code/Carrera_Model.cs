using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Carrera_Model
/// </summary>
public class Carrera_Model
{
    public Carrera_Model()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static int VerificarExistencia(int id) { //Verifica la existencia por id
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM Carrera WHERE idCarrera = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    public static int VerificarExistencia(string nombre)
    { //Verifica la existencia por nombre
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(LOWER(nombre)) FROM Carrera WHERE nombre = LOWER(@nombre)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = nombre;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Insertar(Carrera _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO Carrera(nombre) VALUES(@nombre)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
  
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

    public static Carrera ObtenerCarrera(int id)
    {//Obtiene los datos de la carrera segun id
        string sql = "SELECT * FROM Carrera WHERE idCarrera = " + id + ";";
        SqlDataReader data = DBConnection.GetData(sql);
        data.Read();
        Carrera _c = new Carrera(Int32.Parse(data["idCarrera"].ToString()), data["nombre"].ToString());
        data.Close();
        return _c;
    }

    public static Boolean Modificar(Carrera _c) {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE Carrera SET nombre = @nombre WHERE idCarrera = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);

        cmd.Parameters["@id"].Value = _c.Id;
        cmd.Parameters["@nombre"].Value = _c.Nombre;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static Boolean Eliminar(int id)
    {
        SqlCommand cmd = DBConnection.GetCommand("DELETE FROM Carrera WHERE idCarrera = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return DBConnection.ExecuteCommandIUD(cmd);
    }
}