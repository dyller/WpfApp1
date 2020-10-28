using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace APIDebitoner.DAL
{
    public class DebitonerDAL
    {
        string cs = "Data Source=LAPTOP-LN3SHEJ1;Initial Catalog=Test;integrated security=true";
        public List<Debitoner> GetAllDebitoner()
        {
            try
            {
                List<Debitoner> debitonersList = new List<Debitoner>();
                
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Debitoner", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var debitioner = new Debitoner();

                        debitioner.DebitonerID = Convert.ToInt32(rdr["DebitonerID"]);
                        debitioner.DebitonerName = rdr["DebitonerName"].ToString();
                        debitonersList.Add(debitioner);
                    }
                    
                }
                return debitonersList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error in databse: " + ex.Message);
            }

        }
        public Debitoner GetDebitonerById(int debitonerId)
        {
            try
            {
                Debitoner debitoner = new Debitoner();
                List<Varer> VarerList = new List<Varer>();
                List<OrderLinjer> OrderLinjerList = new List<OrderLinjer>();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand($@"SELECT * 
                                                    FROM varer b
                                                    LEFT JOIN Debitoner e On e.DebitonerID = b.DebitonerID
                                                    WHERE b.DebitonerID = {debitonerId}", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var varer = new Varer();

                        varer.Price = Convert.ToInt32(rdr["Price"]);
                        varer.Name = rdr["Name"].ToString();
                        if (debitoner.DebitonerID == 0 || string.IsNullOrEmpty(debitoner.DebitonerName))
                        debitoner.DebitonerID = Convert.ToInt32(rdr["DebitonerId"]);
                        debitoner.DebitonerName = rdr["DebitonerName"].ToString();
                        VarerList.Add(varer);
                        
                    }
                    debitoner.Varer = VarerList.ToArray();
                    con.Close();

                    cmd = new SqlCommand($@"SELECT * 
                                                    FROM OrderLinjer b
                                                    LEFT JOIN Debitoner e On e.DebitonerID = b.DebitonerID
                                                    WHERE b.DebitonerID = {debitonerId}", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var orderLinjer = new OrderLinjer();

                        orderLinjer.Date = Convert.ToDateTime(rdr["Date"]);
                        orderLinjer.Name = rdr["Name"].ToString();
                        OrderLinjerList.Add(orderLinjer);

                    }
                    debitoner.OrderLinjer = OrderLinjerList.ToArray();
                    con.Close();

                }
                return debitoner;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error in databse: " + ex.Message);
            }

        }
    }
}
