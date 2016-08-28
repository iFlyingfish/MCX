using UnityEngine;
using System.Collections;

public class WorldProviderSurface : WorldProvider {
	/**
     * Returns the dimension's name, e.g. "The End", "Nether", or "Overworld".
     */
	public string getDimensionName()
	{
		return "Overworld";
	}
}
