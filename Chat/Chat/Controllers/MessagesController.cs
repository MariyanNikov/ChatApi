using Chat.Data;
using Chat.Domain;
using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessageDbContext context;

        public MessagesController(MessageDbContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "All")]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByOnAscending()
        {
            var messages = this.context.Messages.OrderBy(x => x.CreatedOn).ToList();

            return messages;
        }

        [HttpPost(Name = "Create")]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreateBindingModel model)
        {
            Message message = new Message
            {
                Content = model.Content,
                User = model.User,
                CreatedOn = DateTime.UtcNow
            };

            await  this.context.Messages.AddAsync(message);
            await this.context.SaveChangesAsync();

            return this.Ok(message);
        }
    }
}
