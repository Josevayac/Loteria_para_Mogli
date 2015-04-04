using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Loteria.Entidades;
using AccesoDatos;

namespace Loteria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ILoteriaNacional
    {
       [OperationContract]
        String NumeroGanador();

        [OperationContract]
        PremioEnt PremioMayor();

        [OperationContract]
        void AgregarPremio(PremioEnt premio);

        [OperationContract]
        Double TipoCambio();
        
        [OperationContract]
        Respuesta AgregarSorteo(Sorteo oSorteo, usuario oUsuario);

        [OperationContract]
        void EditarSorteo(Sorteo oSorteo);
        [OperationContract]
        void EliminarSorteo(Sorteo oSorteo);

        [OperationContract]
        bool AgregarUsuario(usuario oUsuario);

        [OperationContract]
        void EditarPremio(Premio oPremio);

        [OperationContract]
        void EliminarPremio(Premio oPremio);

        [OperationContract]
        Respuesta ValidarUsuario(usuario oUsuario);

        // TODO: agregue aquí sus operaciones de servicio
    }
}
