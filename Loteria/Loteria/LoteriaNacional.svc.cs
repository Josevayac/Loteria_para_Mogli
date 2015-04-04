using System;
using System.Linq;
using AccesoDatos;
using Loteria.Entidades;


namespace Loteria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class LoteriaNacional : ILoteriaNacional
    {
        /*
        public String NumeroGanador()
        {
            int n = 0;
            Random oRandom = new Random();
            n = oRandom.Next(100, 999);
            return "El numero obtenido es: " + n;
        }

        public Entidades.PremioEnt PremioMayor()
        {
            Random oR = new Random();
            return new Entidades.PremioEnt()
            {
                id = 5455,
                monto = 5000000000,
                premio = oR.Next(100, 999)
            };
        }

        public void AgregarPremio(Entidades.PremioEnt premio)
        {

        }

        public Double TipoCambio()
        {
            tipoCambio.wsIndicadoresEconomicosSoapClient oTipoCambio = new tipoCambio.wsIndicadoresEconomicosSoapClient();
            var tipoCambio = oTipoCambio.ObtenerIndicadoresEconomicos("318", "14/03/2015", "14/03/2015", "UTN", "N");
            return Convert.ToDouble(tipoCambio.Tables[0].Rows[0]["NUM_VALOR"].ToString());
        }
        */

        public void AgregarSorteo(Sorteo oSorteo)
        {
            ModeloLoteria oMlModeloLoteria = new ModeloLoteria();

            oMlModeloLoteria.Sorteo.Add(oSorteo);
            oMlModeloLoteria.SaveChanges();
        }

        public void EditarSorteo(Sorteo oSorteo)
        {
            throw new NotImplementedException();
        }

        public void EliminarSorteo(Sorteo oSorteo)
        {
            throw new NotImplementedException();
        }

        public void AgregarPremio(Premio oPremio)
        {
            throw new NotImplementedException();
        }

        public void EditarPremio(Premio oPremio)
        {
            throw new NotImplementedException();
        }

        public void EliminarPremio(Premio oPremio)
        {
            throw new NotImplementedException();
        }

        public string NumeroGanador()
        {
            throw new NotImplementedException();
        }

        public Entidades.PremioEnt PremioMayor()
        {
            throw new NotImplementedException();
        }

        public void AgregarPremio(Entidades.PremioEnt premio)
        {
            throw new NotImplementedException();
        }

        public double TipoCambio()
        {
            throw new NotImplementedException();
        }

        double ILoteriaNacional.TipoCambio()
        {
            throw new NotImplementedException();
        }

        public Respuesta AgregarSorteo(Sorteo oSorteo, usuario oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                ModeloLoteria omLoteria = new ModeloLoteria();
                var md5 =
                    omLoteria.Database.SqlQuery<string>("select convert(varchar(32), HasBytes('MD5','@password'),2)",
                        new object[] { oUsuario.password }).First();

                oUsuario.password = md5;
                usuario oUsuarioLoteria =
                    omLoteria.usuario.FirstOrDefault(x => x.username == oUsuario.username && x.password == md5);
                if (oUsuarioLoteria != null)
                {
                    if (oUsuarioLoteria.admin)
                    {
                        omLoteria.Sorteo.Add(oSorteo);
                        omLoteria.SaveChanges();
                    }
                    else
                    {
                        oRespuesta.HayError = true;
                        oRespuesta.MensajeError = "Solo puede agregar sorteos los administradores";
                    }
                }
            }
            catch (Exception error)
            {
                oRespuesta.HayError = false;
                oRespuesta.MensajeError = error.ToString();

            }
            return oRespuesta;

        }

        public Boolean AgregarUsuario(usuario oUsuario)
        {
            try
            {
                ModeloLoteria omLoteria = new ModeloLoteria();
                var md5 = omLoteria.Database.SqlQuery<string>("selec convert(varchar(32), HasBytes('MD5','@password'),2)",
                        new object[] { oUsuario.password }).First();

                oUsuario.password = md5;
                omLoteria.usuario.Add(oUsuario);
                omLoteria.SaveChanges();
            }
            catch (Exception error)
            {

                return false;
            }
            return true;
        }

        public Respuesta ValidarUsuario(usuario oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                ModeloLoteria omLoteria = new ModeloLoteria();
                var md5 = omLoteria.Database.SqlQuery<string>("select convert(varchar(32), HasBytes('MD5','@password'),2)",
                        new object[] { oUsuario.password }).First();

                oUsuario.password = md5;
                usuario oUsuarioLoteria = omLoteria.usuario.FirstOrDefault(x => x.username == oUsuario.username && x.password == md5);
                if (oUsuarioLoteria != null)
                {
                    oRespuesta.MensajeError = "El usuario y la contraseña no coinciden";
                    oRespuesta.HayError = true;

                }
            }
            catch (Exception error)
            {
                oRespuesta.HayError = false;
                oRespuesta.MensajeError = error.ToString();
            }
            return oRespuesta;
        }
    }
}
