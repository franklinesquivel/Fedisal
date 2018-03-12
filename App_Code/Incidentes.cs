using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Diagnostics;

/// <summary>
/// Descripción breve de Incidentes
/// </summary>
public class Incidentes
{
    private static string connectionString = mySetting.ConnectionString;
    private int idTipoIncidente;
    private string idBecario;
    private static ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["Fedisal_CS"];
    

    public string IdBecario
    {
        get
        {
            return idBecario;
        }

        set
        {
            idBecario = value;
        }
    }

    public int IdTipoIncidente
    {
        get
        {
            return idTipoIncidente;
        }

        set
        {
            idTipoIncidente = value;
        }
    }

    public Incidentes(string idBecario, int idTipoIncidente)
    {
        this.idBecario = idBecario;
        this.idTipoIncidente = idTipoIncidente;
    }

    public static bool InsertarIncidente(Incidentes inci)
    {
        SqlCommand comando = DBConnection.GetCommand("INSERT INTO BitacoraIncidentes(idTipoIncidente,idBecario) VALUES(@idTipo,@idBeca)");
        comando.Parameters.Add("@idTipo", SqlDbType.Int);
        comando.Parameters.Add("@idBeca", SqlDbType.VarChar);

        comando.Parameters["@idTipo"].Value = inci.idBecario;
        comando.Parameters["@idBeca"].Value = inci.idTipoIncidente;

        if (DBConnection.ExecuteCommandIUD(comando))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}