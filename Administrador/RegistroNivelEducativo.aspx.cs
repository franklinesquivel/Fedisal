using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_RegistroNivelEducativo : System.Web.UI.Page
{
    private string idNuevoNivel; //Atributo que guarda el codigo generado al cargar la página
    private object resultCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerarCodigo();
            resultCode.InnerHtml = "<h5 class='center-align  deep-purple-text text-lighten-2'>Código: " + idNuevoNivel + "</h5>";
        }
    }

    protected void GenerarCodigo()
    {//Generamos un codigo aleatorio
        Random rnd = new Random();
        string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Cadena ocupada para generar un código aleatorio
        do
        {
            idNuevoNivel = "BE";
            for (int i = 0; i < 2; i++)
            {
                idNuevoNivel += letras.Substring(rnd.Next(0, letras.Length - 1), 1); //Guardamos la letra seleccionada
            }
        } while (NivelEducativo_Model.VerificarExistencia(idNuevoNivel) > 0);
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string mensaje;
            NivelEducativo nivel = new NivelEducativo(Int32.Parse(idNuevoNivel), txtName.Text, txtDescripcion.Text);
            if (NivelEducativo_Model.VerificarExistencia(nivel.idNivelEducativo) == 0) //Volvemos a verificar codigo
            {
                if (ProgramaBeca_Model.Insertar(nivel))
                {
                    mensaje = "Materialize.toast('Nivel registado exitosamente!', 2000, '', function(){ location.href = '/Administrador/RegistroNivelEducativo.aspx'})";
                }
                else
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }
            else
            {
                mensaje = "Materialize.toast('Código ya existe. Recargar e intentar', 2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }
    }
}