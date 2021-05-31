using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace MarvellousWorks.PracticalPattern.Idiom.Gateway.NativeAPI
{
    /// <summary>
    /// 通过API访问Performance Counter的Gateway类型
    /// </summary>
    public class PerformanceCounterGateway
    {
        /// <summary>
        /// Windows 本地 API
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long x);

        /// <summary>
        /// 保存当前系统PerfCounter计时频率
        /// </summary>
        private long frequency;

        /// <summary>
        /// 保存起始PerfCounter的计数
        /// </summary>
        private long start;
        /// <summary>
        /// 保存结束PerfCounter的计数
        /// </summary>
        private long end;

        /// <summary>
        /// 构造过程获取当前的PerfCounter计时频率
        /// </summary>
        public PerformanceCounterGateway()
        {
            QueryPerformanceFrequency(ref frequency);
        }

        /// <summary>
        /// 计时
        /// </summary>
        public void Reset() { QueryPerformanceCounter(ref start); }
        public void Stop() { QueryPerformanceCounter(ref end); }

        /// <summary>
        /// 以秒计算的执行持续时间
        /// </summary>
        public double ElapsedSeconds
        {
            get { return (end - start) * 1.0 / frequency; }
        }

        /// <summary>
        /// 显示计时频率
        /// </summary>
        public long Frequency { get { return frequency; } }
    }
}
