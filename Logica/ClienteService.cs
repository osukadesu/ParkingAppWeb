using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ClienteService
    {
        private readonly ParkingContext _context;

        public ClienteService(ParkingContext context)
        {
            _context = context;
        }
        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)

            {
                return new GuardarClienteResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaClienteResponse ConsultarTodos()
        {
            try
            {
                List<Cliente> clientes = _context.Clientes.ToList();
                return new ConsultaClienteResponse(clientes);
            }
            catch (Exception e)
            {
                return new ConsultaClienteResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Cliente BuscarxIdentificacion(string idCliente)
        {
            Cliente cliente = _context.Clientes.Find(idCliente);
            return cliente;
        }

        public string Actualizar(Cliente clienteNuevo)
        {
            try
            {
                var clienteViejo = _context.Clientes.Find(clienteNuevo.IdCliente);
                if (clienteViejo != null)
                {
                    clienteViejo.Nombre = clienteNuevo.Nombre;
                    clienteViejo.Apellido = clienteNuevo.Apellido;
                    clienteViejo.Edad = clienteNuevo.Edad;
                    clienteViejo.Email = clienteNuevo.Email;
                    clienteViejo.Telefono = clienteNuevo.Telefono;
                    clienteViejo.Sexo = clienteNuevo.Sexo;
                    _context.Clientes.Update(clienteViejo);
                    _context.SaveChanges();
                    return ($"El registro {clienteNuevo.Nombre} se ha modificado");
                }
                else
                {
                    return $"Lo sentimos, {clienteNuevo.IdCliente} no se encuentra registrado";
                }
                
            }
            catch (Exception e)
            {
                return $"Error inesperado al Modificar: {e.Message}";
            }
            
        }

        public class ConsultaClienteResponse
        {

            public ConsultaClienteResponse(List<Cliente> clientes)
            {
                Error = false;
                Clientes = clientes;
            }

            public ConsultaClienteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Cliente> Clientes { get; set; }
        }
        public class GuardarClienteResponse

        {

            public GuardarClienteResponse(Cliente cliente)

            {
                Error = false;

                Cliente = cliente;

            }



            public GuardarClienteResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Cliente Cliente { get; set; }

        }

    }
}