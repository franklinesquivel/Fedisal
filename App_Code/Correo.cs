﻿using System;
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
    static String hostMail = "";
    static String hostPass = "";

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
        mensaje.From = new MailAddress("");//AÑADIR
        mensaje.Subject = "FEDISAL - Becario";
        mensaje.IsBodyHtml = true;
        mensaje.Body = "";
        mensaje.Body += "<b>Usuario: </b>"+becario.IdBecario;
        mensaje.Body += "<br><b>Contraseña: </b>" + becario.Contrasenna;
        mensaje.BodyEncoding = Encoding.UTF8;
        string correo = (string)reader[0];
        mensaje.To.Add(correo);
        reader.Close();

        //Configuración SMTPT
        SmtpClient clienteSMTP = new SmtpClient();
        clienteSMTP.Credentials = new NetworkCredential("", ""); //AÑADIR
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
    public static bool EnviarCorreoUsuario(Usuario usuario)
    {
        bool response = true;
        //Obtener correo, contraseña y usuario
        SqlDataReader reader = DBConnection.GetData("SELECT correoElectronico FROM InformacionPersonal WHERE idInformacion = " + usuario.IdInfo + "");
        reader.Read();

        //Configuración del mensaje
        MailMessage mensaje = new MailMessage();
        mensaje.From = new MailAddress("");//AÑADIR
        mensaje.Subject = "FEDISAL - Nuevo Usuario";
        mensaje.IsBodyHtml = true;
        mensaje.Body = "";
        mensaje.Body += "<b>Usuario: </b>" + usuario.Nombre;
        mensaje.Body += "<br><b>Contraseña: </b>" + usuario.Contrasenna;
        mensaje.BodyEncoding = Encoding.UTF8;
        mensaje.To.Add((string)reader[0]);
        reader.Close();

        //Configuración SMTPT
        SmtpClient clienteSMTP = new SmtpClient();
        clienteSMTP.Credentials = new NetworkCredential("", "");//AÑADIR
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
