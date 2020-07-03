using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MvcDemoDavi.Svr_datamdavi;

namespace MvcDemoDavi.Models
{
    public class ClsDataBas
    {
        Svr_datamdavi.SvrdatamClient svruseri = new SvrdatamClient();

        // clase para llamar todos los registros
        Svr_datamdavi.listusu listere = new Svr_datamdavi.listusu();

        // clase para filtrar los registros
        Svr_datamdavi.listusuparami listereparam = new Svr_datamdavi.listusuparami();

        public DataTable Dtresu;

        public DataTable Dtresu1;

        public List<usuario> verusu()
        {
            List<usuario> usualiste = new List<usuario>();

            listere = svruseri.Dtusuar();
            DataTable dtreslist = new DataTable();
            dtreslist = listere.usuardatam;

            // lleno la lista dependiendo de los resultados
            for (int i=0; i< dtreslist.Rows.Count;i++)
            {
                usuario userem = new usuario
                {
                    idusuario = Convert.ToInt32(dtreslist.Rows[i]["idusuario"]),
                    nombres = dtreslist.Rows[i]["nombre"].ToString(),
                    fecnac = dtreslist.Rows[i]["Fecha_Nacimiento"].ToString(),
                    sexo = dtreslist.Rows[i]["genero"].ToString()
                };
                usualiste.Add(userem);
            }

            return usualiste;
        }

        public int ejecutaproc(usuario formeuse, int opt)
        {
            int respro;
            try
            {
                svruseri.insercion(opt, formeuse.idusuario, formeuse.nombres, formeuse.fecnac, formeuse.sexo);
                respro = 1;
            }
            catch(Exception ex)
            {
                respro = 2;
            }

            return respro;
        }

        public usuario verusuparami(int codeusu)
        {
            List<usuario> usualiste1 = new List<usuario>();

            listereparam = svruseri.Dtusuarparami(codeusu);
            DataTable dtreslist1 = new DataTable();
            dtreslist1 = listereparam.usuardatamparami;
            usuario userem = new usuario();

            // lleno la lista dependiendo de los resultados
            for (int i = 0; i < dtreslist1.Rows.Count; i++)
            {
                {
                    userem.idusuario = Convert.ToInt32(dtreslist1.Rows[i]["idusuario"]);
                    userem.nombres = dtreslist1.Rows[i]["nombre"].ToString();
                    userem.fecnac = dtreslist1.Rows[i]["Fecha_Nacimiento"].ToString();
                    userem.sexo = dtreslist1.Rows[i]["genero"].ToString();
                };
                usualiste1.Add(userem);
            }

            return userem;
        }
    }
}