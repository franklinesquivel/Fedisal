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
    private int idTipoIncidente;
    private string idBecario;

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

}