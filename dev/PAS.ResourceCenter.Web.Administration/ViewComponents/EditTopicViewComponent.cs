using Microsoft.AspNetCore.Mvc;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties;

namespace PAS.ResourceCenter.Web.Administration.ViewComponents
{
    public class EditTopicViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long? topicId)
        {
            if (topicId.HasValue)
            {
                var result = CategoryDto.Get(topicId.Value);
                if (result.Status == Library.DataAccess.Responses.StatusCodes.OK)
                {
                    if (result.Items.Count > 0)
                    {
                        var item = result.First();

                        TopicViewModel model = new TopicViewModel();
                        model.TopicId = item.Id;
                        model.DisciplineId = item.ParentId;
                        model.Name = item.Name.Trim();
                        model.Enabled = item.IsEnabled;
                        model.DivEditId = "divmodaledittopic" + item.Id.ToString();
                        model.DivPurgeId = "divmodalpurgetopic" + item.Id.ToString();

                        return View(model);
                    }
                }
            }

            return View(string.Empty);
        }
    }
}
