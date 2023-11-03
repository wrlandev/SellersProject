using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SellersProject.Models;

namespace SellersProject.Data
{
    public class SellersProjectContext : DbContext
    {
        public SellersProjectContext (DbContextOptions<SellersProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DepartmentModel> DepartmentModel { get; set; } = default!;

        public DbSet<SellersProject.Models.SellerModel> SellerModel { get; set; } = default!;
        
    }
}
