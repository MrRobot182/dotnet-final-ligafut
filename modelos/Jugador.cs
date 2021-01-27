using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LigaFutbol
{
    public class Jugador
    {
        private int id;
        private int idEquipo;
        private string numero;
        private string nombres;
        private string app;
        private string apm;
        private string fechaN;
        private int idPosicion;
        private DB dbo;

        public int Id
        {
            get { return id; }
        }

        public int IdEquipo
        {
            get { return idEquipo; }
        }

        public string Numero
        {
            get { return numero; }
        }

        public string Nombres
        {
            get { return nombres; }
        }

        public string App
        {
            get { return app; }
        }

        public string Apm
        {
            get { return apm; }
        }
        public string FechaN
        {
            get { return fechaN; }
        }

        public int IdPosicion
        {
            get { return idPosicion; }
        }

        public Jugador()
        {
            DB dbo = new DB();
            this.dbo = dbo;
        }

        public Jugador(int idEquipo, string numero, string nombres, string app, string apm, string fechaN, int idPosicion)
        {
            DB dbo = new DB();
            this.dbo = dbo;
            this.idEquipo = idEquipo;
            this.numero = numero;
            this.nombres = nombres;
            this.app = app;
            this.apm = apm;
            this.fechaN = fechaN;
            this.idPosicion = idPosicion;
        }

        public Jugador(int idEquipo)
        {
            DB dbo = new DB();
            this.dbo = dbo;
            this.idEquipo = idEquipo;
        }

        public Jugador(int id, int mode)
        {
            DB dbo = new DB();
            this.dbo = dbo;
            this.id = id;
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
        public DataSet JugadoresEquipo(string idEquipo)
        {
            string query = "select SUBSTRING(nombres, 1, 1) + '. ' + ap_pat as Jugador,goles as Goles,asistencias as Asistencias,tarj_amarillas as 'Tarjetas amarillas',tarj_rojas as 'Tarjetas rojas' from estadisticas_jugador inner join jugadores on jugadores.id_jugador=estadisticas_jugador.id_jugador where id_equipo="+ idEquipo +" order by Jugador asc;";
            return Consulta(query);
        }
        
        public DataSet DatosJugadores()
        {
            string query = "select id_jugador, nombres + ' ' + ap_pat + ' ' + ap_mat as 'Nombre completo',numero as 'Playera',posiciones_jug.abreviatura as 'Posicion',fecha_nac as 'Fecha de nacimiento',(cast(datediff(dd, fecha_nac, GETDATE()) / 365.25 as int)) as 'Edad' from jugadores inner join posiciones_jug on jugadores.id_posicion=posiciones_jug.id_posicion where id_equipo='"+ this.idEquipo.ToString() +"' order by posiciones_jug.id_posicion asc;";
            return Consulta(query);
        }

        public DataSet Posiciones()
        {
            string query = "select * from posiciones_jug;";
            return Consulta(query);
        }

        public int Insertar()
        {
            dbo.Conn.Open();
            string query1 = "select COUNT(*) from jugadores where numero='" + this.numero + "' and id_equipo='"+ this.idEquipo.ToString() +"';";
            SqlCommand cmd = new SqlCommand(query1, dbo.Conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            dbo.Conn.Close();
            
            if (count == 0)
            {
                dbo.Conn.Open();
                string query2 = "select COUNT(*) from jugadores where id_equipo='"+ this.idEquipo.ToString() +"';";
                cmd = new SqlCommand(query2, dbo.Conn);
                int jugadores = Convert.ToInt32(cmd.ExecuteScalar());
                dbo.Conn.Close();

                if (jugadores == 10)
                {
                    return 2;
                }
                else
                {
                    dbo.Conn.Open();

                    cmd = new SqlCommand("inserta_jugador", dbo.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@equ", this.idEquipo);
                    cmd.Parameters.AddWithValue("@num", this.numero);
                    cmd.Parameters.AddWithValue("@nom", this.nombres);
                    cmd.Parameters.AddWithValue("@app", this.app);
                    cmd.Parameters.AddWithValue("@apm", this.apm);
                    cmd.Parameters.AddWithValue("@fna", this.fechaN);
                    cmd.Parameters.AddWithValue("@pos", this.idPosicion);
                    cmd.ExecuteNonQuery();

                    dbo.Conn.Close();

                    return 0;
                }


            }
            else
                return 1;

        }
        public void ConsultaJugador()
        {
            string query = "select * from jugadores where id_jugador='" + this.id + "';";

            DataSet jugador = Consulta(query);

            this.idEquipo = Convert.ToInt32(jugador.Tables[0].Rows[0][1]);
            this.numero = jugador.Tables[0].Rows[0][2].ToString();
            this.nombres= jugador.Tables[0].Rows[0][3].ToString();
            this.app = jugador.Tables[0].Rows[0][4].ToString();
            this.apm = jugador.Tables[0].Rows[0][5].ToString();
            this.fechaN = jugador.Tables[0].Rows[0][6].ToString();
            this.idPosicion = Convert.ToInt32(jugador.Tables[0].Rows[0][7]);

        }
        public void Eliminar()
        {
            dbo.Conn.Open();

            SqlCommand cmd = new SqlCommand("elimina_jugador", dbo.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idj", this.id);
            cmd.ExecuteNonQuery();

            dbo.Conn.Close();
        }

        public void Actualizar(string numero, string nombres, string app, string apm, string fechaN, int idPosicion)
        {
            dbo.Conn.Open();

            this.numero = numero;
            this.nombres = nombres;
            this.app = app;
            this.apm = apm;
            this.fechaN = fechaN;
            this.idPosicion = idPosicion;

            SqlCommand cmd = new SqlCommand("editar_jugador", dbo.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idj", this.id);
            cmd.Parameters.AddWithValue("@num", this.numero);
            cmd.Parameters.AddWithValue("@nom", this.nombres);
            cmd.Parameters.AddWithValue("@app", this.app);
            cmd.Parameters.AddWithValue("@apm", this.apm);
            cmd.Parameters.AddWithValue("@fna", this.fechaN);
            cmd.Parameters.AddWithValue("@pos", this.idPosicion);

            cmd.ExecuteNonQuery();

            dbo.Conn.Close();
        }

        public DataSet NumeroJugador()
        {
            string query = "select id_jugador, numero + ' - ' + SUBSTRING(nombres,1,1) + '. ' + ap_pat + ' ' + ap_mat as 'nombre_completo' from jugadores where id_equipo='" + this.idEquipo.ToString() + "';";
            return Consulta(query);
        }

        public DataSet Incidentes()
        {
            string query = "select * from incidentes";
            return Consulta(query);
        }
    }
}