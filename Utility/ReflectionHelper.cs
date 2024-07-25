using System.Reflection;

namespace Utility
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// 获取对象的指定属性值
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性值</returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));

            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null) throw new ArgumentException($"Property '{propertyName}' not found on type '{type.FullName}'.");

            return propertyInfo.GetValue(obj);
        }

        /// <summary>
        /// 设置对象的指定属性值
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">属性值</param>
        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));

            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null) throw new ArgumentException($"Property '{propertyName}' not found on type '{type.FullName}'.");

            propertyInfo.SetValue(obj, value);
        }

        /// <summary>
        /// 调用对象的指定方法
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="parameters">方法参数</param>
        /// <returns>方法返回值</returns>
        public static object InvokeMethod(object obj, string methodName, params object[] parameters)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(methodName)) throw new ArgumentNullException(nameof(methodName));

            Type type = obj.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            if (methodInfo == null) throw new ArgumentException($"Method '{methodName}' not found on type '{type.FullName}'.");

            return methodInfo.Invoke(obj, parameters);
        }
    }
}
