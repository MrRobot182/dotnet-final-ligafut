using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LigaFutbol
{
    public class Partido
    {
        private int id;
        private int idLocal;
        private int idVisita;
        private string fechaHora;
        private int golesLocal;
        private int golesVisita;
        private int finalizado;
        private DB dbo;

        public int Id
        {
            get { return id; }
        }
        public int IdLocal
        {
            get { return idLocal; }
        }
        public int IdVisitante
        {
            get { return idVisita; }
        }
        public string FechaHora
        {
            get { return fechaHora; }
        }
        public int GolesLocal
        {
            get { return golesLocal; }
        }
        public int GolesVisita
        {
            get { return golesVisita; }
        }
        public int Finalizado
        {
            get { return finalizado; }
        }
        public Partido()
        {
            DB dbo = new DB();
            this.dbo = dbo;
        }
        public Partido(int id)
        {
            this.id = id;
            DB dbo = new DB();
            this.dbo = dbo;
        }
        public Partido(int idLocal, int idVisita)
        {
            this.idLocal = idLocal;
            this.idVisita = idVisita;
            DB dbo = new DB();
            this.dbo = dbo;
        }

        public Partido(int idLocal, int idVisita, string fechaHora)
        {
            this.idLocal = idLocal;
            this.idVisita = idVisita;
            this.fechaHora = fechaHora;
            DB dbo = new DB();
            this.dbo = dbo;
        }
        public Partido(int id, string fechaHora)
        {
            this.id = id;
            this.fechaHora = fechaHora;
            DB dbo = new DB();
            this.dbo = dbo;
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
        public DataSet Partidos()
        {
            string query = "select id_partido,a.nombre as 'Local', a.escudo as 'EscudoL', goles_local as 'Goles(L)', goles_visita as 'Goles(V)', b.nombre as 'Visita', b.escudo as 'EscudoV', fecha_hora as 'Fecha/hora',finalizado from partidos inner join equipos a on partidos.id_equipo_local = a.id_equipo inner join equipos b on partidos.id_equipo_visitante = b.id_equipo order by fecha_hora desc";
            return Consulta(query);
        }

        public DataSet ConsultaPartido()
        {
            string query = "select id_partido,a.nombre as 'Local',a.escudo as 'EscudoL', goles_local as 'Goles(L)', goles_visita as 'Goles(V)', b.nombre as 'Visita', b.escudo as 'EscudoV', fecha_hora as 'Fecha/hora',finalizado from partidos inner join equipos a on partidos.id_equipo_local = a.id_equipo inner join equipos b on partidos.id_equipo_visitante = b.id_equipo where id_partido='" + this.id.ToString() + "';";
            return Consulta(query);
        }

        public DataSet EquiposPartido()
        {
            string query = "select id_equipo_local, id_equipo_visitante from partidos where id_partido='"+this.id.ToString()+"';";
            return Consulta(query);
        }
        public int Insertar()
        {
            dbo.Conn.Open();
            string query1 = "select COUNT(*) from jugadores where id_equipo='" + this.idLocal.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query1, dbo.Conn);
            int countL = Convert.ToInt32(cmd.ExecuteScalar());

            string query2 = "select COUNT(*) from jugadores where id_equipo='" + this.idVisita.ToString() + "';";
            cmd = new SqlCommand(query2, dbo.Conn);
            int countV = Convert.ToInt32(cmd.ExecuteScalar());
            dbo.Conn.Close();

            if(countL >= 5 && countV >= 5)
            {
                dbo.Conn.Open();

                cmd = new SqlCommand("inserta_partidos", dbo.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idl", this.idLocal);
                cmd.Parameters.AddWithValue("@idv", this.idVisita);
                cmd.Parameters.AddWithValue("@fec", this.fechaHora);
                cmd.ExecuteNonQuery();

                dbo.Conn.Close();

                return 0;
            }
            else
            {
                if (countL < 5)
                {
                    return 1;
                }
                else if (countV < 5)
                {
                    return 2;
                }
                else
                    return -1;
            }
                   

        }

        public void Actualizar()
        {
            dbo.Conn.Open();

            SqlCommand cmd = new SqlCommand("cambio_fecha_partido", dbo.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idp", this.id);
            cmd.Parameters.AddWithValue("@fec", this.fechaHora);

            cmd.ExecuteNonQuery();

            dbo.Conn.Close();
        }

        public void Finalizar()
        {
            dbo.Conn.Open();

            SqlCommand cmd = new SqlCommand("finalizar_partido", dbo.Conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idp", this.id);
            cmd.ExecuteNonQuery();

            dbo.Conn.Close();
        }

    }

    
}