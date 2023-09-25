using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ecommerce.Repository {
    public class GenericRepository<Tbl_Entity> : IRepository<Tbl_Entity> where Tbl_Entity : class {
        readonly DbSet<Tbl_Entity> _dbSet;
        private readonly dbMyOnlineShoppingEntities _dbEntity;
        public GenericRepository(dbMyOnlineShoppingEntities dbEntity) {
            _dbEntity = dbEntity;
            _dbSet = _dbEntity.Set<Tbl_Entity>();
        }

        public void Add(Tbl_Entity entity) {
            _dbSet.Add(entity);
            _dbEntity.SaveChanges();    
        }

        public int GetAllRecordCount() {
           return _dbSet.Count();
        }

        public IEnumerable<Tbl_Entity> GetAllRecords() {
            return _dbSet.ToList();
        }
        public IEnumerable<Tbl_Entity> GetProduct() {
            return _dbSet.ToList();

        }

        public IQueryable<Tbl_Entity> GetAllRecordsIQueryable() {
            return _dbSet;
        }

        public Tbl_Entity GetFirstOrDefault(int recordId) {
            return _dbSet.Find(recordId);
        }

        public Tbl_Entity GetFirstOrDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<Tbl_Entity> GetRecordsToShow(int pageNumber, int pageSize, int currentPage, Expression<Func<Tbl_Entity, bool>> wherePredict, Expression<Func<Tbl_Entity, int>> orderByPredict) {
            if(wherePredict != null) {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();
            } else {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }

        public IEnumerable<Tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters) {
            if(parameters != null) {
                return  _dbEntity.Database.SqlQuery<Tbl_Entity>(query, parameters);
            }
            return _dbEntity.Database.SqlQuery<Tbl_Entity>(query).ToList();
        }

        public void InactiveAndDeleteMarkWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict) {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);    
        }

        public void Remove(Tbl_Entity entity) {
            if(_dbEntity.Entry(entity).State == EntityState.Detached) {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void RemoveByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            Tbl_Entity entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            List<Tbl_Entity> entity = _dbSet.Where(wherePredict).ToList();
            foreach(var ent in entity) {
                Remove(ent);
            }
        }

        public void Update(Tbl_Entity entity) {
            _dbSet.Attach(entity);
            _dbEntity.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict) {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }
    }
}