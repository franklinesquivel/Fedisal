using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BecarioRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Cargamos la información en los dropdownlist
            DBConnection.fillCmb(ref ddlProgram, "SELECT * FROM ProgramaBecas", "nombre", "idPrograma");
            ddlProgram.Items.Insert(0, new ListItem("[Programa de Beca]", "0"));
            DBConnection.fillCmb(ref ddlUser, "SELECT * FROM InformacionPersonal", "dui", "idInformacion");
            ddlUser.Items.Insert(0, new ListItem("[DUI]", "0"));
            DBConnection.fillCmb(ref ddlUniversity, "SELECT * FROM Universidad", "nombre", "idUniversidad");
            ddlUniversity.Items.Insert(0, new ListItem("[Universidad]", "0"));
            DBConnection.fillCmb(ref ddlProfession, "SELECT * FROM Carrera", "nombre", "idCarrera");
            ddlProfession.Items.Insert(0, new ListItem("[Carrera]", "0"));
            DBConnection.fillCmb(ref ddlDegree, "SELECT * FROM NivelEducativo", "nombre", "idNivelEducativo");
            ddlDegree.Items.Insert(0, new ListItem("[Nivel Educativo]", "0"));
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {//Verifica que la fecha de inicio no sea mayor a la final
        DateTime fechaInicial = DateTime.Parse(dtpStart.Text, CultureInfo.InvariantCulture);
        DateTime fechaFinal = DateTime.Parse(dtpEnd.Text, CultureInfo.InvariantCulture);
        bool response = true;
        if (fechaInicial >= fechaFinal)
        {
            response = false;
        }
        args.IsValid = response;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {//Botón de registrar
        if (Page.IsValid)
        {
            string mensaje;
            if (Usuario_Model.VerificarExistencia(int.Parse(ddlUser.SelectedValue)) > 0)
            {//Verificamos si existe el usuario
                if (Becario_Model.VerificarExistencia(int.Parse(ddlUser.SelectedValue), ddlProgram.SelectedValue) == 0)
                {//Verificamos si existe el mismo idinformacion en el mismo programa
                    DateTime fechaInicial = DateTime.Parse(dtpStart.Text, CultureInfo.InvariantCulture);
                    DateTime fechaFinal = DateTime.Parse(dtpEnd.Text, CultureInfo.InvariantCulture);
                    Becario becario = new Becario(generarCodigoBecario(ddlProgram.SelectedValue), int.Parse(ddlUser.SelectedValue), ddlProgram.SelectedValue, int.Parse(ddlUniversity.SelectedValue), int.Parse(ddlProfession.SelectedValue), int.Parse(ddlDegree.SelectedValue), fechaInicial, fechaFinal, generarContrasenna());
                    if (Becario_Model.Insertar(becario))
                    {
                        mensaje = "Materialize.toast('Becario registrado con exito', 2000, '', function(){ location.href = 'BecarioRegistro.aspx'})";
                    }
                    else
                    {
                        mensaje = "Materialize.toast('Error :(', 2000)";
                    }
                } else
                {
                    mensaje = "Materialize.toast('El Usuario ya es parte del programa', 2000)";
                }
            }else
            {
                mensaje = "Materialize.toast('No existe un usuario con el dui seleccionado', 2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }//fin page.isValid
    }

    protected string generarCodigoBecario(string idPrograma)
    {
        string codigoBecario = idPrograma+DateTime.Now.Year.ToString(); //BBEAP2018
        //Se obtiene el numero de becarios en dicho programa y se aumenta en 1
        int numBecarios = Becario_Model.ObtenerNumBecarios(idPrograma);

        if (numBecarios > 0 && numBecarios < 10)
        {
            codigoBecario += "00"+(numBecarios+1);
        }else if (numBecarios >= 10 && numBecarios < 100)
        {
            codigoBecario += "0" + (numBecarios+1);
        }else if(numBecarios > 100)
        {
            codigoBecario += (numBecarios+1);
        }else if (numBecarios == 0)
        {
            codigoBecario += "001";
        }
        return codigoBecario;
    }

    protected string generarContrasenna()
    { //Generamos la contraseña
        Random rnd = new Random();
        string contrasenna = "";
        string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789abcdefghijklomnopqrstuvwxyz";
        for (int i = 0; i < 9; i++) //Generar contraseña de 8 digitos
        {
            contrasenna += caracteres.Substring(rnd.Next(0, caracteres.Length - 1), 1);
        }
        return contrasenna;
    }
}