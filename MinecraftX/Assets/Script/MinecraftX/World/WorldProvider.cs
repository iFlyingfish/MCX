using UnityEngine;
using System.Collections;

public class WorldProvider {

	/** World chunk manager being used to generate chunks */
	protected WorldChunkManager worldChunkMgr;

	public WorldChunkManager getWorldChunkManager()
	{
		return this.worldChunkMgr;
	}
}
