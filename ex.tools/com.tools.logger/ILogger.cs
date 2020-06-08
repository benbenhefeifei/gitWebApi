using System;

namespace com.xbao.tools.logger
{
    public interface ILogger
    {
        /// <summary>
        /// 一般信息（非错误，可能是安全需要增加的跟踪）
        /// </summary>
        /// <param name="message">要写入日志的信息，String.Format 参数</param>
        /// <param name="args">需要提供的 String.Format 参数列表</param>
        void Info(string message, params object[] args);
        /// <summary>
        /// 警告信息（有问题，不影响系统正常运行）
        /// </summary>
        /// <param name="message">要写入日志的信息，String.Format 参数</param>
        /// <param name="args">需要提供的 String.Format 参数列表</param>
        void Warn(string message, params object[] args);

        /// <summary>
        /// 错误信息（程序错误）
        /// </summary>
        /// <param name="message">要写入日志的信息，String.Format 参数</param>
        /// <param name="args">需要提供的 String.Format 参数列表</param>
        void Error(string message, params object[] args);
        /// <summary>
        /// 错误信息（程序错误）
        /// </summary>
        /// <param name="message">要写入日志的信息</param>
        /// <param name="exception">异常信息</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// 严重错误（可能导致系统不能工作）
        /// </summary>
        /// <param name="message">要写入日志的信息，String.Format 参数</param>
        /// <param name="args">需要提供的 String.Format 参数列表</param>
        void Fatal(string message, params object[] args);
        /// <summary>
        /// 严重错误（可能导致系统不能工作）
        /// </summary>
        /// <param name="message">要写入日志的信息</param>
        /// <param name="exception">异常信息</param>
        void Fatal(string message, Exception exception);

        /// <summary>
        /// 调试信息（用于调试错误）
        /// </summary>
        /// <param name="message">要写入日志的信息，String.Format 参数</param>
        /// <param name="args">需要提供的 String.Format 参数列表</param>
        void Debug(string message, params object[] args);
        /// <summary>
        /// 调试信息（用于调试错误）
        /// </summary>
        /// <param name="message">要写入日志的信息</param>
        /// <param name="exception">异常信息</param>
        void Debug(string message, Exception exception);
    }
}
