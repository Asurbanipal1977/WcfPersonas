using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPersonas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePersona
    {

        [OperationContract]
        Persona GetPersona(int? Id);

        [OperationContract]
        List<Persona> GetPersonas();

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Persona
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public int Edad { 
            get
            {
                int edad = DateTime.Now.Year - FechaNacimiento.Year;
                
                return (DateTime.Today < FechaNacimiento.AddYears(edad) ? edad -1: edad);
            }
            set { }
         }
    }
}
