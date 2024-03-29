using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for baglanti
/// </summary>
public class baglanti
{
	public baglanti()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public SqlConnection baglan()
    {

        string baglantiyol = ConfigurationManager.ConnectionStrings["dbaglan"].ConnectionString.ToString();
        SqlConnection baglanti = new SqlConnection(baglantiyol);
        baglanti.Open();
        return (baglanti); 
    }

    public int cmd(string sqlcumle) 
    {
        SqlConnection baglan = this.baglan(); 
        SqlCommand sqlsorgu = new SqlCommand(sqlcumle, baglan); 
        int sonuc = 0;
        
       try
        {
            sqlsorgu.ExecuteNonQuery();
        }
       catch (SqlException ex)
       {

           throw new Exception(ex.Message + "(" + sqlcumle + ")"); 
        }
        sqlsorgu.Dispose();
        baglan.Close();
        baglan.Dispose();
        return (sonuc);

    }

    public DataTable GetDataTable(string sql)
    {
        SqlConnection baglan = this.baglan(); 
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataTable dt = new DataTable(); 
        
        try
        {
            adapter.Fill(dt); 
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + "(" + sql + ")"); 
        }
        adapter.Dispose();
        baglan.Close();
        baglan.Dispose();
        return dt; 
    }

    public DataSet GetDataSet(string sql)
    {
        SqlConnection baglan = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataSet ds = new DataSet();
        
        try
        {
            adapter.Fill(ds); 
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + "(" + sql + ")"); 
        }
        adapter.Dispose();
        baglan.Close();
        baglan.Dispose();
        return ds; 
    }


    public DataRow GetDataRow(string sql)
    {
        
        DataTable table = GetDataTable(sql); 
        if (table.Rows.Count == 0) return null; 
        return table.Rows[0];

    }

    public string GetDataCell(string sql) 
    {
        DataTable table = GetDataTable(sql); 
        if (table.Rows.Count == 0) return null; 
        return table.Rows[0][0].ToString(); 
    }


}