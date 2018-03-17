using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Carrera
/// </summary>
public class Carrera
{
    private int id;
    private string nombre;
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }
    public Carrera(int id, string nombre)
    {
        this.id = id;
        this.nombre = nombre;
    }

    public Carrera(string nombre)
    {
        this.nombre = nombre;
    }
}