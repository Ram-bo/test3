using System;
using System.Collections.Generic;
//add comment to test

namespace Interview
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private List<T> entities;

        public Repository()
        {
            entities = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return entities;
        }

        private Predicate<T> MatchedId(IComparable id)
        {
            return match => match.Id.Equals(id);
        }

        public void Delete(IComparable id)
        {
            entities.RemoveAll(MatchedId(id));
        }

        public T FindById(IComparable id)
        {
            return entities.Find(MatchedId(id));
        }

        public void Save(T item)
        {
            Delete(item.Id);
            entities.Add(item);
        }


    }
}
