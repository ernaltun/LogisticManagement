﻿using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete;
using LogisticManagement.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticManagement.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public IActionResult AddMessage(Message message)
        {
            _messageRepository.Insert(message);
            return RedirectToAction("Index","Home");
        }
		[Authorize(Roles = "admin")]
		public IActionResult GetMessages()
        {
            var messageList = _messageRepository.Messages.ToList();

            return View(messageList);
        }
    }
}
