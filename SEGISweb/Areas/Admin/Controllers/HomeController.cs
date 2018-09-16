using SEGISweb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEGISweb.Areas.Admin.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Location()
        {
            string markers = "[";
            string CS = ConfigurationManager.ConnectionStrings["SEDbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    markers += "{";
                    markers += string.Format("'title': '{0}',", sdr["CityName"]);
                    markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                    markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                    markers += string.Format("'description': '{0}',", sdr["Description"]);


                    //markers += string.Format("'pipLat_1': '{0}',", sdr["PIPE_Latitude_1"]);
                    //markers += string.Format("'pipLat_2': '{0}',", sdr["PIPE_Latitude_2"]);
                    //markers += string.Format("'pipLng_1': '{0}',", sdr["PIPE_Longitude_1"]);
                    //markers += string.Format("'pipLng_2': '{0}',", sdr["PIPE_Longitude_2"]);

                    markers += "},";
                }
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
        //insert data
        [HttpPost]
        public ActionResult Location(Locations location)
        {
            if (ModelState.IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["SEDbContext"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewLocation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@CityName", location.CityName);
                    cmd.Parameters.AddWithValue("@Latitude", location.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", location.Longitude);
                    cmd.Parameters.AddWithValue("@Description", location.Description);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {

            }
            return RedirectToAction("Location");
        }
    }
}