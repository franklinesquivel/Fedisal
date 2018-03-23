using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Universidad
/// </summary>
public class Universidad
{
    public int id;
    public string nombre;
    public string direccion;
    public int telefono;

    private int Id {
        get {
            return id;
        }
        set {
            id = value;
        }
    }

    private String Nombre {
        get {
            return nombre;
        }
        set {
            nombre = value;
        }
    }

    private String Direccion{
        get {
            return direccion;
        }
        set {
            direccion = value;
        }
    }

    private int Telefono {
        get {
            return telefono;
        }
        set {
            telefono = value;
        }
    }


    public Universidad(int id, string nombre, string direccion, int telefono) {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}



