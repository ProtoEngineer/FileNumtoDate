/*
 * Created by SharpDevelop.
 * User: leon
 * Date: 12/1/2017
 * Time: 7:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;


namespace FileNumtoDate
{
	class Program
	{
		public static void Main(string[] args)
		{

			string path = Directory.GetCurrentDirectory();
			
			string file = path + @"/1.jpg";
			int year,month,day;
			
			FileInfo unfile = new FileInfo(file);
			DateTime curtime = unfile.CreationTime;
			
			Console.WriteLine("Date of Jpg 1" + curtime);
			Console.WriteLine("1.To change the date Enter '1'");
			Console.WriteLine("2.Press something else to overwrite the files with the above given date. (Append Filename number to time)");
			string change = Console.ReadLine();
			
			if (change == "1")
			{
				Console.WriteLine("Geef de juiste datum op");
					Console.WriteLine("Set jaar");
					year = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Set maand");
					month = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Set dag");
				    day = Convert.ToInt32(Console.ReadLine());
					DateTime dt = new DateTime(year,month,day);
					Console.WriteLine(dt);
					Console.ReadKey();
					curtime = dt;
			}
			
			int dotstart;
			int lastslash = 0;
			int len;
			double res;
			
			string substring;
			string [] fileEntries = Directory.GetFiles(path);
		
			foreach (string filename in fileEntries)
			{
				if (!(filename.Contains(".exe")))
				{
				dotstart = filename.IndexOf('.');
				lastslash = filename.LastIndexOf('\\');
				len = dotstart - (lastslash + 1);
				Console.WriteLine(lastslash);
				Console.WriteLine(dotstart);
				Console.WriteLine(filename);
				
				substring = filename.Substring(lastslash + 1,len);
				Console.WriteLine(substring);
//				Console.ReadKey();
				res = Convert.ToDouble(substring);
				
//				Console.WriteLine(res);
				DateTime ntime = curtime.AddSeconds(res);
				//Copy fileinfo
				File.SetCreationTime(filename,ntime);
				File.SetLastWriteTime(filename,ntime);
				}

			}
			
			//Get time of first file
		
			Console.ReadKey();
			
		}
	}
}