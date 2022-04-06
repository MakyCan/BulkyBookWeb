﻿using BulkyBook.DataAccess.Repositories.IRepositories;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repositories
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        public CoverTypeRepository(BulkyDbContext bulkyDbContext) : base(bulkyDbContext)
        {
        }

        public EntityState Update(CoverType coverType)
        {
            return Context.Update(coverType).State;
        }
    }
}
