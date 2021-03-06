﻿using System;
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

    public static bool Insert(Desembolso _d)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO Desembolso(monto, fecha, idTipoDesembolso, idCiclo) VALUES(@monto, @fecha, @idTipo, @idBecario);");
        cmd.Parameters.Add("@monto", SqlDbType.Money);
        cmd.Parameters.Add("@fecha", SqlDbType.Date);
        cmd.Parameters.Add("@idTipo", SqlDbType.Int);
        cmd.Parameters.Add("@idBecario", SqlDbType.VarChar);

        cmd.Parameters["@monto"].Value = _d.Monto;
        cmd.Parameters["@fecha"].Value = _d.Fecha;
        cmd.Parameters["@idTipo"].Value = _d.IdTipoDesembolso;
        cmd.Parameters["@idBecario"].Value = _d.IdCiclo;
        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static double ObtenerSaldo(int idCiclo, int idTipo)
    {
        //Obtiene la suma de otos los desembolsos segun ciclo y tipo
        SqlCommand cmd = DBConnection.GetCommand("SELECT COALESCE( SUM(monto), 0) AS [Monto] FROM Desembolso WHERE idCiclo = @idCiclo AND idTipoDesembolso = @idDesembolso");
        cmd.Parameters.Add("@idCiclo", SqlDbType.Int);
        cmd.Parameters.Add("@idDesembolso", SqlDbType.Int);

        cmd.Parameters["@idCiclo"].Value = idCiclo;
        cmd.Parameters["@idDesembolso"].Value = idTipo;
        return Double.Parse(DBConnection.QueryScalar(cmd));

    }
}