using UnityEngine;
using System.Collections;

public class World : IBlockAccess {

	/** The WorldProvider instance that World uses. */
	public readonly WorldProvider provider;

	/** Handles chunk operations and caching */
	protected IChunkProvider chunkProvider;

	protected World(WorldProvider providerIn)
	{
		provider = providerIn;
	}

	public WorldChunkManager getWorldChunkManager()
	{
		return this.provider.getWorldChunkManager();
	}

	public int getSeed()
	{
		return 0;
	}

	public IBlockState getBlockState(BlockPos pos)
	{
		//Chunk chunk = getChunkFromBlockCoords (pos);
	
	}

	/**
     * Checks to see if an air block exists at the provided location. Note that this only checks to see if the blocks
     * material is set to air, meaning it is possible for non-vanilla blocks to still pass this check.
     */
	public bool isAirBlock(BlockPos pos)
	{

	}

	public Chunk getChunkFromBlockCoords(BlockPos pos)
	{

	}

	/**
     * Returns back a chunk looked up by chunk coordinates Args: x, y
     */
	public Chunk getChunkFromChunkCoords(int chunkX, int chunkZ)
	{

	}
}
