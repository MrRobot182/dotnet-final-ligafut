using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.jugadores
{
    public partial class consultar : System.Web.UI.Page
    {
        public static Equipo equ = new Equipo();
        public static Jugador editar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dd1.DataSource = equ.Equipos();
                dd1.DataValueField = "id_equipo";
                dd1.DataTextField = "nombre";
                dd1.DataBind();
            }
        }
        protected void MostrarJugadores(object sender, EventArgs e)
        {
            Jugador jug = new Jugador(Convert.ToInt32(dd1.SelectedValue));
            DataSet jugadores = jug.DatosJugadores();

            gv1.DataSource = jugadores;
            gv1.DataBind();
        }
        protected void Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Jugador jug = new Jugador(Convert.ToInt32(gv1.DataKeys[e.RowIndex].Values[0]),0);
            jug.Eliminar();

            Page.Response.Redirect("consultar.aspx");
        }
        protected void Editar(object sender, GridViewEditEventArgs e)
        {

            pan1.Visible = false;
            pan2.Visible = true;

            editar = new Jugador(Convert.ToInt32(gv1.DataKeys[e.NewEditIndex].Values[0]), 0);

            dd2.DataSource = editar.Posiciones();
            dd2.DataValueField = "id_posicion";
            dd2.DataTextField = "descripcion";
            dd2.DataBind();

            editar.ConsultaJugador();

            title.InnerText = "Editar jugador" + " " + editar.Nombres;

            txtNom.Text = editar.Nombres;
            txtApp.Text = editar.App;
            txtApm.Text = editar.Apm;            
            fn.Text += ": " +  editar.FechaN.Substring(3, 2) + "/" + editar.FechaN.Substring(0, 2) + "/" + editar.FechaN.Substring(6, 4);
            txtNum.Value = editar.Numero;
            dd2.SelectedValue = editar.IdPosicion.ToString();
        }

        protected void Actualizar(object sender, EventArgs e)
        {
            editar.Actualizar(txtNum.Value, txtNom.Text, txtApp.Text, txtApm.Text, dateFn.Value, Convert.ToInt32(dd2.SelectedValue));

            Page.Response.Redirect("consultar.aspx");
        }

    }
}