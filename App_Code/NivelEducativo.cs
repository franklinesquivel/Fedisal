using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NivelEducativo
/// </summary>
public class NivelEducativo
{
    private int idNivelEducativo;
    private String nombre;
    private String descripcion;

    public int IdNivelEducativo
    {
        get
        {
            return idNivelEducativo;
        }

        set
        {
            idNivelEducativo = value;
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

    public NivelEducativo(int id, String Nombre, String descripcion) {
        this.idNivelEducativo = id;
        this.nombre = Nombre;
        this.descripcion = descripcion;
    }

    public NivelEducativo(String Nombre, String descripcion) {
        this.nombre = Nombre;
        this.descripcion = descripcion;
    }
}