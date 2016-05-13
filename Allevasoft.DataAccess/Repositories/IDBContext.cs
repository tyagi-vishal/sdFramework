﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Allevasoft.DataAccess.Repository
{
    public interface IDbContext
    {
        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> Set<T>() where T : class;
        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        void Dispose();
        Database Database { get; }

        DbChangeTracker ChangeTracker { get; }
    }
}