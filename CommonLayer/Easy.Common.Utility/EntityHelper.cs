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
        /// ���캯��
        /// </summary>
        public EntityHelper()
        { }

        /// <summary>
        /// ��¡ʵ��
        /// </summary>
        /// <typeparam name="V">Ҫ��¡�Ķ�������</typeparam>
        /// <param name="source">Դ����</param>
        /// <returns>Դ�����¡���ʵ��</returns>
        public V CloneEntity<V>(T source) where V:class
        {
            if(source==null)
                return default(V);
            // ��ȡԴ����������б�
            PropertyInfo[] sourceProList = typeof(T).GetProperties();
            if (sourceProList != null)
            {
                // ����Ҫ��¡�Ķ���ʵ��
                V entity = (V)Activator.CreateInstance(typeof(V));
                // ѭ��Դ���͵������б�
                foreach (PropertyInfo property in sourceProList)
                {
                    try
                    {
                        // ��ȡԴ����ǰѭ�����Ե�ֵ
                        object value = property.GetValue(source, null);
                        // ��ȡĿ������Դ����ͬ��������
                        PropertyInfo targetProperty = typeof(V).GetProperty(property.Name);
                        // ������Դ�����ֵ
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
        /// ��¡ʵ���б�
        /// </summary>
        /// <typeparam name="V">Ҫ��¡�Ķ�������</typeparam>
        /// <param name="source">Դ�����б�</param>
        /// <returns>Դ�����¡���ʵ���б�</returns>
        public List<V> CloneEntityList<V>(List<T> sourceList) where V : class
        {
            if (sourceList == null)
                return null;
            // ��ȡԴ����������б�
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
        /// �����ݼ�ת����ʵ����,�ڷ�����ִ��Read,�÷�������ת���ǿ����ͣ���int?,���޷ǿ�������ʹ��Eimit����
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>ʵ���б�</returns>
        public T ConvertDataReaderToEntity(IDataReader reader)
        {
            if (reader == null)
            {
                return default(T);
            }
            Type type = typeof(T);
            ///��ȡʵ�������������
            T entity = null;
            ///ѭ�����ݱ�ȡ����
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
        /// �����ݼ�ת����ʵ����,�ڸ÷�����ִ��Read,�÷�������ת���ǿ����ͣ���int?,���޷ǿ�������ʹ��Eimit����
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>ʵ���б�</returns>
        public T ConvertDataReaderToEntityNoRead(IDataReader reader)
        {
            if (reader == null)
            {
                return default(T);
            }
            Type type = typeof(T);
            ///��ȡʵ�������������
            T Entity = null;
            ///ѭ�����ݱ�ȡ����
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
        /// �����ݼ�ת����ʵ���༯�ϣ��ڷ�����ִ��Read,�÷�������ת���ǿ����ͣ���int?,���޷ǿ�������ʹ��Eimit����
        /// </summary>
        /// <param name="table"></param>
        /// <returns>ʵ���б�</returns>
        public List<T> ConvertDataReaderToList(IDataReader reader)
        {
            if (reader == null)
            {
                return new List<T>();
            }
            Type type = typeof(T);
            ///��ȡʵ�������������
            List<T> listEntity = new List<T>();
            ///ѭ�����ݱ�ȡ����
            while (reader.Read())
            {
                T Entity = (T)Activator.CreateInstance(typeof(T));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ///����ʵ�����ʵ��(����new class())
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
        /// ��DataReaderת����ʵ������ڷ�����ִ��Read
        /// </summary>
        /// <param name="dataRecord">���ݼ���</param>
        /// <returns>Ҫת����ʵ��</returns>
        public T ConvertDataReaderToEntityByEimitNoRead(IDataReader dr)
        {
            if (dr == null)
                return default(T);
            T entity = default(T); // (T)Activator.CreateInstance(typeof(T));

            entity = CreateBuilder(dr);

            return entity;
        }

        /// <summary>
        /// ��DataReaderת����ʵ������ڷ�����ִ��Read
        /// </summary>
        /// <param name="dataRecord">���ݼ���</param>
        /// <returns>Ҫת����ʵ��</returns>
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
        /// ��IDataReader ת��Ϊָ��ʵ�弯�ϣ��ڷ�����ִ��Read
        /// </summary>
        /// <param name="dr">���ݼ���</param>
        /// <returns>Ҫת����ʵ�弯��</returns>
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
        /// getitem ��������
        /// </summary>
        private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[] { typeof(int) });
        /// <summary>
        /// isdbnull ��������
        /// </summary>
        private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[] { typeof(int) });
        
        /// <summary>
        /// ��������ʵ��ת��ί�е�EnitytHelper����
        /// </summary>
        /// <param name="dataRecord">���ݼ���</param>
        /// <returns>����ʵ��ת��ί�е�EnitytHelper����</returns>
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
        /// �ж�����
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
