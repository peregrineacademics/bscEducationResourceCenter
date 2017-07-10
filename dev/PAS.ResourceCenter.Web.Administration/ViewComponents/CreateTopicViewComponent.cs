using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class CreateTopicViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long? disciplineId)
        {
            if (disciplineId.HasValue)
            {
                TopicViewModel model = new TopicViewModel();
                model.TopicId = 0;
                model.DisciplineId = disciplineId.Value;
                model.Name = string.Empty;
                model.Enabled = true;
                model.DivEditId = string.Empty;
                model.DivPurgeId = string.Empty;

                return View(model);
            }
            else
            {
                return View(string.Empty);
            }
        }        
    }
}
