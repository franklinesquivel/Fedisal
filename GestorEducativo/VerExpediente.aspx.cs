﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestorEducativo_VerExpediente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            //Verificar Existencia de becario
            try
            {
                if (Becario_Model.VerificarExistencia(Request.QueryString["id"]) > 0)
                {
                    //Recupreramos la informacion
                    RecuperarInformacion(Request.QueryString["id"]);
                }
                else
                {
                    Response.Redirect("/GestorEducativo/IncidentesRegistro.aspx");
                }
            }
                catch (Exception err)
            {
                Response.Redirect("/GestorEducativo/IncidentesRegistro.aspx");
            }
        }
        else
        {
            Response.Redirect("/GestorEducativo/IncidentesRegistro.aspx");
        }
    }

    private void RecuperarInformacion(string id) {
        //Consulta para obtener información del becario
        string sql = "SELECT CONCAT(I.apellidos, ', ', I.nombres) AS[Becario], N.nombre AS[Nivel], C.nombre AS[Carrera],"
                    + " U.nombre AS[Universidad], P.nombre AS[Programa],"
                    + " B.fechaInicio AS[InicioBeca], B.fechaFin AS[FinBeca] FROM Becario B"
                    + " INNER JOIN ProgramaBecas P ON B.idPrograma = P.idPrograma"
                    + " INNER JOIN Universidad U ON B.idUniversidad = U.idUniversidad"
                    + " INNER JOIN Carrera C ON B.idCarrera = C.idCarrera"
                    + " INNER JOIN NivelEducativo N ON B.idNivelEducativo = N.idNivelEducativo"
                    + " INNER JOIN InformacionPersonal I ON B.idInformacion = I.idInformacion"
                    + " WHERE B.idBecario = '" + id + "'";
        SqlDataReader reader = DBConnection.GetData(sql);
        reader.Read();
        nombreB.InnerHtml = "Nombre: " + reader["Becario"];
        nivelB.InnerHtml = "Nivel Educativo: " + reader["Nivel"];
        carreraB.InnerHtml = "Carrera: " + reader["Carrera"];
        universidadB.InnerHtml = "Universidad: " + reader["Universidad"];
        programaB.InnerHtml = "Programa de Beca: " + reader["Programa"];
        fechaInicioB.InnerHtml = "Inicio de Beca: " + String.Format("{0:yyyy/MM/dd}", reader["InicioBeca"]);
        fechaFinB.InnerHtml = "Fin de Beca: " + String.Format("{0:yyyy/MM/dd}", reader["FinBeca"]);
        reader.Close();

        //Obtenemos información y la ponemos en datagridview
        SqlDataSource1.SelectCommand = "SELECT anio AS[Anio], idCiclo AS [idCiclo], nCiclo AS [nCiclo], evidenciaNotas AS [Aprobado]"
            + " FROM Ciclo WHERE idBecario = '"+ id +"'; ";
        DGV.DataBind();
    }

    [System.Web.Services.WebMethod]
    public static Object VerNotasCiclo(int idCiclo)
    {
        List<Notas> notas = Notas_Model.ObtenerNotas(idCiclo);
        if (notas.Count > 0)
        {
            return notas;
        }
        else
        {
            return false;
        }
    }
}