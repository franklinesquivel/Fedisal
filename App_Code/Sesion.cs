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

    public static void SetearUsuario(String _tipo, String _id, String _tabla, String _campoLlave)
    {
        tipo = _tipo;
        id = _id;
        tabla = _tabla;
        campoLlave = _campoLlave;
    }

    public static void VerificarUsuario(String _id)
    {
        if (Boolean.Parse(HttpContext.Current.Session["Logged"].ToString())){
            SqlDataReader data = DBConnection.GetData("SELECT* FROM " + tabla + " AS tbl " + (tipo == "Becario" ? "" : "INNER JOIN TipoUsuario AS tu ON tbl.idTipoUsuario = tu.idTipoUsuario") + " WHERE tbl." + CampoLlave + " = '" + _id + "';");
            String path = HttpContext.Current.Request.Url.AbsolutePath;
            String accesandoA = path.Split('/')[1];

            if (data != null)
            {
                if (data.HasRows)
                {
                    data.Read();
                    if (tipo == "Becario" && accesandoA != Tipo)
                    {
                        HttpContext.Current.Response.Redirect("/Becario");
                    }
                    else
                    {
                        if (data["descripcion"].ToString() != accesandoA)
                        {
                            HttpContext.Current.Response.Redirect("/" + data["descripcion"].ToString() + "/");
                        }
                    }
                }
                else
                {
                    if (accesandoA != "Login.aspx")
                    {
                        HttpContext.Current.Response.Redirect("/Login.aspx");
                    }
                }
            }
            else
            {
                if (accesandoA != "Login.aspx")
                {
                    HttpContext.Current.Response.Redirect("/Login.aspx");
                }
            }

        }
    }
}