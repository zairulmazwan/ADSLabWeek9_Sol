using System;
using System.Globalization;
using CsvHelper;

public class Files
{

	public static void readCSVFile (string fileName)
	{
		using var reader = new StreamReader(fileName);
		using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

		var data = csv.GetRecords<dynamic>();

		csv.Read();
		csv.ReadHeader();
		string[] headerRow = csv.HeaderRecord;

		foreach(var h in headerRow)
		{
			//Console.Write(h);
			Console.WriteLine(csv.GetRecord(h));

        }

		Console.WriteLine(csv.GetRecords<dynamic>(1));

        foreach (var row in data)
        {

            Console.WriteLine(row);
        }

    }
}

