/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/1/2015
 * Time: 7:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Diagnostics;
using abdulaziz.Model;
using MySql.Data.MySqlClient;

namespace abdulaziz.Database
{
	/// <summary>
	/// Description of Mysql.
	/// </summary>
		public abstract class Mysql:MysqlHelper
		{
			
		private MySqlConnection connected ;
		
		
		public void Connection(Connection conn){
		
		
		connected = new MySqlConnection(ConnectionString(conn));
	
		OnCreate();
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn">Model.Connection para</param>
        /// <returns>Bool>> true if connected</returns>
		public bool IsConnection(Connection conn){
		
			
		
		try {
			
			connected = new MySqlConnection(ConnectionString(conn));
			OnCreate();
			if(Open()){
			Close();
			return true;
			}else{
				
				Debug.WriteLine("Can't open Connection MySql ");
				return false;
			}
	
			
		} catch (MySqlException) {
			
			Debug.WriteLine("MysqlExcetion");
		
		}
		
		
		return true;
		
	
		}

        private string ConnectionString(Connection conn) {

            string connectionString = "SERVER=" + conn.Url + ";" + "DATABASE=" +
        conn.DbName + ";" + "UID=" + conn.Username + ";" + "PASSWORD=" + conn.Password + ";charset=utf8;";
            return connectionString;
        }
		
        /// <summary>
        /// use to create table , first method run when you deliverd
        /// </summary>
		public abstract void OnCreate();
		
		
		public void execute(string query){}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">query as string you can use mysqlHelper form model namespace</param>
        /// <returns>Bool >> true if Execute is done </returns>
		public bool IsExecute(string query){
		
			if(Open()){
			
			try {
					Debug.WriteLine(connected.State.ToString());
					var cmd = new MySqlCommand(query,connected);
					cmd.ExecuteNonQuery();
					
			} catch (Exception) {
				
					Debug.WriteLine("Error When Open Connection To MySql =>  IsExecute Method");
					return false;
					
			}
			}
			Close();
			return true;
		
		}


        /// <summary>
        /// 
        /// 
        /// 	DataTable dt = GetDataTable("select * from dru");
        //			
        //				foreach(DataRow row in dt.Rows){
        //					
        //				System.Console.WriteLine(row["drug"].ToString());
        //				
        //				}
        /// 
        /// </summary>
        /// <param name="query">query as string you can use mysqlHelper form model namespace for selected statment only!</param>
        /// <returns> Datatable  </returns>
        public DataTable GetDataTable(string query){
			var t = new DataTable();
			if(Open()){
			try {
					var sda = new MySqlDataAdapter(query,connected);
					sda.Fill(t);
					sda.Dispose();
				
			}catch (Exception) {
				
			Debug.WriteLine("Error When Open Connection To MySql => GetDataTable Method");
			}
			}
			Close();
			return t;
		}
		private bool Open(){
		
			
			try{
				connected.Open();
				return true;
			}
			catch{
			
				return false;
			}
		}
		
		
		
		
		
		
		private void Close(){
		
			connected.Close();
	
		}
		
	}
}
