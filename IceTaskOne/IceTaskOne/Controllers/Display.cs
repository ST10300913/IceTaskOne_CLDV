using Microsoft.AspNetCore.Mvc;

namespace IceTaskOne.Controllers
{
    public class Display : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //to display images.
        public IActionResult DisplayImage(String imageName)
        {
            var imagePath = Path.Combine("/Images", imageName);
            return File(imagePath, "image/jpeg");
        }



    }
}
