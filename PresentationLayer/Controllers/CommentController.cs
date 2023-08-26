using AspNetCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
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
        public async Task<IActionResult> ListComment(ListCommentQueryRequest listCommentQueryRequest)
        {
            ListCommentQueryResponse response = await _mediator.Send(listCommentQueryRequest);
            ListCommentVM listCommentVM = _mapper.Map<ListCommentVM>(response);
            return View(listCommentVM);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommandRequest createCommentCommandRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            createCommentCommandRequest.UserId = user.Id;
            createCommentCommandRequest.UserFirstname = user.FirstName;
            createCommentCommandRequest.UserLastname = user.LastName;
            CreateCommentCommandResponse response = await _mediator.Send(createCommentCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Added comment");

            return RedirectToAction("Details", "Shop", new ShopDetailsQueryRequest() { Url = response.Url});
        }

        [HttpGet]
        public async Task<IActionResult> EditComment(EditCommentQueryRequest editCommentQueryRequest) 
        {
            EditCommentQueryResponse response = await _mediator.Send(editCommentQueryRequest);
            EditCommentVM editCommentVM = _mapper.Map<EditCommentVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(editCommentVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditComment(EditCommentCommandRequest editCommentCommandRequest)
        {
            EditCommentCommandResponse response = await _mediator.Send(editCommentCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Comment updated!");

            return RedirectToAction("ListComment", "Comment");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(DeleteCommentCommandRequest deleteCommentCommandRequest) 
        {
            DeleteCommentCommandResponse response = await _mediator.Send(deleteCommentCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Comment deleted!");

            return RedirectToAction("ListComment","Comment");
        }
    }
}
