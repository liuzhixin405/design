namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// ����ÿ�����ý���ĳ�������
    /// </summary>
    public interface IConfigurationSource
    {
        /// <summary>
        /// ConfigurationBroker ����ͨ���ص��÷���, ������ÿ�����ý�����Ҫ��������ö���
        /// </summary>
        void Load();
    }
}
