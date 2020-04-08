using System;

namespace Entity
{
    public class Paciente
    {
        public string Identificacion{ get; set; } 
        public string Nombre{ get; set; }
        public decimal ValorHospital{ get; set; }
        public decimal SalarioTrabajador{ get; set; }
        public decimal ValorCopago{ get{
            decimal total,Porcentaje = 0;
         if(SalarioTrabajador>=25000000)
         {
             Porcentaje=0.20m;
            total=(this.ValorHospital*Porcentaje);
         }
         else
         {
              Porcentaje=0.10m;
            total=(this.ValorHospital*Porcentaje);  
         }
         return total;
        }
        }
      

    }
   
}
