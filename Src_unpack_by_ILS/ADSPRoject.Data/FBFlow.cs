using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSPRoject.Data;

public class FBFlow
{
	public List<FBFlowField> Filed = (List<FBFlowField>)Activator.CreateInstance(typeof(List<FBFlowField>));

	public string Flow_Name { get; set; }

	public T0 getValue<T0, T1, T2, T3>(T3 key)
	{
		//IL_003c: Expected O, but got I4
		string key2 = (string)key;
		T0 result = (T0)null;
		T1 val = (T1)((IEnumerable<FBFlowField>)Filed).Where((Func<FBFlowField, bool>)((FBFlowField a) => (T2)a.key.ToLower().Equals(key2.ToLower()))).ToList();
		T2 val2 = (T2)(val != null && ((List<FBFlowField>)val).Count > 0);
		if (val2 != null)
		{
			result = (T0)((IEnumerable<FBFlowField>)val).First().value;
		}
		return result;
	}
}
