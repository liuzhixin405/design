namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// 定义每个配置节组的抽象动作。
    /// </summary>
    public interface IConfigurationSource
    {
        /// <summary>
        /// ConfigurationBroker 可以通过回调该方法, 将加载每个配置节组需要缓冲的配置对象
        /// </summary>
        void Load();
    }
}
