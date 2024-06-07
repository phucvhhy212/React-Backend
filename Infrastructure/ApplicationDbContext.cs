using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext:IdentityDbContext<User,IdentityRole<Guid>, Guid>
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowingRequest> BorrowingRequests { get; set; }
        public virtual DbSet<UserRequest> UserRequests { get; set; }
        public virtual DbSet<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRequest>().HasOne<User>(ur => ur.Requester).WithMany(u => u.UserRequests)
                .HasForeignKey(ur => ur.RequesterId);
            builder.Entity<BorrowingRequest>().HasOne<User>(br => br.Requester).WithMany(u => u.BorrowingRequests)
                .HasForeignKey(br => br.RequesterId);
            builder.Entity<BorrowingRequestDetail>().HasKey(x => new { x.BookId, x.BorrowingRequestId });
            builder.Entity<Category>().HasData(new List<Category>
            {
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/action.PNG",
                    Name = "Action"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/adventure.PNG",
                    Name = "Adventure"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/comedy.PNG",
                    Name = "Comedy"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/crime.PNG",
                    Name = "Crime"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/documentary.PNG",
                    Name = "Documentary"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/drama.PNG",
                    Name = "Drama"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/fantasy.PNG",
                    Name = "Fantasy"
                },
                new Category
                {
                    Image = "https://nash-book.s3.ap-southeast-1.amazonaws.com/horror.PNG",
                    Name = "Horror"
                }
            });
            base.OnModelCreating(builder);
        }
    }
}
