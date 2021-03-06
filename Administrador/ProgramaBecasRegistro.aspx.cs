﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramaBecasRegistro : System.Web.UI.Page
{
    private string idNuevoPrograma; //Atributo que guarda el codigo generado al cargar la página

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){
            //GenerarCodigo();
            //idProgramaBeca.Value = idNuevoPrograma;
            //resultCode.InnerHtml = "<h5 class='center-align  deep-purple-text text-lighten-2'>Código: " + idNuevoPrograma+"</h5>";
        }
    }

    protected void GenerarCodigo()
    {//Generamos un codigo aleatorio
        Random rnd = new Random();
        string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Cadena ocupada para generar un código aleatorio
        do
        {
            idNuevoPrograma = "BE";
            for (int i = 0; i < 2; i++)
            {
                idNuevoPrograma += letras.Substring(rnd.Next(0, letras.Length - 1), 1); //Guardamos la letra seleccionada
            }
        } while (ProgramaBeca_Model.VerificarCodigo(idNuevoPrograma) > 0);
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string mensaje;
            ProgramaBeca programa = new ProgramaBeca(txtIdPrograma.Text, txtName.Text, txtDescription.Text);
            if (ProgramaBeca_Model.VerificarCodigo(programa.IdPrograma) == 0) //Volvemos a verificar codigo
            {
                if (ProgramaBeca_Model.Insertar(programa))
                {
                    mensaje = "Materialize.toast('Programa registado exitosamente!', 2000, '', function(){ location.href = '/Administrador/GestionProgramaBecas.aspx'})";
                }else
                {
                    mensaje = "Materialize.toast('Error :(', 2000)";
                }
            }else
            {
                mensaje = "Materialize.toast('Código ya existe', 2000)";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmLog", mensaje, true);
        }
    }
}