using UnityEngine;
using System.Collections;

public class ChunkProviderGenerate : IChunkProvider {

	public ChunkProviderGenerate(World worldIn, int seed, bool generateStructures, string generatorSettings)
	{


	}

	/**
     * Will return back a chunk, if it doesn't exist and its not a MP client it will generates all the blocks for the
     * specified chunk from the map seed and chunk seed
     */
	public Chunk provideChunk(int x, int z)
	{


	}
}
