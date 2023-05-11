using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository
    {
        /// <summary>
        /// Generic constraint use
        /// "T:class" demek yanlızca referans tip olabilir anlamındadır.
        /// "IEntity" olabilir ya da yanlızca buradan türetilenler.
        /// "new()" instence i alınabilirler arasından olmalı. ("IEntity" artık getirilemez.)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IEntityRepository<T> where T : class, IEntity, new()
        {
            IList<T> GetAll(Expression<Func<T, bool>>? filter = null);
            T Get(Expression<Func<T, bool>> filter);
            void Add(T entity);
            void Update(T entity);
            void Delete(T entity);
        }
    }
}
