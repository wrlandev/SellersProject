﻿using System;
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
        public DbSet<SellerModel> SellerModel { get; set; }
        public DbSet<SalesRecordModel> SalesRecordModel { get; set; }
    }
}
