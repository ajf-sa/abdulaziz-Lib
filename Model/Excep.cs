/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/6/2015
 * Time: 3:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace abdulaziz.Model
{
	/// <summary>
	/// Description of Excep.
	/// </summary>
	public class Excep : Exception, ISerializable
	{
		public Excep()
		{
		}

	 	public Excep(string message) : base(message)
		{
		}

		public Excep(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected Excep(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}