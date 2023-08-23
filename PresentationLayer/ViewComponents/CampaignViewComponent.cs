using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.ViewComponents
{
    public class CampaignViewComponent: ViewComponent
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;

        public CampaignViewComponent(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            List<Campaign> campaigns = _campaignService.GetAll();
            List<HomeSliderVM> homeSliderVM = _mapper.Map<List<HomeSliderVM>>(campaigns);   
            return View(homeSliderVM);
        }
    }
}
