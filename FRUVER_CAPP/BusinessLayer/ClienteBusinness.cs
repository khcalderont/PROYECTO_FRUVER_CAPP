using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataLayer;
using Entities;

namespace BusinessLayer
{
    public class ClientesBusiness
    {
        
        public static bool GuardarCliente(ClientesEntity cliente)
        {
            return ClienteData.GuardarCliente(cliente);
        }

        public static List<ClientesEntity> ObtenerClientes()
        {
            return ClienteData.ObtnerClientes();
        }

        public static ClientesEntity ObtenerCliente(int IdClientes)
        {
            return ClienteData.ObtnerCliente(IdClientes);
        }

        public static ClientesEntity ObtnerClientePorNumeroDocumento(string NumeroDocumento)
        {
            return ClienteData.ObtnerClientePorNumeroDocumento(NumeroDocumento);
        }

        public static bool UpdateCliente(ClientesEntity cliente)
        {
            return ClienteData.UpdateCliente(cliente);
        }
    }
    
}
