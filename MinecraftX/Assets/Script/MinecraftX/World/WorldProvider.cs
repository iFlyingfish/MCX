using UnityEngine;
using System.Collections;

public abstract class WorldProvider {

	/** world object being used */
	protected World worldObj;
    
	/** world chunk manager being used to generate chunks */
	protected WorldChunkManager worldChunkMgr;

	public WorldChunkManager getWorldChunkManager()
	{
		return this.worldChunkMgr;
	}

	/**
     * Will check if the x, z position specified is alright to be set as the map spawn point
     */
	public bool canCoordinateBeSpawn(int x, int z)
	{
		 
	}
}
