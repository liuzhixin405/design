using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace MarvellousWorks.PracticalPattern.Idiom.Gateway.NativeAPI
{
    /// <summary>
    /// ͨ��API����Performance Counter��Gateway����
    /// </summary>
    public class PerformanceCounterGateway
    {
        /// <summary>
        /// Windows ���� API
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);

        /// <summary>
        /// ���浱ǰϵͳPerfCounter��ʱƵ��
        /// </summary>
        private long frequency;

        /// <summary>
        /// ������ʼPerfCounter�ļ���
        /// </summary>
        private long start;
        /// <summary>
        /// �������PerfCounter�ļ���
        /// </summary>
        private long end;

        /// <summary>
        /// ������̻�ȡ��ǰ��PerfCounter��ʱƵ��
        /// </summary>
        public PerformanceCounterGateway()
        {
            QueryPerformanceFrequency(ref frequency);
        }

        /// <summary>
        /// ��ʱ
        /// </summary>
        public void Reset() { QueryPerformanceCounter(ref start); }
        public void Stop() { QueryPerformanceCounter(ref end); }

        /// <summary>
        /// ��������ִ�г���ʱ��
        /// </summary>
        public double ElapsedSeconds
        {
            get { return (end - start) * 1.0 / frequency; }
        }

        /// <summary>
        /// ��ʾ��ʱƵ��
        /// </summary>
        public long Frequency { get { return frequency; } }
    }
}
