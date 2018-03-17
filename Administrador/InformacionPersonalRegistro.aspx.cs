using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformacionPersonalRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {//Validación fecha
        DateTime birthdate = DateTime.Parse(dtpBirthdate.Text, CultureInfo.InvariantCulture);
        DateTime fechaActual = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"), CultureInfo.InvariantCulture);
        bool response = true;
        if (birthdate >= fechaActual)
        {
            response = false;
        }
        args.IsValid = response;
    }

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {//Validación email
        bool response = false;
        try
        {
            MailAddress m = new MailAddress(args.Value.ToString().Trim());
            response = true;
        }
        catch (FormatException)
        {
            response = false;
        }
        args.IsValid = response;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DateTime birthdate = DateTime.Parse(dtpBirthdate.Text, CultureInfo.InvariantCulture);
            Usuario nuevoUsuario = new Usuario(txtName.Text.Trim(), txtLastName.Text.Trim(), txtDUI.Text, birthdate, txtResidence.Text.Trim(), txtTelephone.Text, txtEmail.Text);
            string mensaje;
            if (Usuario_Model.VerificarDui(nuevoUsuario.Dui) == 0)
            {//Verificamos que no exista el dui en la BDD
                if (Usuario_Model.Insertar(nuevoUsuario))
                {
                    mensaje = "Materialize.toast('Usuario registado exitosamente!', 2000, '', function(){ location.href = '/Administrador/InformacionPersonalRegistro.aspx'})";
                }else
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }else
            {
                mensaje = "Materialize.toast('DUI ya existe', 2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }
    }
}