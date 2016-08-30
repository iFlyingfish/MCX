using UnityEngine;
using System.Collections;

public class World : IBlockAccess {

	/** The WorldProvider instance that World uses. */
	public readonly WorldProvider provider;

	/** Handles chunk operations and caching */
	protected IChunkProvider chunkProvider;


	/**
     * holds information about a world (size on disk, time, spawn point, seed, ...)
     */
	protected WorldInfo worldInfo;

	protected World()
	{

	}

	protected World(WorldInfo info, WorldProvider providerIn)
	{
		worldInfo = info;
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
		Chunk chunk = getChunkFromBlockCoords (pos);
		return chunk.getBlockState (pos);
	}

	/**
     * Checks to see if an air block exists at the provided location. Note that this only checks to see if the blocks
     * material is set to air, meaning it is possible for non-vanilla blocks to still pass this check.
     */
	public bool isAirBlock(BlockPos pos)
	{
		return false;
	}

	public Chunk getChunkFromBlockCoords(BlockPos pos)
	{
		return getChunkFromChunkCoords (pos.x >> MinecraftConfig.chunkBitSize , pos.y >> MinecraftConfig.chunkBitSize);
	}

	/**
     * Returns back a chunk looked up by chunk coordinates Args: x, y
     */
	public Chunk getChunkFromChunkCoords(int chunkX, int chunkZ)
	{
		return chunkProvider.provideChunk (chunkX, chunkZ);
	}

	/**
     * Gets the spawn point in the world
     */
	public BlockPos getSpawnPoint()
	{
		BlockPos blockpos = new BlockPos (worldInfo.spawnX, worldInfo.spawnY, worldInfo.spawnZ);


		return blockpos;


	}
}
