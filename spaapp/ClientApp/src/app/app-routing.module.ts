import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PacienteConsultaComponent } from './InterfazPaciente/paciente-consulta/paciente-consulta.component';
import { PacienteRegistroComponent } from './InterfazPaciente/paciente-registro/paciente-registro.component';

const routes: Routes =[{

path: 'pacienteRegistro',
component: PacienteRegistroComponent
},
{
path: 'pacienteConsulta',
component: PacienteConsultaComponent
}
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
