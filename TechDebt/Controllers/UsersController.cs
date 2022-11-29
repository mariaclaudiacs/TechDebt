using Microsoft.AspNetCore.Mvc;
using TechDebt.Models;
using TechDebt.Utils.Entities;

namespace TechDebt.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var model = new UsersModel();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new UsersModel();
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel userModel)
        {
            var user = new User()
            {
                Id = userModel.Id,
                Nome = userModel.Nome,
                Senha = userModel.Senha,
                Email = userModel.Email
            };
            // Criar Usuário
            user.Create();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var user = new User(id);
            var model = new UserModel(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UserModel model)
        {
            var user = model.GenerateUser();
            user.Update();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = new User(id);
            var model = new UserModel(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(UserModel model)
        {
            var user = model.GenerateUser();
            user.Delete();

            return RedirectToAction("Index");
        }
    }
}
