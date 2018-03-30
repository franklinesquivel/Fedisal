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
    private int idNota;
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

    public Notas(int idNota, string nombre, decimal nota, int idCiclo) {
        this.idNota = idNota;
        this.nota = nota;
        this.nombreMat = nombre;
        this.idCiclo = idCiclo;
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

    public int IdNota
    {
        get
        {
            return idNota;
        }

        set
        {
            idNota = value;
        }
    }
}