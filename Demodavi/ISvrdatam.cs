using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace Demodavi
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISvrdatam" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISvrdatam
    {
        [OperationContract]
        string insercion(int opt, int idusu, string nombre, string fecnaci, string sexo);

        [OperationContract]
        listusu Dtusuar();

        [OperationContract]
        listusuparami Dtusuarparami(int numi);
    }

    [DataContract]
    public class listusu
    {
        [DataMember]
        public DataTable usuardatam
        {
            get;set;
        }
    }

    [DataContract]
    public class listusuparami
    {
        [DataMember]
        public DataTable usuardatamparami
        {
            get; set;
        }
    }
}
