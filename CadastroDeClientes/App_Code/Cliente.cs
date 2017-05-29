using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de Cliente
/// </summary>
public class Cliente
{

	public string Codigo { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }

	public Cliente()
	{
		//
		// TODO: Adicionar lógica do construtor aqui
		//
	}

    public void Incluir(string _nome, string _email)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CLIENTE(CLI_NOME, CLI_EMAIL) VALUES(@NOME, @EMAIL)", new ClsFuncoes().Conexao());
            cmd.Parameters.AddWithValue("@NOME", _nome);
            cmd.Parameters.AddWithValue("@EMAIL", _email);
            cmd.ExecuteNonQuery();
        }
        catch (Exception er)
        {
            throw new Exception(er.ToString());
        }
    }


    public Cliente(string _codcli) {
        SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTE WHERE CLI_ID=@COD", new ClsFuncoes().Conexao());
        cmd.Parameters.AddWithValue("@COD", _codcli);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read()) {
            Codigo = dr["CLI_ID"].ToString();
            Nome = dr["CLI_NOME"].ToString();
            Email = dr["CLI_EMAIL"].ToString();
        }
    }

    public void Excluir(string _codcli) {
        SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE WHERE CLI_ID=@COD", new ClsFuncoes().Conexao());
        cmd.Parameters.AddWithValue("@COD", _codcli);
        cmd.ExecuteNonQuery();
    }

    public void Alterar()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("UPDATE CLIENTE SET CLI_NOME=@NOME, CLI_EMAIL=@EMAIL WHERE CLI_ID=@COD", new ClsFuncoes().Conexao());
            cmd.Parameters.AddWithValue("@NOME", Nome);
            cmd.Parameters.AddWithValue("@EMAIL", Email);
            cmd.Parameters.AddWithValue("@COD", Codigo);
            cmd.ExecuteNonQuery();
        }
        catch (Exception er) {
            throw new Exception(er.ToString());
        }
    }

    public DataSet Pesquisar(string _txtpesq) {
        return new ClsFuncoes().AbrirTabela("SELECT * FROM CLIENTE WHERE CLI_NOME LIKE '%"+ _txtpesq +"%' ");
    }

}