﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contador_ControlBecarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string filtro = "";
        try
        {
            if (int.Parse(cmbBuscador.SelectedValue) == 0)
            {
                filtro = "nombres";
            }
            else if (int.Parse(cmbBuscador.SelectedValue) == 1)
            {
                filtro = "apellidos";
            }
            else if (int.Parse(cmbBuscador.SelectedValue) == 2)
            {
                filtro = "PB.nombre";
            }
            else if (int.Parse(cmbBuscador.SelectedValue) == 3)
            {
                filtro = "idBecario";
            }
            //if () { 
            SqlDataSource1.SelectCommand = "SELECT C.idCiclo, C.anio, nCiclo, INF.nombres, INF.apellidos, PB.nombre AS [programa], B.idBecario FROM Becario B "
                + " INNER JOIN Ciclo C ON B.idBecario = C.idBecario"
                + " INNER JOIN InformacionPersonal INF ON B.idInformacion = INF.idInformacion"
                + " INNER JOIN ProgramaBecas PB ON B.idPrograma = PB.idPrograma WHERE C.evidenciaNotas = 1 AND C.bloqueado = 0 AND " + filtro +" LIKE '%"+ txtBuscar.Text +"%' ORDER BY C.nCiclo DESC; ";
            DGV.DataBind();
        }
        catch (Exception err)
        {
            SqlDataSource1.SelectCommand = "SELECT C.idCiclo, C.anio, nCiclo, INF.nombres, INF.apellidos, PB.nombre AS [programa], B.idBecario FROM Becario B" 
                +" INNER JOIN Ciclo C ON B.idBecario = C.idBecario"
                +" INNER JOIN InformacionPersonal INF ON B.idInformacion = INF.idInformacion"
                +" INNER JOIN ProgramaBecas PB ON B.idPrograma = PB.idPrograma WHERE C.evidenciaNotas = 1 AND C.bloqueado = 0 ORDER BY C.nCiclo DESC; ";
            DGV.DataBind();
        }
    }

    [System.Web.Services.WebMethod]
    public static object BloquearCiclo(string idCiclo)
    {
        try
        {
            return Ciclo_Model.BloquearDesembolso(Int32.Parse(idCiclo.ToString()));
        }
        catch (Exception e)
        {
            return false;
        }
    }
}