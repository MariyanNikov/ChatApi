using Chat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Data
{
    public class MessageDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessageDbContext()
        {

        }
        public MessageDbContext(DbContextOptions<MessageDbContext> options)
           : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
