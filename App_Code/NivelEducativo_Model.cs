using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for NivelEducativo_Model
/// </summary>
public class NivelEducativo_Model
{
    public NivelEducativo_Model()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static bool Insertar(NivelEducativo _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO NivelEducativo(nombre, descripcion) VALUES(@nombre, @descripcion)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = _c.Nombre;
        cmd.Parameters["@descripcion"].Value = _c.Descripcion;
        if (DBConnection.ExecuteCommandIUD(cmd)) //Registramos en tabla NivelEducativo
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static NivelEducativo ObtenerNivelEducativo(int id)
    {//Obtiene los datos de la carrera segun id
        string sql = "SELECT * FROM NivelEducativo WHERE idNivelEducativo = " + id + ";";
        SqlDataReader data = DBConnection.GetData(sql);
        if (data != null)
        {
            if (data.HasRows)
            {
                data.Read();
                NivelEducativo _c = new NivelEducativo(Int32.Parse(data["idNivelEducativo"].ToString()), data["nombre"].ToString(), data["descripcion"].ToString());
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

    public static Boolean Modificar(NivelEducativo _c)
    {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE NivelEducativo SET nombre = @nombre, descripcion = @d WHERE idNivelEducativo = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@d", SqlDbType.VarChar);
      

        cmd.Parameters["@id"].Value = _c.IdNivelEducativo;
        cmd.Parameters["@nombre"].Value = _c.Nombre;
        cmd.Parameters["@d"].Value = _c.Descripcion;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static Boolean Eliminar(int id)
    {
        SqlCommand cmd = DBConnection.GetCommand("DELETE FROM NivelEducativo WHERE idNivelEducativo = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static int VerificarExistencia(string nombre) {
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(LOWER(nombre)) FROM NivelEducativo WHERE nombre = LOWER(@nombre)");
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);

        cmd.Parameters["@nombre"].Value = nombre;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }
}