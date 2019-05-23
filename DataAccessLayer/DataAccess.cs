using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using DataAccessLayer;

public class DataAccess
{
    private static string str2 = ConnectionDB.ConnectionString;
    SqlConnection conn = new SqlConnection(str2);
    public DataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Get DataTable by ArrayList
    /// </summary>
    /// <param name="SP"></param>
    /// <param name="FieldName"></param>
    /// <param name="FieldType"></param>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public DataTable GetDataTable(string SP, ArrayList FieldName, ArrayList FieldType, ArrayList FieldValue)
    {
        SqlConnection conn = new SqlConnection(str2);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int f = 0; f < FieldName.Count; f++)
            {
                cmd.Parameters.AddWithValue("@" + FieldName[f].ToString(), "SqlDbType." + FieldType[f].ToString()).Value = FieldValue[f];
            }
            cmd.Prepare();
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }    

    /// <summary>
    /// Get Data Table by Stored Procedure
    /// </summary>
    /// <param name="SP"></param>
    /// <returns></returns>
    public DataTable GetDataTable(string SP)
    {
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            //clsException obj_Exception = new clsException(); obj_Exception.ExceptionEntryTo_Log_Email(ex, ""); 
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    /// <summary>
    /// Get Data Table by 1 string and 1 int Input Parameter
    /// </summary>
    /// <param name="SP"></param>
    /// <param name="Field"></param>
    /// <param name="Value"></param>
    /// <returns></returns>
    public DataTable GetDataTable(string SP, string Field, int Value)
    {
        SqlConnection conn = new SqlConnection(str2);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@" + Field, SqlDbType.Int).Value = Value;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    /// <summary>
    /// Get Data Table by 2 string Field and 2 int Value 
    /// </summary>
    /// <param name="SP"></param>
    /// <param name="Field1"></param>
    /// <param name="Field2"></param>
    /// <param name="Value1"></param>
    /// <param name="Value2"></param>
    /// <returns></returns>
    public DataTable GetDataTable(string SP, string Field1, string Field2, int Value1, int Value2)
    {
        SqlConnection conn = new SqlConnection(str2);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@" + Field1, SqlDbType.Int).Value = Value1;
            cmd.Parameters.Add("@" + Field2, SqlDbType.Int).Value = Value2;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    public DataTable GetDataTable(string SP, string Field1, string Field2, string Value1, int Value2)
    {
        SqlConnection conn = new SqlConnection(str2);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@" + Field1, SqlDbType.NVarChar).Value = Value1;
            cmd.Parameters.Add("@" + Field2, SqlDbType.Int).Value = Value2;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    public DataTable GetDataTable(string SP, string Field, string Value)
    {
        SqlConnection conn = new SqlConnection(str2);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@" + Field, SqlDbType.VarChar).Value = Value;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    public DataTable GetDataTableByQuery(string TextCommand)
    {
        SqlConnection conn = new SqlConnection(str2);
        SqlCommand cmd = new SqlCommand(TextCommand, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.Text;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }
    public DataTable GetDataTable(string SP, string Field, string Field1, string Value, string Value1)
    {
        SqlConnection conn = new SqlConnection(str2);
        //SqlConnection conn = new SqlConnection(Connection.ConnectionString);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@" + Field, SqlDbType.VarChar).Value = Value;
            cmd.Parameters.Add("@" + Field1, SqlDbType.VarChar).Value = Value1;
            da.Fill(dt);
            return dt;
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    /// <summary>
    /// Get Data Set by Stored Proc
    /// </summary>
    /// <param name="SP"></param>
    /// <returns></returns>
    public DataSet GetDataSet(string SP)
    {
        SqlConnection conn = new SqlConnection(str2);
        //SqlConnection conn = new SqlConnection(Connection.ConnectionString);
        SqlCommand cmd = new SqlCommand(SP, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            return ds;
        }
        catch (SqlException)
        {
            return ds;
        }
        finally
        {
            da.Dispose();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }
}