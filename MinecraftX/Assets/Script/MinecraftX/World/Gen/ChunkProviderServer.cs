using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkProviderServer : IChunkProvider {


	private Dictionary<long,Chunk> id2ChunkDic = new Dictionary<long,Chunk> ();
	private List<Chunk> loadedChunks = new List<Chunk> ();
	private WorldServer worldObj;

	/**
     * chunk generator object. Calls to load nonexistent chunks are forwarded to this object.
     */
	private IChunkProvider serverChunkGenerator;

	public ChunkProviderServer(WorldServer worldServer, IChunkProvider chunkProvider)
	{
		worldObj = worldServer;
		serverChunkGenerator = chunkProvider;
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
		long chunkID = ChunkCoordIntPair.chunkXZ2Int (x, z);
		Chunk chunk = (Chunk)id2ChunkDic [chunkID];

		if (chunk == null) {

			if (serverChunkGenerator == null) {

			} else {
				chunk = serverChunkGenerator.provideChunk (x, z);
			}
		}

		id2ChunkDic.Add (chunkID, chunk);
		loadedChunks.Add (chunk);
		chunk.onChunkLoad ();
		chunk.populateChunk (this, this, x, z);

		return chunk;
	}
}
