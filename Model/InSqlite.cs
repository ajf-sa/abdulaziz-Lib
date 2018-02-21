/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/11/2015
 * Time: 10:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace abdulaziz.Model
{
	/// <summary>
	/// Description of ISqlite.
	/// </summary>
	public interface InSqlite
	{
		
		void Insert(object obj);
		void Update(object obj);
		void Delete(object obj);
		List<object> GetRecord();
		List<object> GetRecord(object obj);
		object GetOneRecord();
		object GetOneRecord(object obj);
		
	}
}
