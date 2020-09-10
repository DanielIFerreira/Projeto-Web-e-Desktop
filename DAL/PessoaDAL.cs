using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class PessoaDAL
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDSistemaFull;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public void InserirPessoa(Pessoa pessoa)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "INSERT INTO Pessoas VALUES(@nome, @cpf, @nasc, @ec, @sexo, @email, @telefone, @recebeSMS, @recebeEmail)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome", pessoa.NmPessoa);
            cmd.Parameters.AddWithValue("@cpf", pessoa.NrCPF);
            cmd.Parameters.AddWithValue("@nasc", pessoa.DtNascimento);
            cmd.Parameters.AddWithValue("@ec", pessoa.DsEstadoCivil);
            cmd.Parameters.AddWithValue("@sexo", pessoa.DsSexo);
            cmd.Parameters.AddWithValue("@email", pessoa.DsEmail);
            cmd.Parameters.AddWithValue("@telefone", pessoa.NrTelefone);
            cmd.Parameters.AddWithValue("@recebeSMS", pessoa.BtRecebeSMS);
            cmd.Parameters.AddWithValue("@recebeEmail", pessoa.BtRecebeEmail);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public Pessoa BuscarPessoa(int cdPessoa)
        {
            Pessoa pessoa = null;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            //Para fazer busca no BD
            string sql = "SELECT * FROM Pessoas WHERE CdPessoa = @cod";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@cod", cdPessoa);

            SqlDataReader  dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                pessoa = new Pessoa();
                pessoa.CdPessoa = cdPessoa;
                pessoa.NmPessoa = dr["NmPessoa"].ToString();
                pessoa.NrCPF = dr["NrCPF"].ToString();
                pessoa.DtNascimento = Convert.ToDateTime(dr["DtNascimento"]);
                pessoa.DsEstadoCivil = Convert.ToChar(dr["DsEstadoCivil"]);
                pessoa.DsSexo = Convert.ToChar(dr["DsSexo"]);
                pessoa.DsEmail = dr["DsEmail"].ToString();
                pessoa.NrTelefone = dr["NrTelefone"].ToString();
                pessoa.BtRecebeSMS = Convert.ToBoolean(dr["BtRecebeSMS"]);
                pessoa.BtRecebeEmail = Convert.ToBoolean(dr["BtRecebeEmail"]);
            }
            conn.Close();

            return pessoa;
        }

        public List<Pessoa> ListarPessoas()
        {
            List<Pessoa> listaPessoa = new List<Pessoa>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM Pessoas";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Pessoa pessoa;
                while (dr.Read())
                {
                    pessoa = new Pessoa();
                    pessoa.CdPessoa = Convert.ToInt32(dr["CdPessoa"]);
                    pessoa.NmPessoa = dr["NmPessoa"].ToString();
                    pessoa.NrCPF = dr["NrCPF"].ToString();
                    pessoa.DtNascimento = Convert.ToDateTime(dr["DtNascimento"]);
                    pessoa.DsEstadoCivil = Convert.ToChar(dr["DsEstadoCivil"]);
                    pessoa.DsSexo = Convert.ToChar(dr["DsSexo"]);
                    pessoa.DsEmail = dr["DsEmail"].ToString();
                    pessoa.NrTelefone = dr["NrTelefone"].ToString();
                    pessoa.BtRecebeSMS = Convert.ToBoolean(dr["BtRecebeSMS"]);
                    pessoa.BtRecebeEmail= Convert.ToBoolean(dr["BtRecebeEmail"]);

                    listaPessoa.Add(pessoa);

                   
                }
            }
            conn.Close();

            return listaPessoa;

        }
    }
}
