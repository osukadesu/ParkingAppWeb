using Entidad;
using PersonaModel;

namespace ClienteModel
{
    public class ClienteInputModel : PersonaInputModel
    {
        public string IdCliente { get; set; }
        public string IdVehiculo { get; set; }
        public string IdTicket { get; set; }

    }

    public class ClienteViewModel : ClienteInputModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            IdCliente = cliente.Cedula;
            Cedula = cliente.Cedula;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            Edad = cliente.Edad;
            Sexo = cliente.Sexo;
            Email = cliente.Email;
            Telefono = cliente.Telefono;
        }
    }
}