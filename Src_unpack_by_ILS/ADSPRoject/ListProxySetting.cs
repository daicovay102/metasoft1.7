using System;
using System.Collections.Generic;
using ADSPRoject.Data;

namespace ADSPRoject;

public class ListProxySetting
{
	public List<ProxySocksEntity> listProxy = (List<ProxySocksEntity>)Activator.CreateInstance(typeof(List<ProxySocksEntity>));

	public int intThread { get; set; }

	public int intDelay { get; set; }

	public bool isRandom { get; set; }

	public bool isProxy { get; set; }
}
