using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.equipos
{
    public partial class consultar : System.Web.UI.Page
    {
        private static Equipo editar;
        protected void Page_Load(object sender, EventArgs e)
        {
            Equipo equ = new Equipo();
            gv1.DataSource = equ.EquiposEditar();
            gv1.DataBind();
        }

        protected void Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Equipo equ = new Equipo(Convert.ToInt32(gv1.DataKeys[e.RowIndex].Values[0]));
            equ.Eliminar();
            gv1.DataSource = equ.EquiposEditar();
            gv1.DataBind();
            lbl1.Text = "Equipo eliminado";
        }

        protected void Editar(object sender, GridViewEditEventArgs e)
        {
            pan1.Visible = false;
            pan2.Visible = true;

            title.InnerText = "Editar equipo";
            editar = new Equipo(Convert.ToInt32(gv1.DataKeys[e.NewEditIndex].Values[0]));

            editar.ConsultaEquipo();

            txtNom.Text = editar.Nombre;
            //~
            imged.ImageUrl = "/assets/img/escudos/" + editar.Escudo;
        }

        protected void Actualizar(object sender, EventArgs e)
        {
            //equ.Actualizar(txtNom.Text, upl1);
            editar.Actualizar(txtNom.Text.ToUpper(), upl1);

            Page.Response.Redirect("consultar.aspx");
        }

    }
}