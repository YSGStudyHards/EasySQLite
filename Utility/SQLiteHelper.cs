using SQLite;
using System.Linq.Expressions;

namespace Utility
{
    /// <summary>
    /// SQLite同步方法帮助类
    /// 作者：追逐时光者
    /// 创建时间：2023年11月30日
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SQLiteHelper<T> where T : new()
    {
        private readonly string _databasePath = Path.Combine(Environment.CurrentDirectory, "ClassManagement.db");
        private readonly SQLiteConnection _connection; // SQLite连接对象

        /// <summary>
        /// 构造函数
        /// </summary>
        public SQLiteHelper()
        {
            // 创建SQLite连接对象并打开连接
            _connection = new SQLiteConnection(_databasePath);
            _connection.CreateTable<T>(); // 如果表不存在，则创建该表[不会创建重复的表]
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="item">要插入的数据项</param>
        /// <returns></returns>
        public int Insert(T item)
        {
            return _connection.Insert(item);
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="id">要删除的数据的主键ID</param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return _connection.Delete<T>(id);
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="item">要更新的数据项</param>
        /// <returns></returns>
        public int Update(T item)
        {
            return _connection.Update(item);
        }

        /// <summary>
        /// 根据条件查询记录
        /// </summary>
        /// <param name="predExpr">查询条件</param>
        /// <returns></returns>
        public List<T> Query(Expression<Func<T, bool>> predExpr)
        {
            return _connection.Table<T>().Where(predExpr).ToList();
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> QueryAll()
        {
            return _connection.Table<T>().ToList();
        }

        /// <summary>
        /// 根据条件查询单条记录
        /// </summary>
        /// <param name="predExpr">查询条件</param>
        /// <returns></returns>
        public T QuerySingle(Expression<Func<T, bool>> predExpr)
        {
            return _connection.Table<T>().Where(predExpr).FirstOrDefault();
        }
    }
}
