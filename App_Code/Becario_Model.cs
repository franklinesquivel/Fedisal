using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Becario_Model
/// </summary>
public class Becario_Model
{
    public Becario_Model()
    {
    }

    public static int VerificarExistencia(int idInformacion, string idPrograma)
    {
        /* Descripción de método
           Verifica si existe un registro con el mismo dui en el mismo programa
        */
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM Becarios WHERE idInformacion = @idInformacion AND idPrograma = @idPrograma");
        cmd.Parameters.Add("@idInformacion", SqlDbType.VarChar);
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);

        cmd.Parameters["@idInformacion"].Value = idInformacion;
        cmd.Parameters["@idPrograma"].Value = idPrograma;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Insertar(Becario becario)
    {
        SqlCommand cmd = DBConnection.GetCommand("INSERT INTO Becarios(idBecario, fechaInicio, fechaFin, idInformacion, idPrograma, idUniversidad, idCarrera, idNivelEducativo, contrasenna) VALUES(@id, @fechaInicio, @fechaFin, @informacion, @programa, @universidad, @carrera, @nivel, @contra)");
        cmd.Parameters.Add("@id", SqlDbType.VarChar);
        cmd.Parameters.Add("@fechaInicio", SqlDbType.Date);
        cmd.Parameters.Add("@fechaFin", SqlDbType.Date);
        cmd.Parameters.Add("@informacion", SqlDbType.Int);
        cmd.Parameters.Add("@programa", SqlDbType.Char);
        cmd.Parameters.Add("@universidad", SqlDbType.Int);
        cmd.Parameters.Add("@carrera", SqlDbType.Int);
        cmd.Parameters.Add("@nivel", SqlDbType.Int);
        cmd.Parameters.Add("@contra", SqlDbType.VarChar);

        cmd.Parameters["@id"].Value = becario.IdBecario;
        cmd.Parameters["@fechaInicio"].Value = becario.FechaInicio;
        cmd.Parameters["@fechaFin"].Value = becario.FechaFin;
        cmd.Parameters["@informacion"].Value = becario.IdInformacion;
        cmd.Parameters["@programa"].Value = becario.IdProgramaBeca;
        cmd.Parameters["@universidad"].Value = becario.IdUniversidad;
        cmd.Parameters["@carrera"].Value = becario.IdCarrera;
        cmd.Parameters["@nivel"].Value = becario.IdNivelEducativo;
        cmd.Parameters["@contra"].Value = becario.Contrasenna;
        if (DBConnection.ExecuteCommandIUD(cmd)) //Registramos en tabla Becario
        {//Mandamos correo
            return Correo.EnviarCorreoBecario(becario);
        }else
        {
            return false;
        }
    }

    public static int ObtenerNumBecarios(string idPrograma)
    {
        /* Descripción de método
           Obtiene le numero de becarios ingresados en dicho programa
        */
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM Becarios WHERE idPrograma = @idPrograma");
        cmd.Parameters.Add("@idPrograma", SqlDbType.Char);

        cmd.Parameters["@idPrograma"].Value = idPrograma;
        return Int32.Parse(DBConnection.QueryScalar(cmd));
    }

    public static bool Login(string nombreUsuario, string contrasenna)
    {
        /* Descripción de método
           Es llamado en el login y verifica si el becario existe
        */
        SqlCommand cmd = DBConnection.GetCommand("SELECT COUNT(*) FROM Becarios WHERE idBecario = @idBecario and contrasenna = @contrasenna");
        cmd.Parameters.Add("@idBecario", SqlDbType.VarChar);
        cmd.Parameters.Add("@contrasenna", SqlDbType.VarChar);

        cmd.Parameters["@idBecario"].Value = nombreUsuario;
        cmd.Parameters["@contrasenna"].Value = contrasenna;
        return (Int32.Parse(DBConnection.QueryScalar(cmd)) > 0 ? true : false);
    }
}