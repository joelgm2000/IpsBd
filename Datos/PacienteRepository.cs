using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class PacienteRepository
    {
        private readonly SqlConnection _connection;
        
    private readonly List<Paciente> _personas = new List<Paciente>();
        public PacienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Paciente persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (Identificacion, Nombre, ValorHospital, SalarioTrabajador, ValorCopago) 
                                        values (@Identificacion,@Nombre,@ValorHospital,@SalarioTrabajador,@ValorCopago)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@ValorHospital", persona.ValorHospital);
                command.Parameters.AddWithValue("@SalarioTrabajador", persona.SalarioTrabajador);
                command.Parameters.AddWithValue("@ValorCopago", persona.ValorCopago);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Paciente persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        
        public List<Paciente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Paciente> personas = new List<Paciente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Paciente persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }
        public Paciente BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Paciente DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Paciente persona = new Paciente();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.ValorHospital = (double)dataReader["ValorHospital"];
            persona.SalarioTrabajador = (double)dataReader["SalarioTrabajador"];
            return persona;
        }
        public int Totalizar()
        {
            return _personas.Count();
        }
        
    }
}

