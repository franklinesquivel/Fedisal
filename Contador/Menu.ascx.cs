using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contador_Menu : System.Web.UI.UserControl
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
        pageTitle.InnerText = Titulo;
    }
}