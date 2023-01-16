﻿using BlogProjectExam.Filters;
using BlogProjectExam.Models;
using BlogProjectExam.Models.Data;
using BlogProjectExam.ViewModels.Home.Overview;
using BlogProjectExam.ViewModels.Home.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<ArticleViewModel> list = _context.Articles.OrderByDescending(x => x.CreatedTime)
                                          .Take(20)
                                          .Select(x => new ArticleViewModel()
                                          {
                                              Id= x.Id,
                                              AuthorId=x.Author.Id.ToString(),
                                              AuthorName=x.Author.Username,
                                              ArticlePicture = string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture,
                                              Title=x.Title,
                                              Content=x.Content,
                                              CreatedTime=x.CreatedTime
                                          }).ToList();
            return View(list);
        }
        [HttpGet("[controller]/[action]/{email}")]
        public IActionResult Profile(string email)
        {
            List<ArticleViewModel> list = _context.Articles
                .Where(x => x.Author.Email.Equals(email))
                .OrderByDescending(x=> x.CreatedTime)
                .Select(x=> new ArticleViewModel()
                {
                    Id= x.Id,
                    AuthorId=x.Author.Id.ToString(),
                    AuthorName=x.Author.Username,
                    ArticlePicture = string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture,
                    Title=x.Title,
                    Content=x.Content,
                    CreatedTime=x.CreatedTime
                }).ToList();
            return View(list);
        }
        public IActionResult Overview(int id)
        {
            var model = _context.Articles.Select(x => new OverviewViewModel()
            {
                Id = x.Id,
                Author = x.Author.Username,
                ArticlePicture = string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture,
                Title = x.Title,
                Content = x.Content,
                CreatedTime = x.CreatedTime
            }).FirstOrDefault(x => x.Id.Equals(id));

            return View(model);
        }
        [LoggedUser]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
