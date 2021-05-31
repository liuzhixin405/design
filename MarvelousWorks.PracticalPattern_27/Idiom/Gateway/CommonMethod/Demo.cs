using System;
using System.Text;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.Gateway.CommonMethod
{
    public interface ISmsServer
    {
        int ForwardRequest(byte msgType, int packageNumber, byte[] message);
    }

    /// <summary>
    /// 异常对象
    /// </summary>
    public class SmsSendException : ApplicationException
    {
        public SmsSendException(string message)
            : base(message) { }
    }

    public class SmsGateway
    {
        /// <summary>
        /// 目标操作对象
        /// </summary>
        private ISmsServer server;
        /// <summary>
        /// 保存相关错误编码
        /// </summary>
        private static IDictionary<int, string> errors;
        /// <summary>
        /// 操作成功标志
        /// </summary>
        private const int Succeed = 0;
        /// <summary>
        /// 每一条短信的最大容量，这里纯粹为了演示设定一个很小的值
        /// </summary>
        private const int PackageSize = 5;

        private const byte MobileMessage = 0;
        private const byte ImMessage = 1;

        /// <summary>
        /// 登记相关的错误编码
        /// </summary>
        static SmsGateway()
        {
            errors = new Dictionary<int, string>();
            errors.Add(1, "消息结构错");
            errors.Add(2, "命令字错");
            errors.Add(3, "消息序号重复");
            errors.Add(4, "消息长度错");
        }

        /// <summary>
        /// 构造子方式注入目标操作对象
        /// </summary>
        /// <param name="server"></param>
        public SmsGateway(ISmsServer server)
        {
            if (server == null) throw new ArgumentNullException("server");
            this.server = server;
        }

        /// <summary>
        /// Helper Method
        /// 处理返回结果, 将错误编码包装成标准的异常
        /// </summary>
        /// <param name="result"></param>
        private void HandleResult(int result)
        {
            if (result == Succeed) return;
            string message = errors[result];
            throw new SmsSendException(message);
        }

        #region 面向目标类型的便利化封装
        private byte[] GetBuffer(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");
            return Encoding.Unicode.GetBytes(message);
        }

        private void InternalSendMessage(byte messageType, string message)
        {
            InternalSendMessage(messageType, GetBuffer(message));
        }

        private void InternalSendMessage(byte messageType, byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (buffer.Length == 0) return;
            //  按照 packge size 分成多次
            int index = 0;
            int len = buffer.Length;
            int sequence = 0;
            while (index < len)
            {
                int size = (len - index) < PackageSize ? len - index : PackageSize;
                byte[] package = new byte[size];
                Array.Copy(buffer, index, package, 0, size);
                int result = server.ForwardRequest(messageType, sequence++, package);
                HandleResult(result);
                index += PackageSize;
            }
        }
        #endregion

        /// <summary>
        /// gateway 真正提供给客户程序使用的方法
        /// </summary>
        /// <param name="message"></param>
        public void SendMobileMessage(string message)
        {
            InternalSendMessage(MobileMessage, message);
        }
        public void SendImMessage(string message)
        {
            InternalSendMessage(ImMessage, message);
        }
    }
}
