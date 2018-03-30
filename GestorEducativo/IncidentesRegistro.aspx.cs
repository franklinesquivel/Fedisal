﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncidentesRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DBConnection.FillCmb(ref ddlIncidentes, "SELECT * FROM TipoIncidente", "nombre", "idTipoIncidente");
            ddlIncidentes.Items.Insert(0, new ListItem("[Incidentes]", "0"));
        }
    }
    [System.Web.Services.WebMethod]
    public static Boolean InsertarIncidente(int idTipo, string idBecario)
    {
        Incidentes incidente = new Incidentes(idBecario, idTipo);
        SqlCommand comando = DBConnection.GetCommand("INSERT INTO BitacoraIncidentes(idTipoIncidente,idBecario) VALUES(@idTipo,@idBeca)");
        comando.Parameters.Add("@idTipo", SqlDbType.Int);
        comando.Parameters.Add("@idBeca", SqlDbType.VarChar);

        comando.Parameters["@idTipo"].Value = incidente.IdTipoIncidente;
        comando.Parameters["@idBeca"].Value = incidente.IdBecario;
        if (DBConnection.ExecuteCommandIUD(comando))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "SELECT InformacionPersonal.nombres, InformacionPersonal.apellidos, ProgramaBecas.nombre, Becario.idBecario FROM Becario INNER JOIN InformacionPersonal ON Becario.idInformacion = InformacionPersonal.idInformacion INNER JOIN ProgramaBecas ON Becario.idPrograma = ProgramaBecas.idPrograma WHERE "+ cmbBuscador.SelectedValue +" LIKE '%"+ txtBuscar.Text +"%'";
        DGV.DataBind();
    }
}