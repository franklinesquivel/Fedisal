using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
    private String idUsuario;
    private string nombre;
    private int idInfo;
    private string apellido;
    private string dui;
    private DateTime fechaNacimiento;
    private string residencia;
    private string telefono;
    private string correo;
    private string tipoUsuario;

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

    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }

    public string Dui
    {
        get
        {
            return dui;
        }

        set
        {
            dui = value;
        }
    }

    public DateTime FechaNacimiento
    {
        get
        {
            return fechaNacimiento;
        }

        set
        {
            fechaNacimiento = value;
        }
    }

    public string Residencia
    {
        get
        {
            return residencia;
        }

        set
        {
            residencia = value;
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

    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }

    public string TipoUsuario
    {
        get
        {
            return tipoUsuario;
        }

        set
        {
            tipoUsuario = value;
        }
    }

    public int IdInfo
    {
        get
        {
            return idInfo;
        }

        set
        {
            idInfo = value;
        }
    }

    public string IdUsuario
    {
        get
        {
            return idUsuario;
        }

        set
        {
            idUsuario = value;
        }
    }

    public Usuario(string nombre, string apellido, string dui, DateTime fechaNacimiento, string residencia, string telefono, string correo)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.dui = dui;
        this.fechaNacimiento = fechaNacimiento;
        this.residencia = residencia;
        this.telefono = telefono;
        this.correo = correo;
    }
    public Usuario(int idIn,string tipoUser,string nombre, string apellido, string dui, DateTime fechaNacimiento, string residencia, string telefono, string correo)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.dui = dui;
        this.fechaNacimiento = fechaNacimiento;
        this.residencia = residencia;
        this.telefono = telefono;
        this.correo = correo;
        this.tipoUsuario = tipoUser;
        this.idInfo = idIn;
    }
}