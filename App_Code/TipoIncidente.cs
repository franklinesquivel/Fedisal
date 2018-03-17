using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoIncidente
/// </summary>
public class TipoIncidente
{
    private int id;
    private string nombre;
    private string descripcion;

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

    public string Descripcion
    {
        get
        {
            return descripcion;
        }

        set
        {
            descripcion = value;
        }
    }

    public TipoIncidente(int id, string nombre, string descripcion)
    {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }

    public TipoIncidente(string nombre, string descripcion) {
        this.nombre = nombre;
        this.descripcion = descripcion;
    }
}