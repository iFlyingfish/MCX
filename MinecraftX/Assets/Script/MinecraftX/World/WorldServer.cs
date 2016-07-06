using UnityEngine;
using System.Collections;

public class WorldServer : World {

	public ChunkProviderServer theChunkProviderServer;

	public WorldServer()
	{
		World(WorldProvider.getProviderForDimension());
		chunkProvider = createChunkProvider ();
	}

	public void initialize()
	{

	}

	/**
     * creates a spawn position at random within 256 blocks of 0,0
     */
	private void createSpawnPosition()
	{

	}

	/**
     * Creates the chunk provider for this world. Called in the constructor. Retrieves provider from worldProvider?
     */
	protected IChunkProvider createChunkProvider()
	{
		theChunkProviderServer = new ChunkProviderServer (this, provider.createChunkGenerator ());
		return theChunkProviderServer;
	}

	protected void updateBlocks()
	{

	}

	public void tick()
	{

	}

	/**
     * Gets the spawn point in the world
     */
	public BlockPos getSpawnPoint()
	{

	}
		
}
