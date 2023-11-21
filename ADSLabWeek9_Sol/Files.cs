using System;
using System.Globalization;

public class Files
{

	public static int [,] readData (string fileName)
	{
		int [,] data = null;
		StreamReader sr = null;

		if(File.Exists(fileName))
		{
			sr = new StreamReader(File.OpenRead(fileName));
			string line = null;
			int row = 0, col = 0;

			while(!sr.EndOfStream)
			{
				row++;
				line = sr.ReadLine();
				var value = line.Split(",");
				col = value.Length;

			}
			data = new int[row,col];

			sr = new StreamReader(File.OpenRead(fileName));
			int i=0;
			while(!sr.EndOfStream)
			{
				var ln = sr.ReadLine();
				var value = ln.Split(",");

				if (i>0) //Avoid reading the first row
				{
					for (int j=1; j<value.Length; j++) //j starts from 1 to avoid reading the city
					{
						data[i-1,j-1] = Int32.Parse(value[j]);
					}
				}
				i++;
			}
		}
		return data;
	}

	public static string [] getCities(string fileName)
	{
		string [] cities = null;
		StreamReader sr = null;

		if (File.Exists(fileName))
		{
			sr = new StreamReader(fileName);
			string lines = sr.ReadLine();
			string [] header = lines.Split(","); 
			int len = header.Length;

			cities = new string [len-1]; //we dont need the "City" header.
			for (int i=1; i<header.Length; i++) //Read the first city until end
			{
				cities[i-1] = header[i];
			}

		}
		return cities;
	}

	public static void printData (int [,] data)
	{
		for (int i=0; i<data.GetLength(0); i++)
		{
			for (int j=0; j<data.GetLength(1); j++)
			{
				Console.Write(data[i,j]+" ");
			}
			Console.WriteLine();
		}
	}

	public static void printHeader(string [] cities)
	{
		foreach(string city in cities)
		{
			Console.WriteLine(city);
		}
	}

		
}

//©ZairulMazwan©