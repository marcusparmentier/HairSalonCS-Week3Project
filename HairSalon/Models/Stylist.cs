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
  }
}
