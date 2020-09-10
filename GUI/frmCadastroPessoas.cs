using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace GUI
{
    public partial class frmCadastroPessoas : Form
    {
        public frmCadastroPessoas()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmCadastroPessoas_Load(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.NmPessoa = txtNome.Text;
            pessoa.NrCPF = mtxtCPF.Text;
            pessoa.DtNascimento = dtpNascimento.Value;
            switch (cbCivil.Text)
            {
                case "Solteiro":
                    pessoa.DsEstadoCivil = 'S';
                    break;
                case "Casado":
                    pessoa.DsEstadoCivil = 'C';
                    break;
                default:
                    pessoa.DsEstadoCivil = 'D';
                    break;
                        
            }
            //Exemplo completo 
            /*if(rbaMasculino.Checked )
            {
                pessoa.DsSexo = 'M';
            }
            else
            {
                pessoa.DsSexo = 'F';
            }*/
            //IF ternario ou em Lina
            pessoa.DsSexo = rbaMasculino.Checked ? 'M' : 'F';
            pessoa.DsEmail = txtEmail.Text;
            pessoa.NrTelefone = mtxtTelefone.Text;
            pessoa.BtRecebeSMS = chcSMS.Checked;
            pessoa.BtRecebeEmail = chkEmail.Checked;

            PessoaDAL pessoaDAL = new PessoaDAL();
            pessoaDAL.InserirPessoa(pessoa);

            MessageBox.Show("Adicionado com sucesso.");

            
            
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int cdPessoa = Convert.ToInt32(txtCodigo.Text);

            PessoaDAL pessoaDAL = new PessoaDAL();

            Pessoa pessoa = pessoaDAL.BuscarPessoa(cdPessoa);

            if (pessoa == null)
            {
                MessageBox.Show("Pessoa não encontrada.");
            }
            else
            {
                txtNome.Text = pessoa.NmPessoa;
                mtxtCPF.Text = pessoa.NrCPF;
                dtpNascimento.Value = pessoa.DtNascimento;
                switch (pessoa.DsEstadoCivil)
                {
                    case 'S':
                        cbCivil.Text = "Solteiro";
                        break;
                    case 'C':
                        cbCivil.Text = "Casado";
                        break;
                    default:
                        cbCivil.Text = "Divorciado";
                        break;
                }
                rbaMasculino.Checked = pessoa.DsSexo == 'M';
                rbFeminino.Checked = pessoa.DsSexo == 'F';
                txtEmail.Text = pessoa.DsEmail;
                mtxtTelefone.Text = pessoa.NrTelefone;
                chcSMS.Checked = pessoa.BtRecebeSMS;
                chkEmail.Checked = pessoa.BtRecebeEmail;
            }
        }
    }
}
