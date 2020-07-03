using Demodavi.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Demodavi.Negocio
{
    public class usuario
    {
        public string resvalue;

        // Llamo a la base de datos
        ClsOperDatam Clsdatam = new ClsOperDatam();

        // retorno los resultados de la base
        public DataTable retornodatam;

        public string creausuario(int opt, int idusu, string nombre, string fecnaci, string sexo)
        {
            Clsdatam.callpa(opt,idusu,nombre,fecnaci,sexo);

            if (Clsdatam.resproce != "Afirmativo")
            {
                resvalue = Clsdatam.resproce;
            }
            else
            {
                resvalue = "Afirmativo";
            }

            return resvalue;
        }

        public DataTable retornusu()
        {
            Clsdatam.Getusere();

            if (Clsdatam.resproce != "Afirmativo")
            {
                resvalue = Clsdatam.resproce;
            }
            else
            {
                retornodatam = Clsdatam.dt_resval;
                resvalue = "Afirmativo";
            }
            return retornodatam;
        }

        public DataTable retornusuparami(int codeusu)
        {
            Clsdatam.Getusereparam(codeusu);

            if (Clsdatam.resproce != "Afirmativo")
            {
                resvalue = Clsdatam.resproce;
            }
            else
            {
                retornodatam = Clsdatam.dt_resval;
                resvalue = "Afirmativo";
            }
            return retornodatam;
        }

    }
}