using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        public ProductController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }
     
    }
}
