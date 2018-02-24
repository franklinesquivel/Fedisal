using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Desembolso_Model
/// </summary>
public class Desembolso_Model
{
    public Desembolso_Model()
    {

    }

    public static bool insert(Desembolso _d)
    {
        SqlCommand cmd = DBConnection.getCommand("INSERT INTO Desembolso(monto, fecha, idTipoDesembolso, idBecario) VALUES(@monto, @fecha, @idTipo, @idBecario);");
        cmd.Parameters.Add("@monto", SqlDbType.Money);
        cmd.Parameters.Add("@fecha", SqlDbType.Date);
        cmd.Parameters.Add("@idTipo", SqlDbType.Int);
        cmd.Parameters.Add("@idBecario", SqlDbType.VarChar);

        cmd.Parameters["@monto"].Value = _d.Monto;
        cmd.Parameters["@fecha"].Value = _d.Fecha;
        cmd.Parameters["@idTipo"].Value = _d.IdTipoDesembolso;
        cmd.Parameters["@idBecario"].Value = _d.IdBecario;

        return DBConnection.executeCommandIUD(cmd);
    }
}