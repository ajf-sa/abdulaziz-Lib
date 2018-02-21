/*
 * Created by SharpDevelop.
 * User: abdulaziz
 * Date: 16/01/34
 * Time: 04:39 ص
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace abdulaziz.Core
{
	/// <summary>
	/// Description of HelpersSqlite.
	/// </summary>
	internal class HelpersSqlite
	{
		public HelpersSqlite()
		{
		}
		
		Model.Filter fill = new Model.Filter();
		
		
		
			#region ...Sqlite  helper statment
		
		
		#region Create statment
		
		public string CreateDatabase(string database){
		
	return string.Format("create database if not exists {0}",new object[]{database});
	
		}
		
		
		
		
		
		public string CreateTable(string table,string [] column){
		
			
			return string.Format("create table if not exists [{0}]({1})",new object[]{
			  
			table,
			string.Join(", ",column)
			//HACK error when use sqlite AND its essentail in mysql
			});
					}
		
		
		
		#endregion
		
		
		#region Drop statment
		
		
		public string Drop(string dbTable,string tabName){
		
			return string.Format("drop {0} {1}",new object[]{
			     
			dbTable,
			tabName });
					}
					
		
		
		#endregion 
		
		
		#region insert statment 
		
		public string Insert(string table,string [] columns,string [] values){
		
			values=fill.MultiFil(values);
			return string.Format("insert into {0}({1}) values ({2})",new object[]{
			                     	
			table,
			string.Join(", ",columns),
			string.Join(", ",values)
             });
		}
		
		#endregion
		
		
		#region Update statment
		
		public string Update(string table,string [] sets,string wheres){
		
			return string.Format("update {0} set {1} where {2}",new object[]{
			                     
	         table,
	         string.Join(", ",sets),
	         wheres
			         	
			                  });
		}
		
		
		#endregion 
		
		
		#region Delete statment
		
		
		public string Delete(string table,string [] wheres){
		
			return string.Format("delete from {0} where {1}",new object[]{
			 
			table,
			string.Join(" ",wheres )
			                     });
		}
		
		#endregion 
		
		
		#region Select Statment

		public string Select(string column,string table){
		
			return string.Format("select {0} from {1}",new object[]{
			                     
			  column,
			  table          });
		
		}

		#endregion
		
		#endregion
	
	}
}
