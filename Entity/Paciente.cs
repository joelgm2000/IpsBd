using System;

namespace Entity
{
    public class Paciente
    {
        public string Identificacion{ get; set; } 
        public string Nombre{ get; set; }
        public double ValorHospital{ get; set; }
        public double SalarioTrabajador{ get; set; }
        public double ValorCopago{ get{
            double total,Porcentaje = 0;
         if(SalarioTrabajador>=25000000)
         {
             Porcentaje=0.20;
            total=(this.ValorHospital*Porcentaje);
         }
         else
         {
              Porcentaje=0.10;
            total=(this.ValorHospital*Porcentaje);  
         }
         return total;
        }
        }
      

    }
   
}
