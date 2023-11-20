using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Models;
using System.Data;
using System.Threading.Tasks;

namespace Repositories
{
    public class Medico
    {

        readonly string _connectionString;
        readonly SqlConnection _conn;
        readonly SqlCommand _cmd;


        public Medico(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(_connectionString);
            _cmd = new SqlCommand();
        }

        public async Task<List<Models.Medico>> Get()
        {
            List<Models.Medico> medicos = new List<Models.Medico>();
            using (_conn)
            {
                _conn.Open();
                using (_cmd)
                {
                    _cmd.Connection = _conn;
                    _cmd.CommandText = "SELECT id, nome, crm, especialidade FROM medico;";
                    SqlDataReader dr = await _cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        Models.Medico medico = new Models.Medico();
                        medico.Id = (int)dr["id"];
                        medico.Nome = (string)dr["nome"];
                        medico.CRM = (string)dr["crm"];
                        if (!(dr["especialidade"] is DBNull)) medico.Especialidade = (string)dr["especialidade"];
                        medicos.Add(medico);
                    }
                }
            }
            return medicos;
        }

        public async Task<Models.Medico> Get(int id)
        {
            Models.Medico medico = new Models.Medico();
            using (_conn)
            {
                _conn.Open();
                using (_cmd)
                {
                    _cmd.CommandText = "SELECT id, nome, crm, especialidade FROM medico where id = @id;";
                    _cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    _cmd.Connection = _conn;

                    SqlDataReader dr = await _cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        medico.Id = (int)dr["id"];
                        medico.Nome = (string)dr["nome"];
                        medico.CRM = (string)dr["crm"];
                        if (!(dr["especialidade"] is DBNull)) medico.Especialidade = (string)dr["especialidade"];
                    }
                }
            }
            return medico;
        }

        public async Task<int> Post(Models.Medico medico)
        {
            using (_conn)
            {
                _conn.Open();
                using (_cmd)
                {
                    _cmd.CommandText = "insert into medico (nome, crm, especialidade) values (@nome, @crm, @especialidade); SELECT SCOPE_IDENTITY();";
                    _cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = medico.Nome;
                    _cmd.Parameters.Add(new SqlParameter("@crm", SqlDbType.VarChar)).Value = medico.CRM;
                    _cmd.Parameters.Add(new SqlParameter("@especialidade", SqlDbType.VarChar)).Value = medico.Especialidade;
                    _cmd.Connection = _conn;
                    var res = await _cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(res);
                }
            }
        }

        public async Task<int> Put(Models.Medico medico)
        {
            using (_conn)
            {
                _conn.Open();
                using (_cmd)
                {
                    _cmd.CommandText = "update medico set nome = @nome, crm = @crm, especialidade = @especialidade where id = @id;";
                    _cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = medico.Id;
                    _cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = medico.Nome;
                    _cmd.Parameters.Add(new SqlParameter("@crm", SqlDbType.VarChar)).Value = medico.CRM;
                    _cmd.Parameters.Add(new SqlParameter("@especialidade", SqlDbType.VarChar)).Value = medico.Especialidade;
                    _cmd.Connection = _conn;
                    int n = await _cmd.ExecuteNonQueryAsync();
                    return n;
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            Models.Medico m = new Models.Medico();
            using (_conn)
            {
                _conn.Open();
                using (_cmd)
                {
                    _cmd.CommandText = "delete medico where id = @id;";
                    _cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    _cmd.Connection = _conn;
                    int n = await _cmd.ExecuteNonQueryAsync();
                    return n;
                }
            }
        }
    }
}