using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using Entities;
using MySql.Data;

namespace DataLayer
{
    public class ProductosData
    {
        public static MySqlConnection ConexionBD()
        {
            MySqlConnection conex = new MySqlConnection
            ("Server=127.0.0.1;" +
             "Database=bdfruvercapp;" +
             "Uid=root;" +
             "Pwd=;" +
             "SslMode=None");

            return conex;
        }

        public static bool GuardarProductos(ProductosEntity producto)
        {
            MySqlConnection conex = ConexionBD();
            
                conex.Open();
                string sql = @"INSERT INTO tbproductos
                                (Codigo, Descripcion, 
                                 Stock, Presentacion, 
                                 Valor)
                             VALUES 
                                 (@Codigo, @Descripcion, 
                                  @Stock, @Presentacion, 
                                  @Valor)";

                MySqlCommand cmd = new MySqlCommand(sql, conex);

                cmd.Parameters.AddWithValue("@Codigo", producto.IdProducto);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Codigo);
                cmd.Parameters.AddWithValue("@Stock", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Presentacion", producto.Presentacion);
                cmd.Parameters.AddWithValue("@Valor", producto.Valor);

                int NumeroFilas = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (NumeroFilas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        public static List<ClientesEntity> ObtnerClientes()
        {
            List<ClientesEntity> clientes = new List<ClientesEntity>();
           
            MySqlConnection conex = new MySqlConnection();
            conex = ConexionBD();    
            conex.Open();

                string sql = "SELECT * FROM tbclientes";

                MySqlCommand cmd = new MySqlCommand(sql, conex);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clientes.Add(CargarCliente(reader));
                }
                return clientes;
            
        }

        public static ClientesEntity CargarCliente(MySqlDataReader reader)
        {
            ClientesEntity cliente = new ClientesEntity();
            cliente.IdCliente = Convert.ToInt32(reader["id_Clientes"]);
            cliente.TipoDocumento = Convert.ToString(reader["TipoDocumento"]);
            cliente.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
            cliente.Primerombre = Convert.ToString(reader["PrimerNombre"]);
            cliente.SegundoNombre = Convert.ToString(reader["SegundoNombre"]);
            cliente.PrimerApellido = Convert.ToString(reader["PrimerApellido"]);
            cliente.SegudoApellido = Convert.ToString(reader["SegundoApellido"]);
            cliente.Telefono = Convert.ToString(reader["Telefono"]);
            cliente.Email = Convert.ToString(reader["Email"]);
            cliente.direccion = Convert.ToString(reader["Direccion"]);
            cliente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
            return cliente;
        }

        public static bool UpdateCliente(ClientesEntity cliente)
        {
            MySqlConnection conex = ConexionBD();

            conex.Open();
            string sql = @"UPDATE `tbclientes` 
                         SET `TipoDocumento`=@TipoDocumento,`NumeroDocumento`=@NumeroDocumento,
                         `PrimerNombre`=@PrimerNombre,`SegundoNombre`=@SegundoNombre,`PrimerApellido`=@PrimerApellido,
                         `SegundoApellido`=@SegundoApellido,`Email`=@Email,`Direccion`=@Direccion,`Telefono`=@Telefono,`FechaNacimiento`=@FechaNacimiento 
                         WHERE id_Clientes = @IdClientes";

            MySqlCommand cmd = new MySqlCommand(sql, conex);

            cmd.Parameters.AddWithValue("@IdClientes", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
            cmd.Parameters.AddWithValue("@NumeroDocumento", cliente.NumeroDocumento);
            cmd.Parameters.AddWithValue("@PrimerNombre", cliente.Primerombre);
            cmd.Parameters.AddWithValue("@SegundoNombre", cliente.SegundoNombre);
            cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
            cmd.Parameters.AddWithValue("@SegundoApellido", cliente.SegudoApellido);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Direccion", cliente.direccion);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);

            int NumeroFilas = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (NumeroFilas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ClientesEntity ObtnerClientePorNumeroDocumento(string NumeroDocumento)
        {
            ClientesEntity cliente = new ClientesEntity();

            MySqlConnection conex = new MySqlConnection();

            conex = ConexionBD();
            conex.Open();

            string sql = "SELECT * FROM `tbclientes` WHERE NumeroDocumento = @NumeroDocumento ";

            MySqlCommand cmd = new MySqlCommand(sql, conex);

            cmd.Parameters.AddWithValue("@NumeroDocumento", NumeroDocumento);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente = CargarCliente(reader);
            }
            return cliente;

        }

        public static ClientesEntity ObtnerCliente(int IdClientes)
        {
            ClientesEntity cliente = new ClientesEntity();

            MySqlConnection conex = new MySqlConnection();
           
            conex = ConexionBD();    
            conex.Open();

            string sql = "SELECT * FROM `tbclientes` WHERE id_Clientes = @IdClientes ";

                MySqlCommand cmd = new MySqlCommand(sql, conex);

                cmd.Parameters.AddWithValue("@IdClientes", IdClientes);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = CargarCliente(reader);
                }
                return cliente;
            
        }


    }
}
