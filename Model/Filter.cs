/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 4/2/2015
 * Time: 3:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace abdulaziz.Model
{
	/// <summary>
	/// Description of Filter.
	/// </summary>
	public class Filter
	{
		public Filter()
		{
		}
			/// <summary>
		/// signal filter
		/// </summary>
		/// <param name="fil"></param>
		/// <returns></returns>
		public string OneFil(string OneFil){
			
			OneFil = OneFil.Replace("'","\"");
		//	 fil =fil.Replace(";",",");      
			return "'"+OneFil+"'";		
		
		
		}
		
		
		/// <summary>
		/// multi filter
		/// </summary>
		/// <param name="MultiFil"> arragment string that was filter</param>
		/// <returns></returns>
			public string[] MultiFil(string [] MultiFil){
			
				List<string> list = new List<string>();
				
				
			
                for (int x = 0; x < MultiFil.Length; x++)
                {
                    
                    MultiFil[x] = MultiFil[x].Replace("'", "\"");
                    list.Add("'" + MultiFil[x] + "'");
                }
           

             	
				

				return list.ToArray();
			}
	}
}
