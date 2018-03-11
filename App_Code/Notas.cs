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
/// Descripción breve de Notas
/// </summary>
public class Notas
{
    private string nombreMat;
    private decimal nota;
    private byte tercioSuperior;
    private int idCiclo;
    private static ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["Fedisal_CS"];
    private static string connectionString = mySetting.ConnectionString;

    public Notas(string NombreMateria,decimal nota, byte tercioSuperior,int ideCiclo)
    {
        this.nombreMat = NombreMateria;
        this.nota = nota;
        this.tercioSuperior = tercioSuperior;
        this.idCiclo = ideCiclo;
    }
    public bool Insertar(Notas nota) {
        SqlCommand comando = DBConnection.GetCommand("INSERT INTO Nota(nombreMateria,nota,CumplioTercio,idCiclo) VALUES(@nombreMateria,@nota,@tercioSuperior,@idCiclo)");
        comando.Parameters.Add("@nombreMateria", SqlDbType.VarChar);
        comando.Parameters.Add("@nota", SqlDbType.Decimal);
        comando.Parameters.Add("@tercioSuperior", SqlDbType.Bit);
        comando.Parameters.Add("@idCiclo", SqlDbType.Int);

        comando.Parameters["@nombreMateria"].Value = nota.NombreMat;
        comando.Parameters["@nota"].Value = nota.Nota;
        comando.Parameters["@tercioSuperior"].Value = nota.TercioSuperior;
        comando.Parameters["@idCiclo"].Value = nota.IdCiclo;
        if (DBConnection.ExecuteCommandIUD(comando))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public byte TercioSuperior
    {
        get
        {
            return tercioSuperior;
        }

        set
        {
            tercioSuperior = value;
        }
    }

    public int IdCiclo
    {
        get
        {
            return idCiclo;
        }

        set
        {
            idCiclo = value;
        }
    }

    public decimal Nota
    {
        get
        {
            return nota;
        }

        set
        {
            nota = value;
        }
    }

    public string NombreMat
    {
        get
        {
            return nombreMat;
        }

        set
        {
            nombreMat = value;
        }
    }
}