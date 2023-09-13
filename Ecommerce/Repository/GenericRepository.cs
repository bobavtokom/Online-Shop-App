using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ecommerce.Repository {
    public class GenericRepository<Tbl_Entity> : IRepository<Tbl_Entity> where Tbl_Entity : class {
        DbSet<Tbl_Entity> _dbSet;
        private dbMyOnlineShoppingEntities _dbEntity;
        public GenericRepository(dbMyOnlineShoppingEntities dbEntity) {
            _dbEntity = dbEntity;
            _dbSet = _dbEntity.Set<Tbl_Entity>();
        }

        public void Add(Tbl_Entity entity) {
            throw new NotImplementedException();
        }

        public int GetAllRecordCount() {
            throw new NotImplementedException();
        }

        public IEnumerable<Tbl_Entity> GetAllRecords() {
            throw new NotImplementedException();
        }

        public IQueryable<Tbl_Entity> GetAllRecordsIQueryable() {
            throw new NotImplementedException();
        }

        public Tbl_Entity GetFirstOrDefault(int recordId) {
            throw new NotImplementedException();
        }

        public Tbl_Entity GetFirstOrDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            throw new NotImplementedException();
        }

        public IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            throw new NotImplementedException();
        }

        public IEnumerable<Tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters) {
            throw new NotImplementedException();
        }

        public void InactiveAndDeleteMarkWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict) {
            throw new NotImplementedException();
        }

        public void Remove(Tbl_Entity entity) {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            throw new NotImplementedException();
        }

        public void RemoveRangeByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict) {
            throw new NotImplementedException();
        }

        public void Update(Tbl_Entity entity) {
            throw new NotImplementedException();
        }

        public void UpdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict) {
            throw new NotImplementedException();
        }
    }
}