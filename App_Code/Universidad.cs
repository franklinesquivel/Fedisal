using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Universidad
/// </summary>
public class Universidad
{
    private int idUniversidad;
    private String nombre;
    private String direccion;
    private String telefono;

    public int IdUniversidad
    {
        get
        {
            return idUniversidad;
        }

        set
        {
            idUniversidad = value;
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

    public string Direccion
    {
        get
        {
            return direccion;
        }

        set
        {
            direccion = value;
        }
    }

    public string Telefono
    {
        get
        {
            return telefono;
        }

        set
        {
            telefono = value;
        }
    }

    public Universidad(int id, String nombre, String direccion, String telefono) {
        this.idUniversidad = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public Universidad(String nombre, String direccion, String telefono) {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}



