using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.equipos
{
    public partial class insertar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insertar(object sender, EventArgs e)
        {
            Equipo equ = new Equipo((txtNom.Text).Trim());
            int res = equ.Insertar(upl1);

            if (res == 0)
            {
                lbl1.CssClass = "text-success";
                lbl1.Text = "Equipo registrado";
            }
            else if (res == 1)
            {
                lbl1.CssClass = "text-danger";
                lbl1.Text = "Ya existe un equipo con el mismo nombre";
            }
            else if (res == 2)
            {
                lbl1.CssClass = "text-danger";
                lbl1.Text = "Ya hay 20 equipos en el torneo";
            }
            else
            {
                lbl1.CssClass = "text-danger";
                lbl1.Text = "Problema con registro";
            }
             
        }
    }
}