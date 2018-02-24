using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProgramaBeca
/// </summary>
public class ProgramaBeca
{
    private string idPrograma;
    private string nombre;
    private string descripcion;

    public string IdPrograma
    {
        get
        {
            return idPrograma;
        }

        set
        {
            idPrograma = value;
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

    public ProgramaBeca(string idPrograma, string nombre, string descripcion)
    {
        this.IdPrograma = idPrograma;
        this.Nombre = nombre;
        this.Descripcion = descripcion;
    }
}