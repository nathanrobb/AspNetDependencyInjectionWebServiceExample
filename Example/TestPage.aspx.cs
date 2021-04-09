using System;
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
			lbTestLabel.InnerText = _testObject.Get();
		}
	}
}
