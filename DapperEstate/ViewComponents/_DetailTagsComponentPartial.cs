using DapperEstate.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperEstate.ViewComponents
{
    public class _DetailTagsComponentPartial : ViewComponent
    {
        private readonly ITagService _tagService;

        public _DetailTagsComponentPartial(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _tagService.TagListByProductAsync(id);
            return View(values);
        }
    }
}
