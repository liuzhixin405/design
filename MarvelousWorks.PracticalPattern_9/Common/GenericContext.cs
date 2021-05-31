using System;
using System.Collections.Generic;
using System.Web;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// ͨ�õ��Զ��������Ķ���
    /// </summary>
    public class GenericContext
    {
        /// <summary>
        /// �����ڲ������ϣ����е��������;�Ϊ Dictionary<string, object>
        /// ���Զ���һ���̶����������ơ�
        /// </summary>
        class NameBasedDictionary : Dictionary<string, object> { }


        /// <summary>
        /// ���� Windows Ӧ�õ��̼߳������ĳ�Ա����
        /// </summary>
        [ThreadStatic]
        private static NameBasedDictionary threadCache;
        /// <summary>
        /// ��ʶ��ǰӦ���Ƿ�Ϊ Web Ӧ��
        /// </summary>
        private static readonly bool isWeb = CheckWhetherIsWeb();
        /// <summary>
        /// Web Ӧ���� Context ����ļ�ֵ
        /// </summary>
        private const string ContextKey = "marvellousWorks.context.web";


        /// <summary>
        /// ���� Web Ӧ�ã����HttpContext��Ӧ����Ԫ��û�г�ʼ���������һ����������
        /// ���� Windows Ӧ�ã����� threadCache Ϊ [ThreadStatic]������ù��̡�
        /// </summary>
        public GenericContext()
        {
            if (isWeb && (HttpContext.Current.Items[ContextKey] == null))
                    HttpContext.Current.Items[ContextKey] = new NameBasedDictionary();
        }



        /// <summary>
        /// ���������ĳ�Ա���ƣ����ض�Ӧ���ݵġ�
        /// <remarks>
        /// ���� threadCache �� HttpContext �еĻ�����󶼻��ڹ�������д���
        //  ��ˣ�����û�ж� cache == null ���жϡ�
        /// </remarks>
        /// </summary>
        /// <param name="name">�����ĳ�Ա��ֵ��</param>
        /// <returns>��Ӧ����</returns>
        public object this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return null;
                NameBasedDictionary cache = GetCache();
                if (cache.Count <= 0) return null;
                object result;
                if (cache.TryGetValue(name, out result))
                    return result;
                else
                    return null;
            }
            set
            {
                if (string.IsNullOrEmpty(name)) return;
                NameBasedDictionary cache = GetCache();
                object temp;
                if (cache.TryGetValue(name, out temp))
                    cache[name] = value;
                else
                    cache.Add(name, value);
            }
        }



        /// <summary>
        /// ����Ӧ�����ͻ�ȡ��Ӧ�����Ļ������
        /// </summary>
        /// <returns>�������</returns>
        private static NameBasedDictionary GetCache()
        {
            NameBasedDictionary cache;
            if (isWeb)
                cache = (NameBasedDictionary)HttpContext.Current.Items[ContextKey];
            else
                cache = threadCache;
            if (cache == null)
                cache = new NameBasedDictionary();
            if (isWeb)
                HttpContext.Current.Items[ContextKey] = cache;
            else
                threadCache = cache;
            return cache;
        }

        /// <summary>
        /// �жϵ�ǰӦ���Ƿ�Ϊ Web Ӧ�õ� Helper ���� ���ǹٷ�������
        /// </summary>
        /// <returns></returns>
        public static bool CheckWhetherIsWeb()
        {
            bool result = false;
            AppDomain domain = AppDomain.CurrentDomain;
            try
            {
                if (domain.ShadowCopyFiles)
                    result = (HttpContext.Current.GetType() != null);
            }
            catch (System.Exception){}
            return result;
        }
    }
}
