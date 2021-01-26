using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol
{
    public class Equipo
    {
        private int id;
        private string nombre;
        private string escudo;
        private DB dbo;

        public Equipo()
        {
            DB dbo = new DB();
            this.dbo = dbo;
        }

        public Equipo(string nombre)
        {
            this.nombre = nombre.ToUpper();
            DB dbo = new DB();
            this.dbo = dbo;
        }
        public Equipo(int id)
        {
            this.id = id;
            DB dbo = new DB();
            this.dbo = dbo;
        }
        public Equipo(int id, string nombre, string escudo)
        {
            this.id = id;
            this.nombre = nombre;
            this.escudo = escudo;
            DB dbo = new DB();
            this.dbo = dbo;
        }
        public int Id
        {
            get { return id; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public string Escudo
        {
            get { return escudo; }
        }
        public DataSet Consulta(string query)
        {
            dbo.Conn.Open();

            SqlDataAdapter adp = new SqlDataAdapter(query, dbo.Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            dbo.Conn.Close();

            return ds;
        }
        public DataSet Equipos()
        {
            string query = "select * from equipos;";
            return Consulta(query);
        }

        public DataSet EquiposEditar() 
        {
            string query = "select id_equipo,nombre as Equipo, concat('/assets/img/escudos/',escudo) as Escudo from equipos order by nombre asc";
            return Consulta(query);
        }
        public void SubirImagen(FileUpload img, string nombre)
        {            
            string path = System.Web.HttpContext.Current.Server.MapPath("~/assets/img/escudos/");            
            img.SaveAs(path + this.escudo);        
        }
        public int Insertar(FileUpload img)
        {
            dbo.Conn.Open();
            string query1 = "select COUNT(nombre) from equipos where nombre='" + this.nombre + "';";
            SqlCommand cmd = new SqlCommand(query1, dbo.Conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            dbo.Conn.Close();

            if (count == 0)
            {
                dbo.Conn.Open();
                string query2 = "select COUNT(*) from equipos;";
                cmd = new SqlCommand(query2, dbo.Conn);
                int teams = Convert.ToInt32(cmd.ExecuteScalar());
                dbo.Conn.Close();

                if(teams == 20)
                {
                    return 2;
                }
                else
                {
                    if (img.HasFile)
                    {
                        this.escudo = this.nombre + System.IO.Path.GetExtension(img.FileName);                        
                        this.SubirImagen(img, this.escudo);
                    }
                    else
                        this.escudo = "default.png";

                    dbo.Conn.Open();

                    cmd = new SqlCommand("inserta_equipo", dbo.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom", this.nombre);
                    cmd.Parameters.AddWithValue("@esc", this.escudo);
                    cmd.ExecuteNonQuery();

                    dbo.Conn.Close();

                    return 0;
                }
                

            }
            else
                return 1;

            return -1;
        }

        public void Eliminar()
        {
            dbo.Conn.Open();

            SqlCommand cmd = new SqlCommand("elimina_equipo", dbo.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ide", this.id);
            cmd.ExecuteNonQuery();
            
            dbo.Conn.Close();
        }

        public void ConsultaEquipo()
        {
            string query = "select * from equipos where id_equipo='"+ this.id +"';";

            DataSet equipo = Consulta(query);

            this.nombre = equipo.Tables[0].Rows[0][1].ToString();
            this.escudo = equipo.Tables[0].Rows[0][2].ToString();

        }
        public void Actualizar(string nombre, FileUpload img)
        {
            dbo.Conn.Open();

            this.nombre = nombre;

            if (img.HasFile)
            {
                this.escudo = this.nombre + System.IO.Path.GetExtension(img.FileName);
                this.SubirImagen(img, this.escudo);
            }

            SqlCommand cmd = new SqlCommand("editar_equipo", dbo.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ide", this.id);
            cmd.Parameters.AddWithValue("@nom", this.nombre);
            cmd.Parameters.AddWithValue("@esc", this.escudo);
            cmd.ExecuteNonQuery();

            dbo.Conn.Close();
        }
    }
}