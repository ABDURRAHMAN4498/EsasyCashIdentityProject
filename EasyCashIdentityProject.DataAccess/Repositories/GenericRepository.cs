﻿using EasyCashIdentityProject.DataAccess.Abstract;
using EasyCashIdentityProject.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
           using var context = new Context();
            context.Set<T>().Remove(t);
            context.SaveChanges();

        }

        public T GetByID(int id)
        {
            var context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            var context = new Context();
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            var context = new Context();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}
