using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Services;
using Example.App_Data;

namespace Example
{
	[ScriptService]
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class Test : WebService
	{
		private readonly TestObject _testObject;

		// Hacks
		public Test() : this(AppStartDependencyInjection.GetService<TestObject>())
		{
		}

		public Test(TestObject testObject)
		{
			_testObject = testObject;
		}

		// http://localhost:56145/Test.asmx?op=HelloWorld
		[WebMethod]
		public string HelloWorld()
		{
			Debugger.Log(1, "log", $"WebService [{_testObject.Get()}]{Environment.NewLine}");

			return $"Hello World = {_testObject.Get()}";
		}
	}
}
