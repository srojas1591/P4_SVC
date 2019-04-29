using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ServiceModel;



namespace SVC.Interfaces
{
    [ServiceContract]
  public interface IDatabase
    {
        [OperationContract]
        DataTable ListarDatos(string sNombreSP, ref string sMsj_Error);

        [OperationContract]
        DataTable FiltrarDatos(string sNombreSP, string sNombreParametro,SqlDbType DbType, string sValorParametro,ref string sMsj_Error);

        [OperationContract]
        bool Inserta_DatosSinIndentity(string sNombreSP, DataTable dtParametros, ref string sMsj_Error);

        [OperationContract]
        string InsertaDatosConIdentity(string sNombreSP, DataTable dtParametros, ref string sValorScalar, ref string sMsj_Error);

        [OperationContract]
        bool Modifica_Datos(string sNombreSP, DataTable dtParametros, ref string sMsj_Error);

        [OperationContract]
        bool Elimina_Datos(string sNombreSP, DataTable dtParametros, ref string sMsj_Error);
    }
}
