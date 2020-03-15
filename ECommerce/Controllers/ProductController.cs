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
    public class ProductController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Product 
        public ActionResult Index(string searchTerm = "")
        {
            if (searchTerm != "")
            {
                var searchList = db.Products
                   .Where(p => p.product_name.Contains(searchTerm));
                return View(searchList);
            }
            /*var productList = new List<Models.Product>{
                            new Models.Product() { product_id = 1, product_name = "John" } ,
             
                        };*/
            var productList = db.Products;
            // Get the students from the database in the real application

            return View(productList);
        }

        public ActionResult Insert(Models.Product model)
        {
            List<Models.Category> cate = db.Categories.ToList();
            SelectList cateList = new SelectList(cate, "category_id", "category_name");
            ViewBag.CategoryList = cateList;
            SqlConnection cnn = new SqlConnection("data source=DESKTOP-CI6H5AL;initial catalog=ECommerce;integrated security=True;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.p_ecommerce_add_new_product";
                //add any parameters the stored procedure might require
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@id", model.product_id));
                    cmd.Parameters.Add(new SqlParameter("@name", model.product_name));
                    cmd.Parameters.Add(new SqlParameter("@brand", model.product_brand));
                    cmd.Parameters.Add(new SqlParameter("@category_id", model.product_categoryid));
                    cmd.Parameters.Add(new SqlParameter("@price", model.product_price));
                    cmd.Parameters.Add(new SqlParameter("@quantity", model.product_quantity));
                    cmd.Parameters.Add(new SqlParameter("@adder", model.product_adder));
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
                var model = db.Products.Find(id);
                db.Products.Remove(model);
                db.SaveChanges();
                ModelState.AddModelError("", "Deleted");
            }
            catch
            {
                ModelState.AddModelError("", "Error");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id, Models.Product model)
        {
            ViewBag.Product = db.Products.Find(id).product_name.ToString();
            List<Models.Category> cate = db.Categories.ToList();
            SelectList cateList = new SelectList(cate, "category_id", "category_name");
            ViewBag.CategoryList = cateList;
            SqlConnection cnn = new SqlConnection("data source=DESKTOP-CI6H5AL;initial catalog=ECommerce;integrated security=True;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@name", model.product_name));
                cmd.Parameters.Add(new SqlParameter("@brand", model.product_brand));
                cmd.Parameters.Add(new SqlParameter("@category_id", model.product_categoryid));
                cmd.Parameters.Add(new SqlParameter("@price", model.product_price));
                cmd.Parameters.Add(new SqlParameter("@quantity", model.product_quantity));
                cmd.Parameters.Add(new SqlParameter("@adder", model.product_adder));
                
                //add any parameters the stored procedure might require
                try
                {
                    cmd.CommandText = "UPDATE Product SET product_name = @name" +
                        ", product_brand = @brand" +
                        ", product_categoryid = @category_id" +
                        ", product_price = @price" +
                        ", product_quantity = @quantity" +
                        ", product_adder = @adder " +
                        "WHERE product_id = @id";
                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();
                }
                catch {
                    ModelState.AddModelError("", "Error");
                }
            }
            return View();
        }
    }
}