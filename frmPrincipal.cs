using MigradorEBC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MigradorEBC
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServidor.Text) || string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Informe os dados da conexão");

            }
            else
            {

                Conexao.Servidor = txtServidor.Text;
                Conexao.Usuario = txtUsuario.Text;
                Conexao.Senha = txtSenha.Text;
                Conexao.conexao = @"Server=" + txtServidor.Text + ";database=" + "master" + ";user id=" + txtUsuario.Text + ";password=" + txtSenha.Text + ";";


                cbBancoDados.DataSource = Conexao.ListarBancos();
                cbBancoDados.ValueMember = "NOME_BANCO";
                cbBancoDados.DisplayMember = "NOME_BANCO";
                cbBancoDados.Text = "Selecione o banco de dados";
            }
        }

        private void cbBancoDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTabela.DataSource = Conexao.CarregarTabelas(cbBancoDados.Text);
            cbTabela.ValueMember = "table_name";
            cbTabela.DisplayMember = "table_name";
            cbTabela.Text = "Informe a tabela";
        }

        private void btnConsultarTabela_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBancoDados.Text))
            {
                MessageBox.Show("Informe o banco de dados antes de continuar");
            }
            else
            {

                dataGridView1.DataSource = Conexao.CarregarRegistrosTabela(cbBancoDados.Text, cbTabela.Text);
                lblTotalRegistros.Text = "Total de registros: " + dataGridView1.RowCount.ToString();
            }
        }

        private void btnGerarJSON_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    ExportarJSON.DataTableToJSONWithJSONNet(Conexao.CarregarRegistrosTabela(cbBancoDados.Text, cbTabela.Text), folderBrowserDialog1.SelectedPath + @"\" + cbTabela.Text + ".json");
                    MessageBox.Show("Arquivo JSON contendo " + dataGridView1.RowCount.ToString() + " registros, gerado com sucesso.");
                }

            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar gerar o arquivo.");
            }
        }

        private void btnGerarXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(Conexao.CarregarRegistrosTabela(cbBancoDados.Text, cbTabela.Text));
                    string dsXml = ds.GetXml();

                    ds.WriteXml(folderBrowserDialog1.SelectedPath + @"\" + cbTabela.Text + ".xml", XmlWriteMode.IgnoreSchema);
                    MessageBox.Show("Arquivo XML contendo " + dataGridView1.RowCount.ToString() + " registros, gerado com sucesso.");
                }

               
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar gerar o arquivo.");
            }
        }
    }
}
