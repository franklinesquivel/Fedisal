using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Ciclo_Model
/// </summary>
public class Ciclo_Model
{
    public Ciclo_Model()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static bool AprobarDesembolso(int id) {
        SqlCommand cmd = DBConnection.GetCommand("UPDATE Ciclo SET evidenciaNotas = @valor WHERE idCiclo = @id");
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters.Add("@valor", SqlDbType.Int);

        cmd.Parameters["@id"].Value = id;
        cmd.Parameters["@valor"].Value = 1;
        return DBConnection.ExecuteCommandIUD(cmd);
    }
}