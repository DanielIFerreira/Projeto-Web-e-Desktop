using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;

namespace WebUI
{
    public partial class CadastroPessoas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se não for um postBack -- ou seja é a primeira vez que entra na pagina
            if (!Page.IsPostBack) 
            {
                CarregarPessoas();
            }  
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.NmPessoa = txtNome.Text;
            pessoa.NrCPF = txtCPF.Text;
            pessoa.DtNascimento = Convert.ToDateTime(txtDtNAscimento.Text);
            pessoa.DsEstadoCivil = Convert.ToChar(ddlEstadosCivis.SelectedValue);
            pessoa.DsSexo = Convert.ToChar(rblSexos.SelectedValue);
            pessoa.DsEmail = txtEmail.Text;
            pessoa.NrTelefone = txtTelefone.Text;
            pessoa.BtRecebeSMS = cbSMS.Checked;
            pessoa.BtRecebeEmail = cbEmail.Checked;

            PessoaDAL pessoaDAL = new PessoaDAL();

            pessoaDAL.InserirPessoa(pessoa);

            lblMenssagen.Text = "Pessoa Inserida com sucesso.";
            LimparDados();
            CarregarPessoas();

        }
        public void LimparDados()
        {
            txtCodigo.Text = "";
            txtCPF.Text = "";
            txtDtNAscimento.Text = "";
            txtEmail.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            ddlEstadosCivis.SelectedValue = "";
            rblSexos.SelectedValue = "";
           
        }
        public void CarregarPessoas()
        {
            PessoaDAL pessoaDAL = new PessoaDAL();
            grvPessoas.DataSource = pessoaDAL.ListarPessoas();
            grvPessoas.DataBind();                                                                               
            
        }
    }
}