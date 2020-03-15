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
    public class ReviewController : Controller
    {
        // GET: Review
        Models.Model1 db = new Models.Model1();
        public ActionResult Index()
        {
            var productList = db.Reviews;
            return View(productList);
        }

        public ActionResult Insert(Models.Review model)
        {
            SqlConnection cnn = new SqlConnection("data source=DESKTOP-CI6H5AL;initial catalog=ECommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.add_review";
                //add any parameters the stored procedure might require
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@review_rating_add", model.review_rating));
                    cmd.Parameters.Add(new SqlParameter("@review_comment_add", model.review_comment));
                    cmd.Parameters.Add(new SqlParameter("@review_picture_add", model.review_picture));
                    cmd.Parameters.Add(new SqlParameter("@review_customer_mail_add", model.review_customer_mail));
                    cmd.Parameters.Add(new SqlParameter("@review_product_id_add", model.review_product_id));
                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();
                }
                catch { }
            }
            return View();
        }

        public ActionResult Delete(int num_no)
        {
            try
            {
                var model = db.Reviews.Find(num_no);
                db.Reviews.Remove(model);
                db.SaveChanges();
                ModelState.AddModelError("", "Deleted");
            }
            catch
            {
                ModelState.AddModelError("", "Error");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int num_no, Models.Review model)
        {
            ViewBag.Review = db.Reviews.Find(num_no).review_comment.ToString();
            SqlConnection cnn = new SqlConnection("data source=DESKTOP-CI6H5AL;initial catalog=ECommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@rating", model.review_rating));
                cmd.Parameters.Add(new SqlParameter("@comment", model.review_comment));
                cmd.Parameters.Add(new SqlParameter("@no", num_no));
                //add any parameters the stored procedure might require
                try
                {
                    cmd.CommandText = "UPDATE Product SET review_rating = @rating" +
                        ", review_comment = @comment" +
                        "WHERE review_no = @no";
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