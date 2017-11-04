using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _employee;
    private string _details;
    private int _id;

    public Stylist(string employee, string details, int id = 0)
    {
      _employee = employee;
      _details = details;
      _id = id;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        return this.GetId().Equals(newStylist.GetId());
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public string GetEmployee()
    {
      return _employee;
    }
    public string GetDetails()
    {
      return _details;
    }
    public int GetId()
    {
      return _id;
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistEmployee = rdr.GetString(1);
        string stylistDetails = rdr.GetString(2);
        Stylist newStylist = new Stylist(stylistEmployee, stylistDetails, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (employee, details) VALUES (@employee, @details);";

      MySqlParameter employee = new MySqlParameter();
      employee.ParameterName = "@employee";
      employee.Value = this._employee;
      cmd.Parameters.Add(employee);

      MySqlParameter details = new MySqlParameter();
      details.ParameterName = "@details";
      details.Value = this._details;
      cmd.Parameters.Add(details);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
