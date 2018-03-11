using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Presupuesto_Model
/// </summary>
public class Presupuesto_Model
{
    public Presupuesto_Model()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static bool Insert(Presupuesto _p)
    {
        SqlCommand cmd = DBConnection.getCommand("INSERT INTO PresupuestoBecas(libro, colegiatura, manutencion, matricula, otros, trabajoGraduacion, idBecario) VALUES(@libro, @colegiatura, @manutencion, @matricula, @otros, @trabajoGraduacion, @idBecario);");
        cmd.Parameters.Add("@libro", SqlDbType.Money);
        cmd.Parameters.Add("@colegiatura", SqlDbType.Money);
        cmd.Parameters.Add("@manutencion", SqlDbType.Money);
        cmd.Parameters.Add("@matricula", SqlDbType.Money);
        cmd.Parameters.Add("@otros", SqlDbType.Money);
        cmd.Parameters.Add("@trabajoGraduacion", SqlDbType.Money);
        cmd.Parameters.Add("@idBecario", SqlDbType.VarChar);

        cmd.Parameters["@libro"].Value = _p.Libro;
        cmd.Parameters["@colegiatura"].Value = _p.Colegiatura;
        cmd.Parameters["@manutencion"].Value = _p.Manutencion;
        cmd.Parameters["@matricula"].Value = _p.Manutencion;
        cmd.Parameters["@otros"].Value = _p.Otros;
        cmd.Parameters["@trabajoGraduacion"].Value = _p.TrabajoGraduacion;
        cmd.Parameters["@idBecario"].Value = _p.IdBecario;

        return DBConnection.executeCommandIUD(cmd);
    }
}