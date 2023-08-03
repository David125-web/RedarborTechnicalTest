using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Interfaces;
using RedarborTechnicalTest.Infrastructure.Data;
using System.Data;

namespace RedarborTechnicalTest.Infrastructure.Repositories
{

    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationEmployeeDbContext _context;
        private readonly DbSet<T> _entities;
        private readonly string _tableName;
        private readonly string IdKeyColumnName;

        public GenericRepository(ApplicationEmployeeDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
            var obj = BaseEntity.CreateEmptyInstance<T>();
            _tableName = obj.TableName;
            IdKeyColumnName = obj.IdKeyColumnName;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            string query = $"SELECT * FROM {_tableName}";
            using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                connection.Open();
                return connection.Query<T>(query).ToList();
            }
        }
        public async Task<T> GetById(int id)
        {
            string query = $"SELECT * FROM {_tableName} WHERE {IdKeyColumnName} = @id ";
            using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                connection.Open();
                return connection.Query<T>(query, new { id }).FirstOrDefault();
            }
        }
        public async Task<T> Add(T entity)
        {
            _entities.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(T entity)
        {
            _entities.Remove(entity);
             await _context.SaveChangesAsync();
        }
    }
}
