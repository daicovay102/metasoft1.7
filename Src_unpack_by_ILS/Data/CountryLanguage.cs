using System;
using System.Collections.Generic;

namespace Data;

[Serializable]
public class CountryLanguage
{
	public string ISO { get; set; }

	public string PrimaryLanguage { get; set; }

	public List<CountryEntity> CountryName { get; set; }
}
