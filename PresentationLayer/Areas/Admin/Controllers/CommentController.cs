using AspNetCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public CommentController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> ListComment(ListCommentQueryRequest listCommentQueryRequest)
        {
            ListCommentQueryResponse response = await _mediator.Send(listCommentQueryRequest);
            ListCommentVM listCommentVM = _mapper.Map<ListCommentVM>(response);
            return View(listCommentVM);
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
