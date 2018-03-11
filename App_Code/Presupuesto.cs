using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Presupuesto
/// </summary>
public class Presupuesto
{
    private int idPresupuesto;
    private double libro;
    private double colegiatura;
    private double manutencion;
    private double matricula;
    private double otros;
    private double trabajoGraduacion;
    private String idBecario;

    public int IdPresupuesto
    {
        get
        {
            return idPresupuesto;
        }

        set
        {
            idPresupuesto = value;
        }
    }

    public double Libro
    {
        get
        {
            return libro;
        }

        set
        {
            libro = value;
        }
    }

    public double Colegiatura
    {
        get
        {
            return colegiatura;
        }

        set
        {
            colegiatura = value;
        }
    }

    public double Manutencion
    {
        get
        {
            return manutencion;
        }

        set
        {
            manutencion = value;
        }
    }

    public double Matricula
    {
        get
        {
            return matricula;
        }

        set
        {
            matricula = value;
        }
    }

    public double Otros
    {
        get
        {
            return otros;
        }

        set
        {
            otros = value;
        }
    }

    public double TrabajoGraduacion
    {
        get
        {
            return trabajoGraduacion;
        }

        set
        {
            trabajoGraduacion = value;
        }
    }

    public String IdBecario
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

    public Presupuesto(double libro, double colegiatura, double manutencion, double matricula, double otros, double tg, String idBecario)
    {
        this.Libro = libro;
        this.Colegiatura = colegiatura;
        this.Manutencion = manutencion;
        this.Matricula = matricula;
        this.Otros = otros;
        this.TrabajoGraduacion = tg;
        this.IdBecario = idBecario;
    }
}