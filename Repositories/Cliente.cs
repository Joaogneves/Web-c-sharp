using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using Models;

namespace Repositories
{
    public class Cliente
    {
        public readonly string _connectionString;
        public SqlConnection _conn;
        readonly SqlCommand _cmd;
        public Cliente(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(_connectionString);
            _cmd = new SqlCommand();
        }

        public List<Models.Cliente> GetAll()
        {
            List<Models.Cliente> clientes = new List<Models.Cliente>();
            using(_conn)
            {
                _conn.Open();
                using(_cmd)
                {
                    _cmd.Connection = _conn;
                    _cmd.CommandText = "select id, nome, dataNascimento from cliente";
                    SqlDataReader dr = _cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Models.Cliente c = new Models.Cliente();
                        c.Id = (int)dr["id"];
                        c.Nome = (string)dr["nome"];
                        if (!(dr["dataNascimento"] is DBNull))
                            c.DataNascimento = (DateTime)dr["dataNascimento"];
                        clientes.Add(c);
                    }
                    
                }
            }

            return clientes;
        }

        public Models.Cliente GetById(int id)
        {
            using (_conn)
            {
                Models.Cliente c = new Models.Cliente();
                _conn.Open();
                using (_cmd)
                {
                    _cmd.Connection = _conn;
                    _cmd.CommandText = "select id, nome, dataNascimento from cliente";
                    SqlDataReader dr = _cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        c.Id = (int)dr["id"];
                        c.Nome = (string)dr["nome"];
                        if (!(dr["dataNascimento"] is DBNull))
                            c.DataNascimento = (DateTime)dr["dataNascimento"];
                    }
                    return c;
                }
            }
        }
        public int Add(Models.Cliente cliente)
        {
            using (_conn)
            {
                _conn.Open();
                using (_cmd)
                {
                    _cmd.CommandText = "insert into cliente(nome, dataNascimento) values (@nome, @datanascimento); SELECT Convert(int, SCOPE_IDENTITY());";
                    _cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = cliente.Nome;
                    _cmd.Parameters.Add(new SqlParameter("@datanascimento", SqlDbType.VarChar)).Value = cliente.DataNascimento;
                    _cmd.Connection = _conn;
                    var res = _cmd.ExecuteScalar();
                    return Convert.ToInt32(res);
                }
            }
        }

        public int Put()
        {
            return 0;
        }

        public int Delete()
        {
            return 0;
        }

    }

    

}