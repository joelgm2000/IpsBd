using Datos;
using Entity;
using System;
using System.Collections.Generic;

namespace Logica
{
    
    public class PacienteService
    {
        
        private readonly ConnectionManager _conexion;
        private readonly PacienteRepository _repositorio;
        
        public PacienteService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new PacienteRepository(_conexion);
        }
        public GuardarPersonaResponse Guardar(Paciente persona)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(persona);
                _conexion.Close();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Paciente> ConsultarTodos()
        {
            _conexion.Open();
            List<Paciente> personas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return personas;
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var paciente = _repositorio.BuscarPorIdentificacion(identificacion);
                if (paciente != null)
                {
                    _repositorio.Eliminar(paciente);
                    _conexion.Close();
                    return ($"El registro {paciente.Nombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public Paciente BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Paciente persona = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return persona;
        }
        public int Totalizar()
        {
            return _repositorio.Totalizar();
        }
       
    }

    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Paciente persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Paciente Persona { get; set; }
    }
}


