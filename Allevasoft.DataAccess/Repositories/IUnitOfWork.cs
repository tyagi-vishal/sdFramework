﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allevasoft.DataAccess.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void SaveChanges();
        IDbContext DBContext { get; }
    }
}