using UnityEngine;
using System.Collections;

public class ChunkProviderServer : IChunkProvider {

	/**
     * chunk generator object. Calls to load nonexistent chunks are forwarded to this object.
     */
	private IChunkProvider serverChunkGenerator;

	public ChunkProviderServer(WorldServer worldServer, IChunkProvider chunkProvider)
	{

	}

	/**
     * Creates the chunk provider for this world. Called in the constructor. Retrieves provider from worldProvider?
     */
	protected IChunkProvider createChunkProvider()
	{


	}

	/**
     * Will return back a chunk, if it doesn't exist and its not a MP client it will generates all the blocks for the
     * specified chunk from the map seed and chunk seed
     */
	public Chunk provideChunk(int x, int z)
	{

	}

	/**
     * loads or generates the chunk at the chunk location specified
     */
	public Chunk loadChunk(int x, int z)
	{
		
	}
}
