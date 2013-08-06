using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Data;

namespace HtlInv.Common.Utility
{
    public class EntityHelper<T> where T:class
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityHelper()
        { }

        /// <summary>
        /// 克隆实体
        /// </summary>
        /// <typeparam name="V">要克隆的对象类型</typeparam>
        /// <param name="source">源对象</param>
        /// <returns>源对象克隆后的实体</returns>
        public V CloneEntity<V>(T source) where V:class
        {
            if(source==null)
                return default(V);
            // 获取源对象的属性列表
            PropertyInfo[] sourceProList = typeof(T).GetProperties();
            if (sourceProList != null)
            {
                // 创建要克隆的对象实例
                V entity = (V)Activator.CreateInstance(typeof(V));
                // 循环源类型的属性列表
                foreach (PropertyInfo property in sourceProList)
                {
                    try
                    {
                        // 获取源对象当前循环属性的值
                        object value = property.GetValue(source, null);
                        // 获取目标对象和源对象同名的属性
                        PropertyInfo targetProperty = typeof(V).GetProperty(property.Name);
                        // 如果属性存在则赋值
                        if (targetProperty != null)
                            targetProperty.SetValue(entity, value, null);
                    }
                    catch
                    { }
                }
                return entity;
            }
            return default(V);
        }

        /// <summary>
        /// 克隆实体列表
        /// </summary>
        /// <typeparam name="V">要克隆的对象类型</typeparam>
        /// <param name="source">源对象列表</param>
        /// <returns>源对象克隆后的实体列表</returns>
        public List<V> CloneEntityList<V>(List<T> sourceList) where V : class
        {
            if (sourceList == null)
                return null;
            // 获取源对象的属性列表
            PropertyInfo[] sourceProteryList = typeof(T).GetProperties();
            if (sourceProteryList != null)
            {
                List<V> targetList = new List<V>();
                foreach (T source in sourceList)
                {
                    V entity = CloneEntity<V>(source);
                    if (entity != null && !targetList.Contains(entity))
                        targetList.Add(entity);
                }
                return targetList;
            }
            return null;
        }

        /// <summary>
        /// 将数据集转换成实体类,在方法内执行Read,该方法可以转换非空类型，如int?,如无非空类型请使用Eimit方法
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>实体列表</returns>
        public T ConvertDataReaderToEntity(IDataReader reader)
        {
            if (reader == null)
            {
                return default(T);
            }
            Type type = typeof(T);
            ///获取实体类的所有属性
            T entity = null;
            ///循环数据表取数据
            if (reader.Read())
            {
                entity = (T)Activator.CreateInstance(typeof(T));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo property = typeof(T).GetProperty(reader.GetName(i));
                    if (property != null && property.GetSetMethod() != null)
                    {
                        Type ty = property.PropertyType;
                        if (Nullable.GetUnderlyingType(ty) != null)
                        {
                            ty = Nullable.GetUnderlyingType(ty);
                        }
                        if (!reader.IsDBNull(i))
                        {
                            property.SetValue(entity, Convert.ChangeType(reader[i], ty), null);
                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 将数据集转换成实体类,在该方法外执行Read,该方法可以转换非空类型，如int?,如无非空类型请使用Eimit方法
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>实体列表</returns>
        public T ConvertDataReaderToEntityNoRead(IDataReader reader)
        {
            if (reader == null)
            {
                return default(T);
            }
            Type type = typeof(T);
            ///获取实体类的所有属性
            T Entity = null;
            ///循环数据表取数据
            Entity = (T)Activator.CreateInstance(typeof(T));
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = typeof(T).GetProperty(reader.GetName(i));
                if (property != null && property.GetSetMethod() != null)
                {
                    Type ty = property.PropertyType;
                    if (Nullable.GetUnderlyingType(ty) != null)
                    {
                        ty = Nullable.GetUnderlyingType(ty);
                    }
                    if (!reader.IsDBNull(i))
                    {
                        property.SetValue(Entity, Convert.ChangeType(reader[i], ty), null);
                    }
                }
            }
            return Entity;
        }

        /// <summary>
        /// 将数据集转换成实体类集合，在方法内执行Read,该方法可以转换非空类型，如int?,如无非空类型请使用Eimit方法
        /// </summary>
        /// <param name="table"></param>
        /// <returns>实体列表</returns>
        public List<T> ConvertDataReaderToList(IDataReader reader)
        {
            if (reader == null)
            {
                return new List<T>();
            }
            Type type = typeof(T);
            ///获取实体类的所有属性
            List<T> listEntity = new List<T>();
            ///循环数据表取数据
            while (reader.Read())
            {
                T Entity = (T)Activator.CreateInstance(typeof(T));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ///创建实体的新实例(类似new class())
                    PropertyInfo property = typeof(T).GetProperty(reader.GetName(i));
                    if (property != null && property.GetSetMethod() != null)
                    {
                        Type ty = property.PropertyType;
                        if (Nullable.GetUnderlyingType(ty) != null)
                        {
                            ty = Nullable.GetUnderlyingType(ty);
                        }
                        if (!reader.IsDBNull(i))
                        {
                            property.SetValue(Entity, Convert.ChangeType(reader[i], ty), null);
                        }
                    }
                }
                listEntity.Add(Entity);
            }

            return listEntity;
        }

        /// <summary>
        /// 将DataReader转换成实体对象，在方法外执行Read
        /// </summary>
        /// <param name="dataRecord">数据集合</param>
        /// <returns>要转换的实体</returns>
        public T ConvertDataReaderToEntityByEimitNoRead(IDataReader dr)
        {
            if (dr == null)
                return default(T);
            T entity = default(T); // (T)Activator.CreateInstance(typeof(T));

            entity = CreateBuilder(dr);

            return entity;
        }

        /// <summary>
        /// 将DataReader转换成实体对象，在方法内执行Read
        /// </summary>
        /// <param name="dataRecord">数据集合</param>
        /// <returns>要转换的实体</returns>
        public T ConvertDataReaderToEntityByEimit(IDataReader dr)
        {
            if (dr == null)
                return default(T);
            T entity = default(T); // (T)Activator.CreateInstance(typeof(T));
            if (dr.Read())
            {
                entity = CreateBuilder(dr);
            }

            return entity;
        }

        /// <summary>
        /// 把IDataReader 转换为指定实体集合，在方法内执行Read
        /// </summary>
        /// <param name="dr">数据集合</param>
        /// <returns>要转换的实体集合</returns>
        public List<T> ConvertDataReaderToListByEimit(IDataReader dr)
        {
            List<T> list = new List<T>();
            if (dr == null) 
                return list;
            while (dr.Read())
                list.Add(CreateBuilder(dr));

            return list;
        }

        /// <summary>
        /// getitem 方法对象
        /// </summary>
        private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[] { typeof(int) });
        /// <summary>
        /// isdbnull 方法对象
        /// </summary>
        private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[] { typeof(int) });
        
        /// <summary>
        /// 创建包含实体转换委托的EnitytHelper对象
        /// </summary>
        /// <param name="dataRecord">数据集合</param>
        /// <returns>包含实体转换委托的EnitytHelper对象</returns>
        private T CreateBuilder(IDataRecord dataRecord)
        {
            DynamicMethod method = new DynamicMethod("DynamicCreateEntity", typeof(T),
            new Type[] { typeof(IDataRecord) }, typeof(T), true);
            ILGenerator generator = method.GetILGenerator();
            LocalBuilder result = generator.DeclareLocal(typeof(T));
            generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
            generator.Emit(OpCodes.Stloc, result);
            for (int i = 0; i < dataRecord.FieldCount; i++)
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(dataRecord.GetName(i));
                Label endIfLabel = generator.DefineLabel();
                if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                {
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                    generator.Emit(OpCodes.Brtrue, endIfLabel);
                    generator.Emit(OpCodes.Ldloc, result);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, getValueMethod);
                    EmitCastObj(generator, dataRecord.GetFieldType(i));
                    generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                    generator.MarkLabel(endIfLabel);
                }
            }
            generator.Emit(OpCodes.Ldloc, result);
            generator.Emit(OpCodes.Ret);
            return (T)method.Invoke(null, new object[] { dataRecord  });
        }

        /// <summary>
        /// 判断类型
        /// </summary>
        /// <param name="il"></param>
        /// <param name="targetType"></param>
        private static void EmitCastObj(ILGenerator il, Type targetType)
        {
            if (targetType.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, targetType);
            }
            else
            {
                il.Emit(OpCodes.Castclass, targetType);
            }
        }
    }
}
