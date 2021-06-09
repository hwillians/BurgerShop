using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;

namespace WebBurger.Binders
{
	public class FloatingTypeModelBinderProvider : IModelBinderProvider
	{
		internal static readonly NumberStyles SupportedStyles = NumberStyles.Float | NumberStyles.AllowThousands; //value = 231

		/// <inheritdoc />
		public IModelBinder GetBinder(ModelBinderProviderContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			Type underlyingOrModelType = context.Metadata.UnderlyingOrModelType;
			if (underlyingOrModelType == typeof(decimal))
			{
				return new DecimalModelBinder(FloatingTypeModelBinderProvider.SupportedStyles);
			}
			if (underlyingOrModelType == typeof(double))
			{
				return new DoubleModelBinder(FloatingTypeModelBinderProvider.SupportedStyles);
			}
			if (underlyingOrModelType == typeof(float))
			{
				return new FloatModelBinder(FloatingTypeModelBinderProvider.SupportedStyles);
			}
			return null;
		}
	}
}