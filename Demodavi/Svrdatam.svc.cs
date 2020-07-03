using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Demodavi.Negocio;
using System.Data;

namespace Demodavi
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Svrdatam" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Svrdatam.svc o Svrdatam.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Svrdatam : ISvrdatam
    {
        public string resfin;
        usuario usere = new usuario();

        // genero un nuevo datatable de listusu
        listusu resliste = new listusu();

        listusuparami restelisteparami = new listusuparami();

        public string insercion(int opt,int idusu, string nombre, string fecnaci, string sexo)
        {
            resfin = "";

            try
            {
                usere.creausuario(opt,idusu,nombre,fecnaci,sexo);

                if (usere.resvalue == "Afirmativo")
                {
                    resfin = "200";
                }
                else
                {
                    resfin = "500";
                }
            }
            catch (InvalidCastException e)
            {
                resfin = e.Message.ToString();
            }

            return resfin;
        }

        // Cargo los usuarios registrados
        public listusu Dtusuar()
        {
            resfin = "";

            try
            {
                usere.retornusu();

                if (usere.resvalue == "Afirmativo")
                {
                    resliste.usuardatam = usere.retornodatam;
                    resfin = "200";
                }
                else
                {
                    resfin = "500";
                }
            }
            catch (InvalidCastException e)
            {
                resfin = e.Message.ToString();
            }

            return resliste;
        }

        // Cargo los usuarios registrados
        public listusuparami Dtusuarparami(int valusu)
        {
            resfin = "";

            try
            {
                usere.retornusuparami(valusu);

                if (usere.resvalue == "Afirmativo")
                {
                    restelisteparami.usuardatamparami = usere.retornodatam;
                    resfin = "200";
                }
                else
                {
                    resfin = "500";
                }
            }
            catch (InvalidCastException e)
            {
                resfin = e.Message.ToString();
            }

            return restelisteparami;
        }

    }
}
