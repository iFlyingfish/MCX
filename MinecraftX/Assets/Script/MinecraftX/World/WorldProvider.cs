using UnityEngine;
using System.Collections;

public abstract class WorldProvider {

	/** world object being used */
	protected World worldObj;
	private WorldType terrainType; 
    
	/** world chunk manager being used to generate chunks */
	protected WorldChunkManager worldChunkMgr;

	public static WorldProvider getProviderForDimension()
	{
		return (WorldProvider)(new WorldProviderSurface ());
	}

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

	/**
     * Returns a new chunk provider which generates chunks for this world
     */
	public IChunkProvider createChunkGenerator()
	{
		return (IChunkProvider)(terrainType == WorldType.FLAT ? new ChunkProviderFlat(worldObj, 0, true, "") : (terrainType == WorldType.DEFAULT ? new ChunkProviderGenerate(worldObj, 0, true, "") : new ChunkProviderGenerate(worldObj, 0, true, ""));
	}
}
