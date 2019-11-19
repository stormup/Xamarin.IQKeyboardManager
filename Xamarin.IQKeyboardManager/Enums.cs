using System;
using ObjCRuntime;

namespace Xamarin
{
	[Native]
	public enum IQAutoToolbarManageBehaviour : long
	{
		BySubviews,
		ByTag,
		ByPosition
	}

	[Native]
	public enum IQPreviousNextDisplayMode : long
	{
		Default,
		AlwaysHide,
		AlwaysShow
	}

	[Native]
	public enum IQLayoutGuidePosition : long
	{
		None,
		Top,
		Bottom
	}

	[Native]
	public enum IQEnableMode : long
	{
		Default,
		Enabled,
		Disabled
	}
}

