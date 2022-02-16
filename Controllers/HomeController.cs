using Fine.Data;
using Fine.Models;
using Fine.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatService _chatService;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ChatService chatService)
        {
            _logger = logger;
            _context = context;
            _chatService = chatService;
        }

        //GET
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var archivedMessages = await _context.Messages
                .Include(m => m.ChatUser)
                .ToListAsync();

            return View(archivedMessages);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task Archive(string? message, string? user)
        //{
        //    if (message == null && user == null)
        //    {
        //        return;
        //    }
        //    await _chatService.ArchiveMessageAsync(message, user);
        //    return;
        //}

    }
}
