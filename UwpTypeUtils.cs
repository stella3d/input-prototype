using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.InputNew
{
	public static class UwpTypeUtils
	{
	    public static bool IsInstanceOfType(Type instance, object obj)
	    {
	        var objType = obj.GetType();
	        if (objType == instance || objType.GetTypeInfo().IsSubclassOf(instance))
	            return true;

	        return false;
	    }
	}
}
