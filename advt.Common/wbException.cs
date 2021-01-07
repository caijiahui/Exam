using System;

namespace advt.Common
{
	/// <summary>
	/// 自定义异常类。
	/// </summary>
	public class wbException : Exception
	{
		public wbException()
		{
			//
		}


		public wbException(string msg) : base(msg)
		{
			//
		}
	}
}
