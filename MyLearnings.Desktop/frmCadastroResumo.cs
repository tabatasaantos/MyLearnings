﻿using MyLearnings.Entidades.Entidades;
using MyLearnings.RegrasDeNegocio.RegrasDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLearnings.Desktop
{
    public partial class frmCadastroResumo : Form
    {
        public string operacao;

        public frmCadastroResumo()
        {
            InitializeComponent();

            toolTipMeusBotoes.SetToolTip(btnInserir, "Inserir Usuário");
            toolTipMeusBotoes.SetToolTip(btnSalvar, "Salvar Usuário");
            toolTipMeusBotoes.SetToolTip(btnAlterar, "Alterar Cadastro");
            toolTipMeusBotoes.SetToolTip(btnExcluir, "Excluir Usuário");
            toolTipMeusBotoes.SetToolTip(btnCancelar, "Cancelar Cadastro");
        }

        public void LimpaTela()
        {
            txtIdResumo.Clear();
            txtResumo.Clear();
            txtSubAssunto.Clear();
            txtAssunto.Clear();
        }

        public void AlteraBotoes(int op)
        {
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnInserir.Enabled = false;

            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnLocalizar.Enabled = true;
                
            }
            if (op == 2)
            {
                btnCancelar.Enabled = true;
                btnSalvar.Enabled = true;
                btnLocalizar.Enabled = false;
                
            }
            if (op == 3)
            {
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
                btnSalvar.Enabled = true;
            }
        }

        private void frmCadastroResumo_Load(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
            this.AlteraBotoes(2);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ResumoRegrasDeNegocio resumoRegras = new ResumoRegrasDeNegocio();

            if (this.operacao == "Inserir")
            {
                Resumo resumo = new Resumo();

                resumo.Subassunto = txtSubAssunto.Text;
                resumo.Assunto = txtAssunto.Text;
                resumo.Texto = txtResumo.Text;

                resumoRegras.Incluir(resumo);

                txtIdResumo.Text = resumo.Id.ToString();

                MessageBox.Show("Cadastro efetuado com sucesso! " + resumo.Id.ToString());
            }

            if (this.operacao == "Alterar" && txtIdResumo.Text != null)
            {
                Resumo resumo = new Resumo();

                resumo.Subassunto = txtSubAssunto.Text;
                resumo.Assunto = txtAssunto.Text;
                resumo.Texto = txtResumo.Text;

                //if (txtIdUsuAlteracao.Text != String.Empty)
                //{
                //    IdLogin.IdLogado(Convert.ToInt32(txtIdUsuAlteracao.Text));
                //    tecnica.IdUsuarioAlteracao = Convert.ToInt32(txtIdUsuAlteracao.Text);
                //}
                //else
                //{
                //    tecnica.IdUsuarioAlteracao = IdLogin.IdLogado(Convert.ToInt32(txtIdUsuCadastro.Text));
                //    //  tecnica.IdUsuarioAlteracao = 1;
                //}
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

                if (d.ToString() == "Yes")
                {
                    ResumoRegrasDeNegocio resumoRegrasDeNegocio = new ResumoRegrasDeNegocio();
                    resumoRegrasDeNegocio.Excluir(Convert.ToInt32(txtIdResumo.Text));
                    this.LimpaTela();
                    this.AlteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir esse registro. \nO registro está sendo utilizado em outro local.");
                this.AlteraBotoes(3);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.AlteraBotoes(1);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.AlteraBotoes(2);
        }
    }
}
