using System;

namespace Example.App_Data
{
	public class TestObject
	{
		private readonly string _instanceId = Guid.NewGuid().ToString().ToUpper();

		public string Get() => $"{DateTime.UtcNow:O} - [Instance: {_instanceId}]";
	}
}
