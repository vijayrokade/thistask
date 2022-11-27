using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thistask.Models;

namespace thistask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryList()
        {
            thisclass m = new thisclass();
            m.idlist();
            m.Categorylist();

            return View(m);
        }
        public ActionResult CategoryDetails(int CategoryId = 0)
        {
            thisclass t = new thisclass();
            t.CategoryId = CategoryId;
            ViewBag.CategoryId = CategoryId;
            t.SelectCategoryDetails();
            return View("CategoryEdit",t);
        }
        public ActionResult CreateCategory(thisclass c)
        {
            try
            {
                c.insertCategory();

                Response.Redirect("/Home/CategoryList");
                ViewBag.Msg = "Record Created Succesfully";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(c);
        }
        [HttpPost]
        public ActionResult UpdateCategory(thisclass c)
        {
            try
            {
                c.UpdateCategory();

                Response.Redirect("/Home/CategoryList");
                ViewBag.Msg = "Record Created Succesfully";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(c);
        }
        public ActionResult DeleteCategory(int CategoryId = 0)
        {
            thisclass t = new thisclass();
            t.CategoryId = CategoryId;
            t.DeleteCategory();
            thisclass m = new thisclass();
            m.idlist();
            m.Categorylist();
            return View("CategoryList",m);
        }


        public ActionResult ProductList()
        {
            thisclass m = new thisclass();
            m.idlist();
            m.Productlist();

            return View(m);
        }
        public ActionResult ProductDetails(int ProductId = 0)
        {
            thisclass m = new thisclass();
            m.ProductId = ProductId;
            m.idlist();
            //ViewBag.CategoryList = m.Categorylist();
            ViewBag.ProductId = ProductId;
            m.SelectProductDetails();
            return View("ProductEdit", m);
        }
        public ActionResult CreateProduct(thisclass c)
        {
            try
            {
                c.insertProduct();

                Response.Redirect("/Home/ProductList");
                ViewBag.Msg = "Record Created Succesfully";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(c);
        }
        [HttpPost]
        public ActionResult UpdateProduct(thisclass c)
        {
            try
            {
                c.UpdateProduct();

                Response.Redirect("/Home/ProductList");
                ViewBag.Msg = "Record Created Succesfully";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View(c);
        }
        public ActionResult DeleteProduct(int ProductId = 0)
        {
            thisclass t = new thisclass();
            t.ProductId = ProductId;
            t.DeleteProduct();
            thisclass m = new thisclass();
            m.idlist();
            m.Productlist();
            return View("ProductList", m);
        }

    }
}