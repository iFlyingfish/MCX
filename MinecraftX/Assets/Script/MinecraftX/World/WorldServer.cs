using UnityEngine;
using System.Collections;

public class WorldServer : World {

	public ChunkProviderServer theChunkProviderServer;

	public WorldServer()
	{


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
