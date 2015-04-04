using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Loteria.Entidades
{
    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public bool HayError { set; get; }

        [DataMember]
        public string MensajeError { set; get; }

    }
}