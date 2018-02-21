/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/1/2015
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using abdulaziz.Model;
using System.IO;

namespace abdulaziz.Database
{
	/// <summary>
	/// Description of Sqlite.
	/// </summary>
	public abstract class Sqlite:SqliteHelper
	{
		private SQLiteConnection connected;
	
		public void Connection(Connection conn){
		
		connected=new SQLiteConnection(ConnectionString(conn));
		OnCreate();
		}
		
		
				public bool IsConnection(Connection conn)
        {
           
            try
            {
                connected = new SQLiteConnection(ConnectionString(conn));

                OnCreate();
                if (Open())
                {
                    Close();
                    return true;
                }
                else
                {

                    Debug.WriteLine("Can't open Connection Sqlite ");
                    return false;
                }


            }
            catch (SQLiteException)
            {

                Debug.WriteLine("sqliteExcetion");

            }


            return true;


        }


        private static string ConnectionString(Connection conn)
        {
            string db = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), conn.DbName + "");
            return string.Format("Data Source={0};Version=3;New=True;Compress=True", db);
        }

        public abstract void OnCreate();
		
		
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="query">sqlite statement for insert,update and delete</param>
		public void Execute(string query){
			
			if(Open()){
				try{
		
				var cmd = new SQLiteCommand(query,connected);
				cmd.ExecuteNonQuery();
				
				
				}catch(Exception e){
				
					System.Console.WriteLine(e.Message);
					
				}
			}
			Close();
			
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"> sqlite query for insert,update and delete</param>
		/// <returns>True if Execute done</returns>
		public bool IsExecute(string query){
		
				if(Open()){
				try{
		
				var cmd = new SQLiteCommand(query,connected);
				cmd.ExecuteNonQuery();
				
				
				}catch(Exception){
				
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
		/// <param name="query"></param>
		/// <returns> datatable </returns>
		public DataTable GetDataTable(String query){
			
			var t = new DataTable();
					if(Open()){
				try{
		
					var sda = new SQLiteDataAdapter(query,connected);
		   			sda.Fill(t);
		   			return t;
				
		   			
				
				}catch(Exception){
				
					
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
