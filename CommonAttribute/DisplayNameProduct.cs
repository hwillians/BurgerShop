using System;
using System.ComponentModel;

namespace CommonAttribute
{
	public class DisplaynamePrduct : DisplayNameAttribute
	{
		private readonly string resourceKey;
		private readonly Type type;

		public DisplaynamePrduct(Type type, string resourceKey)
		{
			this.type = type;
			this.resourceKey = resourceKey;
		}

		public override string DisplayName
		{
			get
			{
				return $"{resourceKey} {this.type.Name}";
			}
		}
	}
}