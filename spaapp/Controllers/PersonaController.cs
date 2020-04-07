using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using spaapp.Models;

namespace spaapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PacienteService _personaService;
        public IConfiguration Configuration { get; }
        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PacienteService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var paciente = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
            return paciente;
        }

        // GET: api/Persona/5
        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> Get(string identificacion)
        {
            var paciente = _personaService.BuscarxIdentificacion(identificacion);
            if (paciente == null) return NotFound();
            var personaViewModel = new PersonaViewModel(paciente);
            return personaViewModel;
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Paciente persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
        // DELETE: api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _personaService.Eliminar(identificacion);
            return Ok(mensaje);
        }
        private Paciente MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Paciente
            {
                Identificacion = personaInput.Identificacion,
                Nombre = personaInput.Nombre,
                ValorHospital = personaInput.ValorHospital,
                SalarioTrabajador = personaInput.SalarioTrabajador
            };
            return persona;
        }
        // PUT: api/Persona/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Paciente persona)
        {
            throw new NotImplementedException();
        }
    }
}