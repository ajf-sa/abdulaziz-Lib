/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/6/2015
 * Time: 3:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace abdulaziz.Model
{
	/// <summary>
	/// Description of Helpers.
	/// </summary>
	public class Helpers
	{
		public Helpers()
		{
		}
		
		
		public SqliteHelper Sqlite{
			get{var sqlite = new SqliteHelper(); return sqlite;}
		}
		
		public MysqlHelper Mysql{
			get{var mysql = new MysqlHelper(); return mysql;}
		}
		
	}
}
