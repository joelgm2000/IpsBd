using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spaapp.Models
{
    
        public class PersonaInputModel
    {
       public string Identificacion{get; set;}
        public string Nombre{get; set;}
        public double ValorHospital{get; set;}
        public double SalarioTrabajador{get; set;}
       
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Paciente persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            ValorHospital = persona.ValorHospital;
            SalarioTrabajador = persona.SalarioTrabajador;
            
        }
         public decimal ValorCopago{get;}
    }
    
}
