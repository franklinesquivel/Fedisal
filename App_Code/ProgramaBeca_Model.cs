using System;
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

    public static int verificarCodigo(string idPrograma) 
    {
        /* Descripción de método
           Al momento de registrar un programa verifica si el codigo genrado automaticamente existe 
        */
        SqlCommand cmd = DBConnection.getCommand("SELECT COUNT(*) FROM ProgramaBecas WHERE idPrograma = @idPrograma");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);

        cmd.Parameters["@idPrograma"].Value = idPrograma;
        return Int32.Parse(DBConnection.queryScalar(cmd));
    }

    public static bool insertar(ProgramaBeca programa)
    {
        SqlCommand cmd = DBConnection.getCommand("INSERT INTO ProgramaBecas(idPrograma, nombre, descripcion) VALUES(@idPrograma, @nombre, @descripcion)");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);

        cmd.Parameters["@idPrograma"].Value = programa.IdPrograma;
        cmd.Parameters["@nombre"].Value = programa.Nombre;
        cmd.Parameters["@descripcion"].Value = programa.Descripcion;
        return DBConnection.executeCommandIUD(cmd);
    }
}