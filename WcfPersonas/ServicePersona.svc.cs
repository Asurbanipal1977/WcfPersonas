using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPersonas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicePersona : IServicePersona
    {
        private List<Persona> lstPersonas = new List<Persona> { 
            new Persona { Id=1, Nombre="Miguel Ángel", FechaNacimiento=new DateTime(1977,3,13)},
            new Persona { Id=2, Nombre="Alicia", FechaNacimiento=new DateTime(1977,12,17)}
        };
        public Persona GetPersona(int? id)
        {
            Persona per = lstPersonas.Where(p => p.Id == id).FirstOrDefault();
            if (id == null || per == null)
                return null;
            else
            {
                return per;
            }
        }

        public List<Persona> GetPersonas()
        {
            return lstPersonas;
        }
    }
}
