using MVCSBD_Sklep.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCSBD_Sklep
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Read_Visit_Count();

        }

        void Read_Visit_Count()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCSBD_Sklep.Models.XmoreltronikEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string queryString = "SELECT VisitCountNumber FROM dbo.VisitCount WHERE Id=1;";
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                var dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Application["Visitor"] = dr[0].ToString();
                    }
                }
                connection.Close();
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCSBD_Sklep.Models.XmoreltronikEntities;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string queryString = "UPDATE dbo.VisitCount SET VisitCountNumber = VisitCountNumber + 1;";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            Read_Visit_Count();
        }
    }
}
