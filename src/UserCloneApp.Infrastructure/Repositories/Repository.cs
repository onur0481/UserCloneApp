using MongoDB.Driver;
using System.Linq.Expressions;
using UserCloneApp.Domain.Attributes;
using UserCloneApp.Domain.Configurations;
using UserCloneApp.Domain.Repositories;
using UserCloneApp.Domain.SeedWorks;

namespace UserCloneApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;
        public Repository(DatabaseConfiguration databaseConfiguration)
        {
            MongoClient mongoClient = new(databaseConfiguration.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private protected static string GetCollectionName(Type entityType)
        {
            return ((BsonCollectionAttribute)entityType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()!).CollectionName;
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual IEnumerable<T> AsEnumerable()
        {
            return _collection.AsQueryable().AsEnumerable();
        }

        public virtual IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public virtual T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual T FindById(string id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.ID, id);
            return _collection.Find(filter).SingleOrDefault();
        }

        public virtual Task<T> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.ID, id);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public virtual void InsertOne(T entity)
        {
            _collection.InsertOne(entity);
        }

        public virtual Task InsertOneAsync(T entity)
        {
            return Task.Run(() => _collection.InsertOneAsync(entity));
        }

        public void InsertMany(ICollection<T> entities)
        {
            _collection.InsertMany(entities);
        }

        public virtual async Task InsertManyAsync(ICollection<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public void ReplaceOne(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.ID, entity.ID);
            _collection.FindOneAndReplace(filter, entity);
        }

        public virtual async Task ReplaceOneAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.ID, entity.ID);
            await _collection.FindOneAndReplaceAsync(filter, entity);
        }

        public void DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public void DeleteById(string id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.ID, id);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.ID, id);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }
    }
}
