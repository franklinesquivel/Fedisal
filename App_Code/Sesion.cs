using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Sesion
/// </summary>
public static class Sesion
{
    private static String tipo;
    private static String id;
    private static String tabla;
    private static String campoLlave;

    public static string Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }

    public static string Id
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

    public static string Tabla
    {
        get
        {
            return tabla;
        }

        set
        {
            tabla = value;
        }
    }

    public static string CampoLlave
    {
        get
        {
            return campoLlave;
        }

        set
        {
            campoLlave = value;
        }
    }

    public static void SetearUsuario(Usuario _u)
    {
        tipo = "Usuario";
        id = _u.IdUsuario.ToString();
        tabla = "Usuario";
        campoLlave = "idUsuario";
    }

    public static void SetearUsuario(Becario _u)
    {
        tipo = "Becario";
        id = _u.IdBecario;
        tabla = "Becario";
        campoLlave = "idBecario";
    }

    public static void VerificarUsuario(String _id)
    {

        SqlDataReader data = DBConnection.GetData("SELECT* FROM " + tabla + " AS tbl " + (tipo == "Becario" ? "" : "INNER JOIN TipoUsuario AS tu ON tbl.idTipoUsuario = tu.idTipoUsuario") + " WHERE tbl." + CampoLlave + " = '" + _id + "';");
        String path = HttpContext.Current.Request.Url.AbsolutePath;
        String accesandoA = path.Split('/')[0];

        if (data.HasRows)
        {
            if(tipo == "Becario" && accesandoA != Tipo)
            {
                HttpContext.Current.Response.Redirect("/Becario");
            }else
            {
                if(data["descripcion"].ToString() != accesandoA)
                {
                    HttpContext.Current.Response.Redirect("/" + data["descripcion"].ToString());
                }
            }
        }else
        {
            HttpContext.Current.Response.Redirect("/");
        }
    }
}