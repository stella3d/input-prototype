using System;
using System.Collections.Generic;

namespace UnityEngine.InputNew
{
	[Serializable]
	public class InputControlDescriptor
	{
		public int controlIndex;

		public Type deviceType
		{
			get
			{
				if ( m_CachedDeviceType == null )
				{
					if (m_DeviceTypeName == null)
						return null;
					m_CachedDeviceType = Type.GetType( m_DeviceTypeName );
				}
				return m_CachedDeviceType;
			}
			set
			{
				m_CachedDeviceType = value;
				m_DeviceTypeName = m_CachedDeviceType.AssemblyQualifiedName;
			}
		}

		[ SerializeField ]
		private string m_DeviceTypeName;

		private Type m_CachedDeviceType;

		public virtual InputControlDescriptor Clone()
		{
			var clone = (InputControlDescriptor) Activator.CreateInstance(GetType());
			clone.controlIndex = controlIndex;
			clone.m_DeviceTypeName = m_DeviceTypeName;
			clone.m_CachedDeviceType = m_CachedDeviceType;
			return clone;
		}
		
		public override string ToString()
		{
			return string.Format( "(device:{0}, control:{1})", deviceType.Name, controlIndex );
		}
		
		public void ExtractDeviceTypeAndControlIndex(Dictionary<Type, List<int>> controlIndicesPerDeviceType)
		{
			List<int> entries;
			if (!controlIndicesPerDeviceType.TryGetValue(deviceType, out entries))
			{
				entries = new List<int>();
				controlIndicesPerDeviceType[deviceType] = entries;
			}
			
			entries.Add(controlIndex);
		}
	}
}
