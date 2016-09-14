using System;

namespace FileHelpers.Sample.Models
{
	[DelimitedRecord(";")]
	public class Customer
	{
		public string CustomerId;
		public string CompanyName;
		public string ContactName;
		public string ContactTitle;
		public string Address;
		public string City;
		public string Country;

		public override string ToString()
		{
			return "Customer: " + CustomerId + " - " + CompanyName + ", " + ContactName;
		}
	}

	[FixedLengthRecord]
	public class SampleType
	{
		[FieldFixedLength(8)]
		[FieldConverter(ConverterKind.Date, "ddMMyyyy")]
		public DateTime Field1;

		[FieldFixedLength(3)]
		[FieldAlign(AlignMode.Left, ' ')]
		[FieldTrim(TrimMode.Both)]
		public string Field2;

		[FieldFixedLength(3)]
		[FieldAlign(AlignMode.Right, '0')]
		[FieldTrim(TrimMode.Both)]
		public int Field3;

		public override string ToString()
		{
			return "SampleType: " + Field2 + " - " + Field3;
		}
	}

	[DelimitedRecord("|")]
	public class Orders
	{
		public int OrderId;

		public string CustomerId;

		public int EmployeeId;

		public DateTime OrderDate;

		public DateTime RequiredDate;

		[FieldNullValue(typeof(DateTime), "2005-1-1")]
		public DateTime ShippedDate;

		public int ShipVia;

		public decimal Freight;

		public override string ToString()
		{
			return "Orders: " + OrderId + " - " + CustomerId + " - " + Freight;
		}
	}
}