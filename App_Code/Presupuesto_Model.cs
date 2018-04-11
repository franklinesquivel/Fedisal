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
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO PresupuestoBecas(libro, colegiatura, manutencion, matricula, otros, trabajoGraduacion, idBecario) VALUES(@libro, @colegiatura, @manutencion, @matricula, @otros, @trabajoGraduacion, @idBecario);");
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

        return DBConnection.ExecuteCommandIUD(cmd);
    }

    public static Presupuesto Obetener(string idBecario) //Obtiene el presupuesto en base al idBecario
    {
        string sql = "SELECT libro, colegiatura, manutencion, matricula, otros, trabajoGraduacion FROM PresupuestoBecas WHERE idBecario= '"+ idBecario +"'";
        SqlDataReader reader = DBConnection.GetData(sql);
        reader.Read();
        Presupuesto presupuesto = new Presupuesto(Convert.ToDouble(reader.GetDecimal(0)), Convert.ToDouble(reader.GetDecimal(1)), Convert.ToDouble(reader.GetDecimal(2)), Convert.ToDouble(reader.GetDecimal(3)), Convert.ToDouble(reader.GetDecimal(4)), Convert.ToDouble(reader.GetDecimal(5)), idBecario);
        reader.Close();
        return presupuesto;
    }

    public static int VerificarExistencia(string idBecario) //Verifica que exista un presupuesto en dicho becario
    {
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM PresupuestoBecas WHERE idBecario= @idBecario");
        cmd.Parameters.Add("@idBecario", SqlDbType.NVarChar);

        cmd.Parameters["@idBecario"].Value = idBecario;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }
}