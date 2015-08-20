using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.BLL;
using TechBlogCMS.Models;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class DisplayBlogPostsController : Controller
    {
        public ActionResult ShowAllBlogPost()
        {
            var model = new BlogPostAllVM();

            var categoryOps = OperationsFactory.CreateCategoryOps();
            var hashtagOps = OperationsFactory.CreateHashtagOps();
            var categoriesList = categoryOps.ListAllCategories();
            var hashtagsList = hashtagOps.ListAllHashtags();
            var ops = OperationsFactory.CreateBlogPostOps();

            model.BlogPosts =
                ops.GetAllBlogPosts()
                    .FindAll(x => x.Status.StatusID == 2)
                    .FindAll(x => x.DateOfPost <= DateTime.Today)
                    .OrderByDescending(x => x.DateOfPost)
                    .ToList();
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
                model.BlogPosts = ops.ListAllBlogsInCategoryByCategoryId(categoryId).FindAll(x => x.Status.StatusID == 2)
                    .FindAll(x => x.DateOfPost <= DateTime.Today)
                    .OrderByDescending(x => x.DateOfPost)
                    .ToList();
                var firstOrDefault = categoryOps.ListAllCategories().FirstOrDefault(x => x.CategoryID == categoryId);
                if (firstOrDefault != null)
                    model.SelectedCategoryName =
                        firstOrDefault.CategoryType;
            }
            else
            {
                model.BlogPosts = ops.ListAllBlogsByHashTag(hashtagId).FindAll(x => x.Status.StatusID == 2)
                    .FindAll(x => x.DateOfPost <= DateTime.Today)
                    .OrderByDescending(x => x.DateOfPost)
                    .ToList();
                var firstOrDefault = hashtagOps.ListAllHashtags().FirstOrDefault(x => x.HashtagID == hashtagId);
                if (firstOrDefault != null)
                    model.SelectedHashtagName =
                        firstOrDefault.HashtagType;
            }

            return View(model);
        }

        public ActionResult ShowSinglePost(int id)
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var commentOps = OperationsFactory.CreateCommentOps();

            var singlePostVM = new SingleBlogPostVM()
            {
                NewComment = new Comment()
            };
            singlePostVM.SelectedBlogPost = ops.GetBlogPostById(id);
            singlePostVM.Comments = commentOps.GetAllCommentsByBlogPostID(id).FindAll(x=>x.Status.StatusID == 2);
            return View(singlePostVM);
        }

        [HttpPost]
        public ActionResult PostNewComment(SingleBlogPostVM model)
        {
            var ops = OperationsFactory.CreateCommentOps();
            model.NewComment.DateOfComment = DateTime.Now;
            model.NewComment.Status = new Status() { StatusID = 1 };
            ops.CreateComment(model.NewComment);

            return RedirectToAction("ShowSinglePost", new {id=model.NewComment.BlogPostID});
        }
    }
}