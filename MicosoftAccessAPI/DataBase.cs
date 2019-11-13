using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace MicrosoftAccessAPI
{
    internal static class DataBaseProcess
    {
        private static string connectstr(string path, string pw="")
        {
            if(!string.IsNullOrEmpty(pw))
            return string.Format("Provider=Microsoft.Ace.OLEDB.12.0; Data Source='{0}';jet oledb:Database Password='{1}';", path, pw);
            else
                return string.Format()
        }
        internal static bool database_delete(string Address, string Table,string header, object target,string pw)
        {
            try
            {
                string strconn = connectstr(Address,pw)
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = "delete from " + Table + " where " + header + " ='" + target + "'";
                OleDbCommand cmd = new OleDbCommand(strcomm, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //MessageBox.Show("successful");
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                else
                {
                    conn.Close();
                    conn.Dispose();
                    return false;
                }                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        internal static DataTable database_read(string Address, string Table)
        {
            try
            {
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = @"Select * from " + Table;
                OleDbDataAdapter da = new OleDbDataAdapter(strcomm, conn);
                DataSet ds = new DataSet();
                da.FillSchema(ds, SchemaType.Source, Table);
                da.Fill(ds, Table);
                DataTable dt;
                dt = ds.Tables[Table];
                conn.Close();
                conn.Dispose();
                da.Dispose();
                return dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }
        internal static DataTable database_read(string Address, string Table,string Condition,string Content)
        {
            try
            {
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = @"Select * from " + Table + " where " + Condition + "='" + Content + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(strcomm, conn);
                DataSet ds = new DataSet();
                da.FillSchema(ds, SchemaType.Source, Table);
                da.Fill(ds, Table);
                DataTable dt;
                dt = ds.Tables[Table];
                conn.Close();
                conn.Dispose();
                da.Dispose();
                return dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }
        internal static DataTable database_read(string Address, string Table, string Condition, int Content)
        {
            try
            {
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = @"Select * from " + Table + " where " + Condition + "<" + Content + "";
                OleDbDataAdapter da = new OleDbDataAdapter(strcomm, conn);
                DataSet ds = new DataSet();
                da.FillSchema(ds, SchemaType.Source, Table);
                da.Fill(ds, Table);
                DataTable dt;
                dt = ds.Tables[Table];
                conn.Close();
                conn.Dispose();
                da.Dispose();
                return dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }

        internal static bool database_update(string Address, string Table,DataTable dt)
        {
            try
            {
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = @"Select * from " + Table;
                OleDbDataAdapter da = new OleDbDataAdapter(strcomm, conn);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);
                //dt.DataSet
                //da.FillSchema(ds, SchemaType.Source, Table);
                //da.Fill(ds, Table);
                //DataTable dt;
                var num = da.Update(dt.DataSet, Table);
                //da.
                //dt = ds.Tables[Table];
                conn.Close();
                conn.Dispose();
                da.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        internal static bool database_update(string Address, string Table, DataRow[] dra)
        {
            try
            {
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = @"Select * from " + Table;
                OleDbDataAdapter da = new OleDbDataAdapter(strcomm, conn);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);
                //dt.DataSet
                //da.FillSchema(ds, SchemaType.Source, Table);
                //da.Fill(ds, Table);
                //DataTable dt;

                var temp = da.Update(dra);
                //da.
                //dt = ds.Tables[Table];
                conn.Close();
                conn.Dispose();
                da.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        internal static void database_update(string Address, string Table, DataTable dt,string Condition, string Content)
        {
            try
            {
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                string strcomm = @"Select * from " + Table + " where " + Condition + "='" + Content + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(strcomm, conn);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);
                //dt.DataSet
                //da.FillSchema(ds, SchemaType.Source, Table);
                //da.Fill(ds, Table);
                //DataTable dt;
                //da.Update(dt.DataSet, Table);
                var temp = da.Update(dt);
                //da.
                //dt = ds.Tables[Table];
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
        internal static bool database_update(string Address, string Table,string SearchCondition1,string username,string SearchTarget,string TargetContent)
        {
            try
            {
                //string s2 = "SELECT * FROM " + Table + " WHERE ((" + c1 + " = '" + username.Trim() + "') AND (" + c2 + " = '" + pw.Trim() + "'))";
                //string s2 = "SELECT "+c3+" FROM " + Table + " WHERE " + c1 + " = '" + username.Trim() + "'";
                //string s2 = "SELECT " + SearchTarget + " FROM " + Table + " WHERE " + SearchCondition1 + " = '" + username.Trim() + "'";
                string s2 = "update " + Table + " set " + SearchTarget + " = '" + TargetContent.Trim() + "' where " + SearchCondition1 + " = '" + username + "'"; 
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection scon = new OleDbConnection(strconn);
                scon.Open();
                //oledbd
                //OleDbCommand scmd = new OleDbCommand(s2, scon);
                OleDbCommand oc = new OleDbCommand(s2, scon);
                oc.ExecuteNonQuery();
                //OleDbDataAdapter da = new OleDbDataAdapter(s2, scon);
                //OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                ////olda.Update()
                //DataTable dt = ds.Tables[Table];
                //dt.Rows[0][0] = TargetContent;
                //da.Update(ds, Table);
                //var c = dt.ToString();
                //scmd.
                //OleDbDataReader sda = scmd.ExecuteReader(,);
                //scmd.
                //if (sda.Read())
                //{
                //    //Response.Redirect("list.aspx");
                //    //MessageBox.Show("successful");
                //    return 1;
                //}
                //else
                //{
                //    MessageBox.Show("username or password wrong!");
                //    return 0;
                //}
                //sda.Close();
                scon.Close();
                scon.Dispose();
                //return Convert.ToInt32(temp);
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        internal static bool database_check(string Address, string Table, string username, string pw, string SearchCondition1, string SearchCondition2)
        {
            //database_sea()
            try
            {
                string s2 = "SELECT * FROM " + Table + " WHERE ((" + SearchCondition1 + " = '" + username.Trim() + "') AND (" + SearchCondition2 + " = '" + pw.Trim() + "'))";
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";

                OleDbConnection scon = new OleDbConnection(strconn);
                OleDbCommand scmd = new OleDbCommand(s2, scon);
                scon.Open();
                OleDbDataReader sda = scmd.ExecuteReader();
                if (sda.Read())
                {
                    //Response.Redirect("list.aspx");
                    //MessageBox.Show("successful");
                    sda.Close();
                    scon.Close();
                    scon.Dispose();
                    return true;
                }
                else
                {
                    //MessageBox.Show("Username or Password is wrong!");
                    sda.Close();
                    scon.Close();
                    scon.Dispose();
                    return false;
                }
                sda.Close();
                scon.Close();
                scon.Dispose();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        internal static int database_search(string Address, string Table, string username, string pw, string SearchCondition1, string SearchCondition2, string SearchTraget)
        {
            try
            {
                //string s2 = "SELECT * FROM " + Table + " WHERE ((" + c1 + " = '" + username.Trim() + "') AND (" + c2 + " = '" + pw.Trim() + "'))";
                //string s2 = "SELECT "+c3+" FROM " + Table + " WHERE " + c1 + " = '" + username.Trim() + "'";
                string s2 = "SELECT "+ SearchTraget + " FROM " + Table + " WHERE ((" + SearchCondition1 + " = '" + username.Trim() + "') AND (" + SearchCondition2 + " = '" + pw.Trim() + "'))";
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";

                OleDbConnection scon = new OleDbConnection(strconn);
                
                scon.Open();
                //oledbd
                //OleDbCommand scmd = new OleDbCommand(s2, scon);
                OleDbDataAdapter olda = new OleDbDataAdapter(s2, scon);
                DataSet ds = new DataSet();
                olda.Fill(ds);
                //olda.Update()
                DataTable dt = ds.Tables[0];
                var temp = dt.Rows[0][0];
                //var c = dt.ToString();
                //scmd.
                //OleDbDataReader sda = scmd.ExecuteReader(,);
                //scmd.
                //if (sda.Read())
                //{
                //    //Response.Redirect("list.aspx");
                //    //MessageBox.Show("successful");
                //    return 1;
                //}
                //else
                //{
                //    MessageBox.Show("username or password wrong!");
                //    return 0;
                //}
                //sda.Close();
                scon.Close();
                scon.Dispose();
                return Convert.ToInt32(temp);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return 0;
            }
        }
        internal static bool database_check2(string Address, string Table, string username, string pw, string SearchCondition1, string SearchCondition2)
        {
            try
            {
                //string s2 = "SELECT * FROM " + Table + " WHERE ((" + c1 + " = '" + username.Trim() + "') AND (" + c2 + " = '" + pw.Trim() + "'))";
                //string s2 = "SELECT "+c3+" FROM " + Table + " WHERE " + c1 + " = '" + username.Trim() + "'";
                string s2 = string.Format("select {0} from {1} where ({2} = '{3}')", SearchCondition2, Table, SearchCondition1, username.Trim());
                    //"SELECT " + TargetName + " FROM " + Table + " WHERE ((" + KeyName + " = '" + KeyValue.Trim() + "') AND (" + SearchCondition2 + " = '" + pw.Trim() + "'))";
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";

                OleDbConnection scon = new OleDbConnection(strconn);
                scon.Open();
                OleDbDataAdapter olda = new OleDbDataAdapter(s2, scon);
                DataSet ds = new DataSet();
                olda.Fill(ds);
                DataTable dt = ds.Tables[0];
                var temp = dt.Rows[0][0];
                scon.Close();
                scon.Dispose();
                return temp.Equals(pw);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        internal static bool database_add_newUser(string Address, string Table, DataRow dr)
        {
            try
            {
                string temp = "'" + dr[0] + "'";
                for (int i = 1; i < dr.ItemArray.Length - 4; i++)
                {
                    temp = temp + ",'" + dr[i] + "'";
                }
                temp += ",'','0','0','0'";
                string UserInfo = "insert into " + Table + " values(" + temp + ")";
                string strconn = @"Provider=Microsoft.Ace.OLEDB.12.0; Data Source='" + Address + "';";
                OleDbConnection conn = new OleDbConnection(strconn);
                conn.Open();
                OleDbCommand scmd = new OleDbCommand(UserInfo, conn);
                if (scmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                else
                {
                    conn.Close();
                    conn.Dispose();
                    return false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
    }
}
