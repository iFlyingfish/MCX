using UnityEngine;
using System.Collections;

public abstract class WorldProvider {

	/** world object being used */
	protected World worldObj;
	private WorldType terrainType = WorldType.DEFAULT;

	/** world chunk manager being used to generate chunks */
	protected WorldChunkManager worldChunkMgr;

	/**
     * associate an existing world with a World provider, and setup its lightbrightness table
     */
	public void registerWorld(World worldIn)
	{
		worldObj = worldIn;
		registerWorldChunkManager ();
	}

	/**
     * creates a new world chunk manager for WorldProvider
     */
	protected void registerWorldChunkManager()
	{
		worldChunkMgr = new WorldChunkManager (worldObj);
	}

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
		return true;
	}

	/**
     * Returns a new chunk provider which generates chunks for this world
     */
	public IChunkProvider createChunkGenerator()
	{
		return terrainType == WorldType.FLAT ? (IChunkProvider)(new ChunkProviderFlat(worldObj, 0, true, "")) : (terrainType == WorldType.DEFAULT ? (IChunkProvider)(new ChunkProviderGenerate(worldObj, 0, true, "")) : (IChunkProvider)(new ChunkProviderGenerate(worldObj, 0, true, "")));
	}
}
