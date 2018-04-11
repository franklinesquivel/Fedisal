using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestorEducativo_AprobarDesembolso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {//Proceso para buscar
        string filtro = "";

        try {
            if (cmbBuscador.SelectedValue.Equals("nombre"))
            {
                filtro = "I.nombres";
            }
            else if (cmbBuscador.SelectedValue.Equals("apellido"))
            {
                filtro = "I.apellidos";
            }
            else if (cmbBuscador.SelectedValue.Equals("programa"))
            {
                filtro = "P.nombre";
            }
            else if (cmbBuscador.SelectedValue.Equals("codigo"))
            {
                filtro = "B.idBecario";
            }
            //if () { 
            SqlDataSource1.SelectCommand = "SELECT C.idCiclo, C.anio, nCiclo, CONCAT(I.nombres, ' ', I.apellidos) AS [NombreBecario], P.nombre AS [Programa],"
                + " B.idBecario AS[CodigoB] FROM Ciclo C"
                + " INNER JOIN Becario B ON C.idBecario = B.idBecario"
                + " INNER JOIN ProgramaBecas P ON B.idPrograma = P.idPrograma"
                + " INNER JOIN InformacionPersonal I ON B.idInformacion = I.idInformacion"
                + " WHERE C.evidenciaNotas = 0 AND " + filtro + " LIKE '%" + txtBuscar.Text + "%' "
                + " ORDER BY C.anio, C.nCiclo, [NombreBecario]";
            DGV.DataBind();
        }
        catch (Exception err) {
            SqlDataSource1.SelectCommand = "SELECT C.idCiclo, C.anio, nCiclo, CONCAT(I.nombres, ' ', I.apellidos) AS[NombreBecario]," 
                +" P.nombre AS[Programa], B.idBecario AS[CodigoB] FROM Ciclo C"
                +" INNER JOIN Becario B ON C.idBecario = B.idBecario"
                +" INNER JOIN ProgramaBecas P ON B.idPrograma = P.idPrograma"
                +" INNER JOIN InformacionPersonal I ON B.idInformacion = I.idInformacion"
                +" WHERE C.evidenciaNotas = 0 ORDER BY C.anio, C.nCiclo, [NombreBecario]";
            DGV.DataBind();
        }
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
    [System.Web.Services.WebMethod]
    public static bool AprobarDesembolso(int idCiclo)
    {
        return Ciclo_Model.AprobarDesembolso(idCiclo);
    }
}