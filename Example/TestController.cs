using System;
using System.Diagnostics;
using System.Web.Http;
using Example.App_Data;

namespace Example
{
	[AllowAnonymous]
	[RoutePrefix("api/test")]
	public class TestController : ApiController
	{
		private readonly TestObject _testObject;

		public TestController(TestObject testObject)
		{
			_testObject = testObject;
		}

		// GET http://localhost:56145/api/test
		[HttpGet]
		[Route]
		public string Get()
		{
			Debugger.Log(1, "log", $"Controller [{_testObject.Get()}]{Environment.NewLine}");

			return $"Hello World = {_testObject.Get()}";
		}
	}
}
