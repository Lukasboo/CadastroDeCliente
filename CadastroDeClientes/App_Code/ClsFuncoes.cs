using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de ClsFuncoes
/// </summary>
public class ClsFuncoes
{

	public string conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lucas\Documents\Visual Studio 2017\WebSites\CadastroDeClientes\App_Data\BDCliente.mdf;Integrated Security=True";

	public DataSet AbrirTabela(string sqltxt) {
        try
        {
            SqlConnection cnx = new SqlConnection(conexao);
            cnx.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqltxt, cnx);
            DataSet dst = new DataSet();
            adp.Fill(dst);
            return dst;
        }
        catch (Exception er) {
            return null;
        }
	}

	public SqlConnection Conexao() {
		SqlConnection cnx = new SqlConnection(conexao);
		cnx.Open();
		return cnx;
	}

	


}