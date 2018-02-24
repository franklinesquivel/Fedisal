using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Desembolso
/// </summary>
public class Desembolso
{
    private int idDesembolso;
    private double monto;
    private String fecha;
    private int idTipoDesembolso;
    private String idBecario;

    public int IdDesembolso
    {
        get
        {
            return idDesembolso;
        }

        set
        {
            idDesembolso = value;
        }
    }

    public double Monto
    {
        get
        {
            return monto;
        }

        set
        {
            monto = value;
        }
    }

    public string Fecha
    {
        get
        {
            return fecha;
        }

        set
        {
            fecha = value;
        }
    }

    public int IdTipoDesembolso
    {
        get
        {
            return idTipoDesembolso;
        }

        set
        {
            idTipoDesembolso = value;
        }
    }

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

    public Desembolso(int id, double monto, String fecha, int idTipo, String idBecario)
    {
        this.idDesembolso = id;
        this.monto = monto;
        this.fecha = fecha;
        this.idTipoDesembolso = idTipo;
        this.idBecario = idBecario;
    }


}