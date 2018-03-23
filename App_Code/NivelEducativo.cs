using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NivelEducativo
/// </summary>
public class NivelEducativo
{
    public int idNivelEducativo;
    public String nombre;
    public String descripcion;

    private int Id
    {
        get {
            return idNivelEducativo;
        }
        set {
            idNivelEducativo = value;
        }
    }
    private String Nombre {
        get {
            return nombre;
        }
        set {
            Nombre = value;
        }
    }
    private String Descripcion {
        get {
            return descripcion;
        }
        set {
            descripcion = value;
        }
    }

    public NivelEducativo(int id, String Nombre, String descripcion) {
        this.Id = id;
        this.Nombre = Nombre;
        this.Descripcion = descripcion;
    }
}