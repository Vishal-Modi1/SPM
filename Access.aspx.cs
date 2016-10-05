using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;


public partial class Access : System.Web.UI.Page
{
    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory\Database1.accdb");
    OleDbCommand cmd;
    OleDbDataAdapter da;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
        cmd = new OleDbCommand("select * from stud", con);
       
        da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        OleDbCommand cmd = new OleDbCommand("insert into stud(sname,city) values ('mahesh','surat')", con);
        cmd.ExecuteNonQuery();
        GridView1.DataBind();
        con.Close();
        Page_Load(sender, e);

        
    }
}