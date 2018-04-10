using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestorEducativo_Header : System.Web.UI.UserControl
{
    private String titulo;
    public string Titulo
    {
        get
        {
            return titulo;
        }

        set
        {
            titulo = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Sesion.VerificarUsuario(HttpContext.Current.Session["ID"].ToString());
            titleTag.Text = "[Gestor Educativo]" + Titulo;
        }
    }
}