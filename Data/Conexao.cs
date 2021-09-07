using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MigradorEBC.Data
{
    public class Conexao
    {
        private static SqlConnection _conexao;
        public static SqlConnection ObterConexaoPrincipal => _conexao;

        public static string Servidor { get => servidor; set => servidor = value; }
        public static string Usuario { get => usuario; set => usuario = value; }
        public static string Database { get => database; set => database = value; }
        public static string Senha { get => senha; set => senha = value; }

        private static string servidor;
        private static string database;
        private static string usuario;
        private static string senha;

        public static string conexao;

        public static SqlConnection DbConnection()
        {
            try
            {
                _conexao = new SqlConnection(conexao);
                _conexao.Open();
                return _conexao;
            }
            catch (Exception exSQL)
            {
                throw new ArgumentNullException("Não foi possível conectar, verifique os dados da conexão.");
                return null;
            }
        }
        public static DataTable ListarBancos()
        {
            SqlDataAdapter da = null;
            DataTable dtB = new DataTable();
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT NAME AS NOME_BANCO FROM sys.databases WHERE NAME NOT IN('MASTER','MODEL','MSDB','tempdb')";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dtB);
                    return dtB;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("Não foi possível conectar, verifique os dados da conexão.");
            }
        }

        public static DataTable CarregarTabelas(string nomeBanco)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select table_name from " + nomeBanco + ".INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE'";
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());

                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable CarregarRegistrosTabela(string nomeBanco, string nometabela)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"Select * from " + nomeBanco + ".." + nometabela;
                    da = new SqlDataAdapter(cmd.CommandText, DbConnection());

                    da.Fill(dt);
                    return dt;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   }
}