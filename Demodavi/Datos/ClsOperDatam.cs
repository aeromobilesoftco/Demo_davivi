using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Demodavi.Datos
{
    public class ClsOperDatam
    {

        ClsDataCon Clsdatami = new ClsDataCon();

        // Datatable de respuesta
        public DataTable dt_resval;
        public DataTable res;
        public string resproce;

        public string callpa(int opt, int idusu, string nombre, string fecnaci, string sexo)
        {
            try
            {

                SqlCommand comando = new SqlCommand("Exec PA_DEMUS "+ opt+","+ idusu+",'"+ nombre+"','"+ fecnaci +"','"+ sexo+"'", Clsdatami.GetDBConnection());
                comando.ExecuteNonQuery();
                resproce = "Afirmativo";

            }
            catch (InvalidCastException e)
            {
                resproce = "Negativo -> " + e.Message.ToString();
            }

            return resproce;
        }

        public DataTable Getusere()
        {
            try
            {

                SqlCommand comando = new SqlCommand("Exec PA_DEMUS 1,0,null,null,null", Clsdatami.GetDBConnection());
                comando.ExecuteNonQuery();
                SqlDataReader sdr_user = comando.ExecuteReader();
                // inserto los datos en un datatable 

                // Creo el datatable 
                dt_resval = new DataTable("Simucre");

                // creo las columnas pertenecientes al datatable
                dt_resval.Columns.Add("idusuario", typeof(int));
                dt_resval.Columns.Add("nombre", typeof(string));
                dt_resval.Columns.Add("Fecha_Nacimiento", typeof(DateTime));
                dt_resval.Columns.Add("genero", typeof(string));

                // leo los resultado que me devolvio
                while (sdr_user.Read())
                {
                    string str_cedula = sdr_user["idusuario"].ToString();
                    string str_nombres = sdr_user["nombre"].ToString();
                    string str_apellidos = sdr_user["fecnac"].ToString();
                    string str_genero = sdr_user["sexo"].ToString();

                    dt_resval.Rows.Add(str_cedula, str_nombres, str_apellidos, str_genero);
                }

                resproce = "Afirmativo";

            }
            catch (InvalidCastException e)
            {
                resproce = "Negativo -> " + e.Message.ToString();
            }

            return dt_resval;
        }

        public DataTable Getusereparam(int codeus)
        {
            try
            {

                SqlCommand comando = new SqlCommand("Exec PA_DEMUS 5,"+ codeus+",null,null,null", Clsdatami.GetDBConnection());
                comando.ExecuteNonQuery();
                SqlDataReader sdr_user = comando.ExecuteReader();
                // inserto los datos en un datatable 

                // Creo el datatable 
                dt_resval = new DataTable("Simucreparam");

                // creo las columnas pertenecientes al datatable
                dt_resval.Columns.Add("idusuario", typeof(int));
                dt_resval.Columns.Add("nombre", typeof(string));
                dt_resval.Columns.Add("Fecha_Nacimiento", typeof(DateTime));
                dt_resval.Columns.Add("genero", typeof(string));

                // leo los resultado que me devolvio
                while (sdr_user.Read())
                {
                    string str_cedula = sdr_user["idusuario"].ToString();
                    string str_nombres = sdr_user["nombre"].ToString();
                    string str_apellidos = sdr_user["fecnac"].ToString();
                    string str_genero = sdr_user["sexo"].ToString();

                    dt_resval.Rows.Add(str_cedula, str_nombres, str_apellidos, str_genero);
                }

                resproce = "Afirmativo";

            }
            catch (InvalidCastException e)
            {
                resproce = "Negativo -> " + e.Message.ToString();
            }

            return dt_resval;
        }

    }
}