using SQLite;
using System.Linq.Expressions;

namespace Utility
{
    /// <summary>
    /// SQLite异步方法帮助类
    /// 作者：追逐时光者
    /// 创建时间：2023年11月30日
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SQLiteAsyncHelper<T> where T : new()
    {
        private readonly string _databasePath = Path.Combine(Environment.CurrentDirectory, "ClassManagement.db");
        private readonly SQLiteAsyncConnection _connectionAsync; // SQLite连接对象

        /// <summary>
        /// 构造函数
        /// </summary>
        public SQLiteAsyncHelper()
        {
            // 创建SQLite连接对象并打开连接
            _connectionAsync = new SQLiteAsyncConnection(_databasePath);
            _connectionAsync.CreateTableAsync<T>(); // 如果表不存在，则创建该表[不会创建重复的表]
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="item">要插入的数据项</param>
        /// <returns></returns>
        public async Task<int> InsertAsync(T item)
        {
            return await _connectionAsync.InsertAsync(item);
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="id">要删除的数据的主键ID</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int id)
        {
            return await _connectionAsync.DeleteAsync<T>(id);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="item">要更新的数据项</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(T item)
        {
            return await _connectionAsync.UpdateAsync(item);
        }

        /// <summary>
        /// 根据条件查询记录
        /// </summary>
        /// <param name="predExpr">查询条件</param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predExpr)
        {
            return await _connectionAsync.Table<T>().Where(predExpr).ToListAsync();
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> QueryAllAsync()
        {
            return await _connectionAsync.Table<T>().ToListAsync();
        }

        /// <summary>
        /// 根据条件查询单条记录
        /// </summary>
        /// <param name="predExpr">查询条件</param>
        /// <returns></returns>
        public async Task<T> QuerySingleAsync(Expression<Func<T, bool>> predExpr)
        {
            return await _connectionAsync.Table<T>().Where(predExpr).FirstOrDefaultAsync();
        }
    }
}
