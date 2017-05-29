using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcliente : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			CarregaClientes();
		}
	}

	

	protected void btn_incluir_Click(object sender, EventArgs e)
	{
		try
		{
            new Cliente().Incluir(txt_nome.Text, txt_email.Text);
            CarregaClientes();
            Page.ClientScript.RegisterStartupScript(typeof(Page), "sucess", "$('#msg').html('Cliente incluído com sucesso.').slideDown('slow').delay(3000).slideUp('slow');", true);
		}
		catch (Exception er) {
			lbl_msg.Text = "Ocorreu um erro inesperado!";
		}
	}

	void CarregaClientes()
    {
        grid_cliente.DataSource = new ClsFuncoes().AbrirTabela("SELECT * FROM CLIENTE");
        grid_cliente.DataBind();
        txt_cod.Text = "";
        txt_nome.Text = "";
        txt_email.Text = "";
    }


    protected void grid_cliente_SelectedIndexChanged(object sender, EventArgs e)
	{
        Cliente cli = new Cliente(grid_cliente.SelectedRow.Cells[1].Text);
        txt_cod.Text = cli.Codigo;
        txt_nome.Text = cli.Nome;
        txt_email.Text = cli.Email;
	}

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        try
        {
            new Cliente().Excluir(txt_cod.Text);
            lbl_msg.Text = "Cliente Excluído";
            CarregaClientes();
        }
        catch (Exception er) {
            lbl_msg.Text = "Erro ao excluir, " + er.Message;
        }
    }

    protected void grid_cliente_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grid_cliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_cliente.PageIndex = e.NewPageIndex;
        CarregaClientes();
    }

    protected void btn_alt_Click(object sender, EventArgs e)
    {
        Cliente cli = new Cliente();
        cli.Codigo = txt_cod.Text;
        cli.Nome = txt_nome.Text;
        cli.Email = txt_email.Text;
        cli.Alterar();
        CarregaClientes();
    }

    protected void btn_pesq_Click(object sender, EventArgs e)
    {
        grid_cliente.DataSource = new Cliente().Pesquisar(txt_pesqnome.Text);
        grid_cliente.DataBind();
    }
}