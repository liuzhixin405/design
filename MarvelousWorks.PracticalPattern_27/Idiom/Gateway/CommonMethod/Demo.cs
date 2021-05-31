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
    /// �쳣����
    /// </summary>
    public class SmsSendException : ApplicationException
    {
        public SmsSendException(string message)
            : base(message) { }
    }

    public class SmsGateway
    {
        /// <summary>
        /// Ŀ���������
        /// </summary>
        private ISmsServer server;
        /// <summary>
        /// ������ش������
        /// </summary>
        private static IDictionary<int, string> errors;
        /// <summary>
        /// �����ɹ���־
        /// </summary>
        private const int Succeed = 0;
        /// <summary>
        /// ÿһ�����ŵ�������������﴿��Ϊ����ʾ�趨һ����С��ֵ
        /// </summary>
        private const int PackageSize = 5;

        private const byte MobileMessage = 0;
        private const byte ImMessage = 1;

        /// <summary>
        /// �Ǽ���صĴ������
        /// </summary>
        static SmsGateway()
        {
            errors = new Dictionary<int, string>();
            errors.Add(1, "��Ϣ�ṹ��");
            errors.Add(2, "�����ִ�");
            errors.Add(3, "��Ϣ����ظ�");
            errors.Add(4, "��Ϣ���ȴ�");
        }

        /// <summary>
        /// �����ӷ�ʽע��Ŀ���������
        /// </summary>
        /// <param name="server"></param>
        public SmsGateway(ISmsServer server)
        {
            if (server == null) throw new ArgumentNullException("server");
            this.server = server;
        }

        /// <summary>
        /// Helper Method
        /// �����ؽ��, ����������װ�ɱ�׼���쳣
        /// </summary>
        /// <param name="result"></param>
        private void HandleResult(int result)
        {
            if (result == Succeed) return;
            string message = errors[result];
            throw new SmsSendException(message);
        }

        #region ����Ŀ�����͵ı�������װ
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
            //  ���� packge size �ֳɶ��
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
        /// gateway �����ṩ���ͻ�����ʹ�õķ���
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
