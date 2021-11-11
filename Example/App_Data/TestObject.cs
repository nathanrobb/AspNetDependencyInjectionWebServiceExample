using System;
using System.Web;
using AspNetDependencyInjection;

namespace Example.App_Data
{
	public class TestObject
	{
		private readonly string _instanceId = Guid.NewGuid().ToString().ToUpper();

		private readonly IHttpContextAccessor _context;

		public TestObject(IHttpContextAccessor context)
		{
			_context = context;
		}

		public string Get() => $"{DateTime.UtcNow:O} - [Instance: {_instanceId}] [Context (DI) HashCode: {_context.HttpContext?.GetHashCode()}] [Context (Thread) HashCode: {HttpContext.Current?.GetHashCode()}]";
	}
}
