using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de Correo
/// </summary>
public class Correo
{
    public Correo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static bool EnviarCorreoBecario(Becario becario)
    {
        bool response = true;
        //Obtener correo, contraseña y usuario
        SqlDataReader reader = DBConnection.GetData("SELECT correoElectronico FROM InformacionPersonal WHERE idInformacion = "+ becario.IdInformacion +"");
        reader.Read();

        //Configuración del mensaje
        MailMessage mensaje = new MailMessage();
        mensaje.From = new MailAddress("ezic2017@gmail.com");
        mensaje.Subject = "FEDISAL - Becario";
        mensaje.IsBodyHtml = true;
        mensaje.Body = "";
        mensaje.Body += "<b>Usuario: </b>"+becario.IdBecario;
        mensaje.Body += "<br><b>Contraseña: </b>" + becario.Contrasenna;
        mensaje.BodyEncoding = Encoding.UTF8;
        mensaje.To.Add((string)reader[0]);

        //Configuración SMTPT
        SmtpClient clienteSMTP = new SmtpClient();
        clienteSMTP.Credentials = new NetworkCredential("", ""); //Correo y contraseña del emisor
        clienteSMTP.Port = 587;
        clienteSMTP.Host = "smtp.gmail.com";
        clienteSMTP.EnableSsl = true;
        try
        {
            clienteSMTP.Send(mensaje);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            response = false;
        }
        return response;
    }
}