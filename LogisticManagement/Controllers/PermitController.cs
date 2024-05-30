using System.Security.Claims;
using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete;
using LogisticManagement.Entity;
using LogisticManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LogisticManagement.Controllers
{
	[Authorize]
	public class PermitController : Controller
	{
		private readonly IPermitRepository _permitRepository;
		private readonly IUserRepository _userRepository;
		public PermitController(IPermitRepository permitRepository,IUserRepository userRepository)
		{
			_userRepository = userRepository;
			_permitRepository = permitRepository;
		}
        [Authorize(Roles = "admin")]
        [HttpGet]
		public IActionResult Index()
		{
			var permitList = _permitRepository.Permits.Include(x=>x.User).ToList();
			return View(permitList);
		}
		[Authorize]
		[HttpGet]
        public IActionResult AddPermit()
        {
			string userName = User.Identity.Name;
			var kullanici = _userRepository.Users.FirstOrDefault(x => x.UserName == userName);
			ViewBag.kalanIzin = kullanici.PermitRemaining;
            return View();
        }
		[HttpPost]
		public IActionResult AddPermit(Permit permit)
		{
			string userName = User.Identity.Name;
            var kullanici = _userRepository.Users.FirstOrDefault(x => x.UserName == userName);
			var totaldate = permit.PermitFinish.Date - permit.PermitStart.Date;
			permit.UserId = kullanici.UserId;
			var totalDate = int.Parse(totaldate.Days.ToString());
            _permitRepository.Insert(permit);
			return RedirectToAction("AddPermit");
		}
		[Authorize(Roles ="admin")]
		[HttpGet]
		public IActionResult PermitEditConfirm(int id)
		{
			var permit = _permitRepository.GetById(id);
			int user = permit.User.UserId;
			var kullanici = _userRepository.Users.FirstOrDefault(x => x.UserId == user);
			var permitUserRemaining = kullanici.PermitRemaining;
			ViewBag.UserPermitRemaining = permitUserRemaining;
			return View(permit);
		}
		[HttpPost]
		public IActionResult PermitEditConfirm(Permit editPermit)
		{
			int user = editPermit.User.UserId;
			var kullanici = _userRepository.Users.FirstOrDefault(x => x.UserId == user);
			var editKullanici = _userRepository.GetUserById(user);
			DateTime start = editPermit.PermitStart.Date;
			DateTime finish = editPermit.PermitFinish.Date;

			var updatedPermitDays = (finish - start).Days;
			var totalRemainingPermits = kullanici.PermitRemaining;
			var recordPermit = _permitRepository.GetById(editPermit.PermitId);

			if (totalRemainingPermits >= updatedPermitDays)
			{
				editKullanici.PermitRemaining -= updatedPermitDays;
				editPermit.UserId = user;
				recordPermit.Description = editPermit.Description;
				recordPermit.IsApproval = editPermit.IsApproval;
				recordPermit.PermitType = editPermit.PermitType;
				recordPermit.PermitStart = editPermit.PermitStart;
				recordPermit.PermitFinish = editPermit.PermitFinish;
				recordPermit.PermitId = editPermit.PermitId;
				_userRepository.Update(editKullanici);
				_permitRepository.Update(recordPermit);
			}
			else
			{

			}
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> GetUserPermitsAll()
		{
			int currentUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			if (currentUser == null)
			{
				return NotFound();
			}

			var permits = _permitRepository.GetByUser(currentUser);
			return View(permits);


		}

	}
}
