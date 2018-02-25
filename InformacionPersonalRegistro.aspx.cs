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

    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {//Validación fecha
        DateTime birthdate = DateTime.Parse(dtpBirthdate.Text, CultureInfo.InvariantCulture);
        DateTime fechaActual = Convert.ToDateTime(DateTime.Now.ToString("yyyy-mm-dd"));
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
}