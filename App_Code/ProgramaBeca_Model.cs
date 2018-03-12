using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProgramaBeca_Model
/// </summary>
public class ProgramaBeca_Model
{
    public ProgramaBeca_Model()
    {

    }

    public static int VerificarCodigo(string idPrograma) 
    {
        /* Descripción de método
           Al momento de registrar un programa verifica si el codigo genrado automaticamente existe 
        */
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM ProgramaBecas WHERE idPrograma = @idPrograma");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);

        cmd.Parameters["@idPrograma"].Value = idPrograma;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Insertar(ProgramaBeca programa)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO ProgramaBecas(idPrograma, nombre, descripcion) VALUES(@idPrograma, @nombre, @descripcion)");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);

        cmd.Parameters["@idPrograma"].Value = programa.IdPrograma;
        cmd.Parameters["@nombre"].Value = programa.Nombre;
        cmd.Parameters["@descripcion"].Value = programa.Descripcion;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static object Obtener()
    {
        string sql = "SELECT P.idPrograma, P.nombre, P.descripcion, COUNT(B.idBecario) AS [NumBecarios] FROM ProgramaBecas P LEFT JOIN Becario B ON B.idPrograma=P.idPrograma  GROUP BY P.idPrograma, P.descripcion, P.nombre UNION SELECT P.idPrograma, P.nombre, P.descripcion, COUNT(B.idBecario) FROM ProgramaBecas P RIGHT  JOIN Becario B ON B.idPrograma=P.idPrograma  GROUP BY P.idPrograma, P.descripcion, P.nombre;";
        SqlDataReader data = DBConnection.GetData(sql);
        ArrayList programa = new ArrayList();
        while (data.Read())
        {
            ProgramaBeca nuevoPrograma = new ProgramaBeca(data["idPrograma"].ToString(), data["nombre"].ToString(), data["descripcion"].ToString());
            programa.Add(nuevoPrograma.DevolverDatos(Int32.Parse(data["NumBecarios"].ToString())));
        }
        return programa;
    }

    public static ProgramaBeca Obtener(string idPrograma)
    {
        string sql = "SELECT * FROM ProgramaBecas WHERE idPrograma = '"+ idPrograma +"';";
        SqlDataReader data = DBConnection.GetData(sql);
        data.Read();
        ProgramaBeca programa = new ProgramaBeca(data["idPrograma"].ToString(), data["nombre"].ToString(), data["descripcion"].ToString());
        data.Close();
        return programa;
    }

    public static bool Modificar(ProgramaBeca programa)
    {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE ProgramaBecas SET nombre = @nombre, descripcion = @descripcion WHERE idPrograma = @idPrograma");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);

        cmd.Parameters["@idPrograma"].Value = programa.IdPrograma;
        cmd.Parameters["@nombre"].Value = programa.Nombre;
        cmd.Parameters["@descripcion"].Value = programa.Descripcion;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static bool Eliminar(string idPrograma)
    {
        SqlCommand cmd = DBConnection.GetCommand("DELETE FROM ProgramaBecas WHERE idPrograma = @idPrograma");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);

        cmd.Parameters["@idPrograma"].Value = idPrograma;
        return DBConnection.ExecuteCommandIUD(cmd);
    }
}