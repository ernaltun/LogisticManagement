using LogisticManagement.Data.Abstract;
using LogisticManagement.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LogisticManagement.ViewComponents
{
    public class NewMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
