using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Objednávky
{
    class Hlášení
    {
        static void Main(string[] args)
        {
            SqlConnection datovéPřipojení = new SqlConnection();
            try
            {
                datovéPřipojení.ConnectionString =
                   "Integrated Security=true;Initial Catalog=Northwind;" +
                   "Data Source=Lukáš-PC\\SQLExpress";
                datovéPřipojení.Open();
                Console.Write("Zadejte prosím ID zákazníka (5 znaků): ");
                string idZákazníka = Console.ReadLine();
                SqlCommand datovýPříkaz = new SqlCommand();
                datovýPříkaz.Connection = datovéPřipojení;
                datovýPříkaz.CommandText =
                   "SELECT OrderID, OrderDate, ShippedDate, ShipName, " +
                   "ShipAddress, ShipCity, ShipCountry " +
                   "FROM Orders WHERE CustomerID='" + idZákazníka + "'";
                Console.WriteLine("Bude provedeno: {0}\n\n",
                   datovýPříkaz.CommandText);
                SqlDataReader datovýSnímač = datovýPříkaz.ExecuteReader();
                while (datovýSnímač.Read())
                {
                    int idObjednávky = datovýSnímač.GetInt32(0);
                    if (datovýSnímač.IsDBNull(2))
                    {
                        Console.WriteLine("Objednávka {0} zatím nebyla doručena\n\n",
                           idObjednávky);
                    }
                    else
                    {                        
                        DateTime datumObjednávky = datovýSnímač.GetDateTime(1);
                        DateTime datumDoručení = datovýSnímač.GetDateTime(2);
                        string jménoDoručení = datovýSnímač.GetString(3);
                        string adresaDoručení = datovýSnímač.GetString(4);
                        string městoDoručení = datovýSnímač.GetString(5);
                        string zeměDoručení = datovýSnímač.GetString(6);
                        Console.WriteLine(
                           "Objednávka: {0}\nVystavená: {1}\nDoručená: {2}\n" +
                           "Na adresu: {3}\n{4}\n{5}\n{6}\n\n", idObjednávky,
                           datumObjednávky, datumDoručení, jménoDoručení,
                           adresaDoručení, městoDoručení, zeměDoručení);
                    }
                }
                datovýSnímač.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Chyba při přístupu do databáze: {0}", e.Message);
            }
            finally
            {
                datovéPřipojení.Close();
            } 
        }
    }
}
