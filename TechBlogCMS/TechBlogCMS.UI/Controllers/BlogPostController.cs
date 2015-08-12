using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.BLL;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class BlogPostController : Controller
    {
        // GET: BlogPost
        public ActionResult ShowAllBlogPost()
        {
            var model = new BlogPostAllVM();

            var categoryOps = OperationsFactory.CreateCategoryOps();
            var hashtagOps = OperationsFactory.CreateHashtagOps();
            var categoriesList = categoryOps.ListAllCategories();
            var hashtagsList = hashtagOps.ListAllHashtags();
            var ops = OperationsFactory.CreateBlogPostOps();

            model.BlogPosts = ops.GetAllBlogPosts();
            model.GenerateCategoriesList(categoriesList);
            model.GenerateHashtagsList(hashtagsList);

            return View(model);
        }

        [HttpPost]
        public ActionResult ShowAllBlogPost(BlogPostAllVM model)
        {
            var categoryId = model.SelectedCategoryId;
            var hashtagId = model.SelectedHashtagId;
            var categoryOps = OperationsFactory.CreateCategoryOps();
            var hashtagOps = OperationsFactory.CreateHashtagOps();
            var ops = OperationsFactory.CreateBlogPostOps();
            if (categoryId != 0)
            {
                model.BlogPosts = ops.ListAllBlogsInCategoryByCategoryId(categoryId);
                model.SelectedCategoryName =
                    categoryOps.ListAllCategories().FirstOrDefault(x => x.CategoryID == categoryId).CategoryType;
            }
            else
            {
                model.BlogPosts = ops.ListAllBlogsByHashTag(hashtagId);
                model.SelectedHashtagName =
                  hashtagOps.ListAllHashtags().FirstOrDefault(x => x.HashtagID == hashtagId).HashtagType;
            }

            return View(model);
        }



        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
