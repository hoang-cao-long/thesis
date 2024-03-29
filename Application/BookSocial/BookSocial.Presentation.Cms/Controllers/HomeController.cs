﻿using AutoMapper;
using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Cms.Controllers
{
    [Authorize(Policy = "All")]
    public partial class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        private readonly IUserService _userService;
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly IAuthorService _authorService;
        private readonly IAuthorBookService _authorBookService;
        private readonly IShelfService _shelfService;
        private readonly IReviewService _reviewService;
        private readonly IFriendService _friendService;

        public HomeController(
            IMapper mapper,

            IUserService userService,
            IGenreService genreService,
            IBookService bookService,
            ICommentService commentService,
            IAuthorService authorService,
            IAuthorBookService authorBookService,
            IShelfService shelfService,
            IReviewService reviewService,
            IFriendService friendService)
        {
            _mapper = mapper;

            _userService = userService;
            _genreService = genreService;
            _bookService = bookService;
            _commentService = commentService;
            _authorService = authorService;
            _authorBookService = authorBookService;
            _shelfService = shelfService;
            _reviewService = reviewService;
            _friendService = friendService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult ChangePassword()
        {
            return View("~/Views/Home/ChangePassword.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var user = await _userService.GetById(Convert.ToInt32(userIdClaim));
            if (user.Password != changePassword.OldPassword)
            {
                ModelState.AddModelError("OldPassword", "Mật khẩu cũ không khớp");
            }
            if (ModelState.IsValid)
            {
                user.Password = changePassword.NewPassword;
                int result = await _userService.Update(user);
                if (result != 0)
                {
                    TempData["Success"] = "Cập nhật mật khẩu thành công!";
                }
                else
                {
                    TempData["Fail"] = "Cập nhật mật khẩu thất bại!";
                }
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Home/ChangePassword.cshtml");
        }
    }
}