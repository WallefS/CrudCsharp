using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class ClienteRepository : Repository<Cliente, int>
    {
       
        public override void Delete(Cliente entity)
        {
            using (var conn = GetConn())
            {
                string sql = "DELETE Pessoa Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private SqlConnection GetConn()
        {
            return new SqlConnection(StringConnection);
        }

        public override void Delete1(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Cliente Where Id=@Id";
                SqlCommand left = new SqlCommand(sql, conn);
                left.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    left.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public override List<Cliente> GetAll()
        {
            string sql = "Select Id, Nome, Ddd, Numero, FROM Cliente ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var left = new SqlCommand(sql, conn);
                List<Cliente> list = new List<Cliente>();
                Cliente p = null;
                try
                {
                    conn.Open();
                    using (var reader = left.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Cliente();
                            p.Id = (int)reader["Id"];
                            p.Nome = reader["Nome"].ToString();
                            p.Ddd = reader["Ddd"].ToString();
                            p.Numero = reader["Numero"].ToString();
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                }
                return list;
            }
        }
        public override Cliente GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Ddd, Numero, FROM Pessoa WHERE Id=@Id";
                SqlCommand left = new SqlCommand(sql, conn);
                left.Parameters.AddWithValue("@Id", id);
                Cliente p = null;
                try
                {
                    conn.Open();
                    using (var reader = left.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Cliente();
                                p.Id = (int)reader["Id"];
                                p.Nome = reader["Nome"].ToString();
                                p.Ddd = reader["Ddd"].ToString();
                                p.Numero = reader["Numero"].ToString();
                                
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }
        public override void Save(Cliente entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Pessoa (Nome, Ddd, Numero,) VALUES (@Nome, @Ddd, @Numero)";
                SqlCommand left = new SqlCommand(sql, conn);
                left.Parameters.AddWithValue("@Nome", entity.Nome);
                left.Parameters.AddWithValue("@Ddd", entity.Ddd);
                left.Parameters.AddWithValue("@Numero", entity.Numero);
                
                try
                {
                    conn.Open();
                    left.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public override void Update(Cliente entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Cliente SET Nome=@Nome, Ddd=@Ddd, Numero=@Numero, Where Id=@Id";
                SqlCommand left = new SqlCommand(sql, conn);
                left.Parameters.AddWithValue("@Id", entity.Id);
                left.Parameters.AddWithValue("@Nome", entity.Nome);
                left.Parameters.AddWithValue("@Ddd", entity.Ddd);
                left.Parameters.AddWithValue("@Numero", entity.Numero);
                try
                {
                    conn.Open();
                    left.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }

}