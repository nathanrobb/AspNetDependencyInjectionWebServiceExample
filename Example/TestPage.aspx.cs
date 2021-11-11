using System;
using System.Diagnostics;
using System.Web.UI;
using Example.App_Data;

namespace Example
{
	public partial class TestPage : Page
	{
		private readonly TestObject _testObject;

		public TestPage(TestObject testObject)
		{
			_testObject = testObject;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Debugger.Log(1, "log", $"ASP Page [{_testObject.Get()}]{Environment.NewLine}");

			lbTestLabel.InnerText = _testObject.Get();
		}
	}
}
