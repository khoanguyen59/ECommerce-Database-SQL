using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Orders
        public ActionResult Index()
        {
            var OrdersList = db.Orders;
            return View(OrdersList);
        }
        public ActionResult Insert(Models.Order model)
        {

            SqlConnection cnn = new SqlConnection("data source=DESKTOP-CI6H5AL;initial catalog=ECommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.p_ecommerce_add_new_order";
                //add any parameters the stored procedure might require
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@customermail", model.order_customer_mail));
                    cmd.Parameters.Add(new SqlParameter("@date", model.order_date));
                    cmd.Parameters.Add(new SqlParameter("@shipvia", model.order_shipvia));
                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();
                }
                catch { }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var model = db.Orders.Find(id);
                db.Orders.Remove(model);
                db.SaveChanges();
                ModelState.AddModelError("", "Deleted");
            }
            catch
            {
                ModelState.AddModelError("", "Error");
            }
            return RedirectToAction("Index");
        }
        /*public ActionResult Edit(int id, Models.Order model)
        {
            var temp = db.Orders.Find(id);

            SqlConnection cnn = new SqlConnection("data source=DESKTOP-E4T8N80\SQL1710136;initial catalog=ECommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.p_ecommerce_update_order";
                //add any parameters the stored procedure might require
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@id", temp));
                    cmd.Parameters.Add(new SqlParameter("@customermail", model.order_customer_mail));
                    cmd.Parameters.Add(new SqlParameter("@date", model.order_date));
                    cmd.Parameters.Add(new SqlParameter("@shipvia", model.order_shipvia));
                    cmd.Parameters.Add(new SqlParameter("@state", model.order_status));

                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();
                }
                catch { }
            }
            return View();
        }*/
        public ActionResult Edit(int id, Models.Order model)
        {
            //ViewBag.Order = db.Orders.Find(id).order_id;


            SqlConnection cnn = new SqlConnection("data source==DESKTOP-CI6H5AL;initial catalog=ECommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Order_id", id));
                cmd.Parameters.Add(new SqlParameter("@customermail", model.order_customer_mail));
                cmd.Parameters.Add(new SqlParameter("@date", model.order_date));
                cmd.Parameters.Add(new SqlParameter("@shipvia", model.order_shipvia));
                cmd.Parameters.Add(new SqlParameter("@state", model.order_status));


                //add any parameters the stored procedure might require
                try
                {
                    cmd.CommandText = "UPDATE Orders SET order_customer_mail = @customermail " +
                    ", order_date = @date " +
                    ", order_shipvia = @shipvia" +
                    ", order_status = @state" +
                    " WHERE order_id = @Order_id";

                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();
                }
                catch
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            return View();
        }
    }
}