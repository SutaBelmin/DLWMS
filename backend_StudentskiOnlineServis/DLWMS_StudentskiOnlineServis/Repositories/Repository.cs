﻿using DLWMS_StudentskiOnlineServis.Data;
using System.Collections.Generic;
using System.Linq;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Commit();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DLWMS_baza baza;

        public Repository(DLWMS_baza baza)
        {
            this.baza = baza;
        }

        public List<TEntity> GetAll()
        {
            return baza.Set<TEntity>().ToList();
        }

        public void Commit()
        {
            baza.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            baza.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            baza.Set<TEntity>().Update(entity);
        }

        public TEntity Get(int id)
        {
            return baza.Set<TEntity>().Find(id);
        }
    }
}
