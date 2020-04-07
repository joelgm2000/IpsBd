import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/paciente';
import { PacienteService } from 'src/app/services/paciente.service';

@Component({
  selector: 'app-paciente-consulta',
  templateUrl: './paciente-consulta.component.html',
  styleUrls: ['./paciente-consulta.component.css']
})
export class PacienteConsultaComponent implements OnInit {
 
  paciente:Paciente[];

  constructor(private pacienteService: PacienteService) { }

  ngOnInit(): void {
  this.pacienteService.get().subscribe(result => { this.paciente = result; });
  } 

}
