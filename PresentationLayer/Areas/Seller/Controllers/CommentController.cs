using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Enums;
using PresentationLayer.Identity;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        private readonly UserManager<User> _userManager;
        public CommentController(IMediator mediator, IMapper mapper, INotyfService notyfService, UserManager<User> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ListComment(SellerListCommentQueryRequest sellerListCommentQueryRequest)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            sellerListCommentQueryRequest.UserId = user.Id;
            SellerListCommentQueryResponse response = await _mediator.Send(sellerListCommentQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            SellerListCommentVM sellerListCommentVM = _mapper.Map<SellerListCommentVM>(response);
            return View(sellerListCommentVM);
        }

        [HttpGet]
        public async Task<IActionResult> DetailComment(SellerDetailCommentQueryRequest sellerDetailCommentQueryRequest) 
        {
            SellerDetailCommentQueryResponse response = await _mediator.Send(sellerDetailCommentQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            SellerCommentVM sellerCommentVM = _mapper.Map<SellerCommentVM>(response);
            return View(sellerCommentVM);
        }

        [HttpPost]
        public async Task<IActionResult> AnswerComment(SellerAnswerCommentCommandRequest sellerAnswerCommentCommandRequest) 
        {
            SellerAnswerCommentCommandResponse response = await _mediator.Send(sellerAnswerCommentCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Answer created!");

            return RedirectToAction("ListComment", "Comment");
        }
    }
}
