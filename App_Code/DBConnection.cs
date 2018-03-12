using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de DbConnection
/// </summary>
public class DBConnection
{
    private static ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["Fedisal_CS"];
    private static string connectionString = mySetting.ConnectionString;
    private static SqlConnection connection;
    private static SqlCommand cmd;
    private static SqlDataReader dr;
    private static SqlDataAdapter da;

    public DBConnection()
    {

    }

    //ExecuteNonQuery, ExecuteReader, Execute Scalar

    public static bool QueryIUD(String query) //UPDATE, INSERT AND DELETE
    {
        bool response = false;
        try
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, connection);
            cmd.Connection.Open();
            response = (cmd.ExecuteNonQuery() > 0) ? true : false;
            cmd.Connection.Close();
            return response;
        }
        catch (Exception e)
        {
            return response;
        }
    }

    public static string QueryScalar(SqlCommand _cmd) //Devuelve la primera columna de la primera fila de una consulta
    {
        string response = "";
        try
        {
            _cmd.Connection.Open();
            response = _cmd.ExecuteScalar().ToString();
            _cmd.Connection.Close();
        }
        catch (Exception e)
        {
            response = "0";
        }

        return response;
    }

    public static SqlDataReader GetData(String sql)
    {
        try
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand(sql, connection);
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                return null;
            };
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return null;
        }
    }

    public static SqlCommand GetCommand(String query)
    {
        connection = new SqlConnection(connectionString);
        return new SqlCommand(query, connection);
    }

    public static bool ExecuteCommandIUD(SqlCommand _cmd)
    {
        bool response = false;
        _cmd.Connection.Open();
        response = (_cmd.ExecuteNonQuery() > 0) ? true : false;
        _cmd.Connection.Close();

        return response;
    }

    public static String ExecuteCommandScalar(SqlCommand _cmd)
    {
        String response = "0";
        _cmd.Connection.Open();
        response = _cmd.ExecuteScalar().ToString();
        _cmd.Connection.Close();

        return response;
    }

    public static void FillCmb(ref DropDownList cmb, String query, String text, String value)
    {
        using (connection = new SqlConnection(connectionString))
        {
            try
            {
                da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmb.DataSource = dt;
                cmb.DataTextField = text;
                cmb.DataValueField = value;
                cmb.DataBind();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}