using System.Security.Claims;
using LogisticManagement.Data.Abstract;
using LogisticManagement.Entity;
using LogisticManagement.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace LogisticManagement.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICommentRepository _commentRepository;
        public TicketController(ITicketRepository ticketRepository, ICommentRepository commentRepository)
        {
            _ticketRepository = ticketRepository;
            _commentRepository = commentRepository;

        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _ticketRepository.Tickets.Include(x => x.User).ToListAsync());
        }
        [Authorize]
        public IActionResult AddTicket()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTicket(Ticket model)
        {
            _ticketRepository.Insert(model);
            return RedirectToAction("Index");
        }
		[Authorize]
		public async Task<IActionResult> Details(int id)
        {

            var ticket = _ticketRepository.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket = await _ticketRepository.Tickets
                                            .Include(x => x.User)
                                            .Include(x => x.Comments)
                                            .FirstOrDefaultAsync(x => x.TicketId == id);
            ViewBag.IsActiveText = ticket.IsActive.HasValue
            ? (ticket.IsActive.Value ? "Aktif" : "Pasif") : "Bilinmiyor";
            return View(ticket);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(Ticket model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _ticketRepository.Insert(
                new Ticket
                {
                    Title = model.Title,
                    Description = model.Description,
                    UserId = int.Parse(userId ?? ""),
                    PublishedOn = DateTime.Now,
                    Image = "LOGO1.jpg",
                    IsActive = true
                }
            );
            return RedirectToAction("GetTicketByCurrentUser");
        }
        [HttpPost]
        public JsonResult AddComment(int TicketId, string UserName, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                TicketId = TicketId,
                UserId = int.Parse(userId)
            };
            _commentRepository.CreateComment(entity);
            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });

        }
		[Authorize]
		[HttpGet]
        public IActionResult GetTicketByCurrentUser()
        {
            int currentUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (currentUser == null)
            {
                return NotFound();
            }

            var tickets = _ticketRepository.GetByUser(currentUser);
            return View(tickets);
        }
    }
}
