/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/13/2015
 * Time: 12:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace abdulaziz.Model
{
	/// <summary>
	/// Description of Connection.
	/// </summary>
	public class Connection
	{
		private string userName;
		private string password;
		private string dbType;
		private string dbName;
		private string url;
		public Connection()
		{
		}

		public string Username {
			get {
				return userName;
			}
			set {
				userName = value;
			}
		}

		public string Password {
			get {
				return password;
			}
			set {
				password = value;
			}
		}

		public string DbType {
			get {
				return dbType;
			}
			set {
				dbType = value;
			}
		}
		public string DbName {
			get {
				return dbName;
			}
			set {
				dbName = value;
			}
		}

		public string Url {
			get {
				return url;
			}
			set {
				url = value;
			}
		}
	}
}
