using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LigaFutbol
{
    public class Estadisticas
    {
        private DB dbo;

        public Estadisticas()
        {
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
        public DataSet TablaGeneral()
        {
            string query = "select row_number() over(order by ((victorias*3)+(empates)) desc,(goles_a_favor-goles_en_contra) desc) as Posicion,nombre as Equipo,victorias as G,empates as E,derrotas as P,goles_a_favor as GF,goles_en_contra as GC,(goles_a_favor-goles_en_contra) as DG,((victorias*3)+(empates)) as Puntos from estadisticas_equipo inner join equipos on equipos.id_equipo=estadisticas_equipo.id_equipo order by Puntos desc;";
            return Consulta(query);
        }
        public DataSet Goleadores()
        {
            string query = "select top 10 SUBSTRING(jugadores.nombres, 1, 1) + '. ' + jugadores.ap_pat as Jugador,equipos.nombre as Equipo,estadisticas_jugador.goles as Goles from jugadores inner join equipos on jugadores.id_equipo=equipos.id_equipo inner join estadisticas_jugador on jugadores.id_jugador= estadisticas_jugador.id_jugador order by estadisticas_jugador.goles desc;";
            return Consulta(query);
        }
        public DataSet Asistentes()
        {
            string query = "select top 10 SUBSTRING(jugadores.nombres, 1, 1) + '. ' + jugadores.ap_pat as Jugador,equipos.nombre as Equipo,estadisticas_jugador.asistencias as Asistencias from jugadores inner join equipos on jugadores.id_equipo=equipos.id_equipo inner join estadisticas_jugador on jugadores.id_jugador=estadisticas_jugador.id_jugador order by estadisticas_jugador.asistencias desc;";
            return Consulta(query);
        }
        public DataSet MejorAtaque()
        {
            string query = "select row_number() over(order by goles_a_favor desc) as Posicion,nombre as Equipo,goles_a_favor as 'Goles anotados' from estadisticas_equipo inner join equipos on estadisticas_equipo.id_equipo=equipos.id_equipo order by goles_a_favor desc;";
            return Consulta(query);
        }

        public DataSet MejorDefensa()
        {
            string query = "select row_number() over(order by goles_en_contra asc) as Posicion,nombre as Equipo,goles_en_contra as 'Goles recibidos' from estadisticas_equipo inner join equipos on estadisticas_equipo.id_equipo=equipos.id_equipo order by goles_en_contra asc;";
            return Consulta(query);
        }

        public DataSet FairPlay()
        {
            string query = "select row_number() over(order by (sum(estadisticas_jugador.tarj_amarillas)+(sum(estadisticas_jugador.tarj_rojas)*4)) asc) as Posicion,equipos.nombre as Equipo,sum(estadisticas_jugador.tarj_amarillas) as 'Tarjetas Amarillas',sum(estadisticas_jugador.tarj_rojas) as 'Tarjetas Rojas',(sum(estadisticas_jugador.tarj_amarillas) + (sum(estadisticas_jugador.tarj_rojas) * 4)) as Puntos from jugadores inner join equipos on jugadores.id_equipo = equipos.id_equipo join estadisticas_jugador on jugadores.id_jugador = estadisticas_jugador.id_jugador group by equipos.nombre order by Puntos asc;";
            return Consulta(query);
        }

        public void Incidentes(int idPartido, int idIncidente, int idJugador, int minuto)
        {
            dbo.Conn.Open();

            SqlCommand cmd = new SqlCommand("inserta_incidentes", dbo.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idp", idPartido);
            cmd.Parameters.AddWithValue("@idi", idIncidente);
            cmd.Parameters.AddWithValue("@idj", idJugador);
            cmd.Parameters.AddWithValue("@min", minuto);
            cmd.ExecuteNonQuery();

            dbo.Conn.Close();
        }
        

    }
    
}