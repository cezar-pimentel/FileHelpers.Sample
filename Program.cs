using FileHelpers.Sample.Models;
using System;

namespace FileHelpers.Sample
{
	internal class Program
	{
		private static void Main()
		{
			var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			var txtPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exePath, @"..\..\txts\sample.txt"));

			var engine = new MultiRecordEngine(typeof(Orders), typeof(Customer), typeof(SampleType)) { RecordSelector = CustomSelector };
			var res = engine.ReadFile(txtPath);

			foreach (var rec in res)
				Console.WriteLine(rec.ToString());

			Console.WriteLine("\nFINISHED!");
			Console.Read();
		}

		private static Type CustomSelector(MultiRecordEngine engine, string recordLine)
		{
			if (recordLine.Length == 0)
				return null;

			if (char.IsLetter(recordLine[0]))
				return typeof(Customer);
			else if (recordLine.Length == 14)
				return typeof(SampleType);
			else
				return typeof(Orders);
		}
	}
}