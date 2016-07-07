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
		return null;
	}

	public Chunk provideChunk(BlockPos blockPosIn)
	{
		return provideChunk (blockPosIn.x >> 4, blockPosIn.z >> 4);
	}

	/**
     * Checks to see if a chunk exists at x, z
     */
	public bool chunkExists(int x, int z)
	{
		return true;
	}

	/**
     * Returns if the IChunkProvider supports saving.
     */
	public bool canSave()
	{
		return true;
	}

	/**
     * Unloads chunks that are marked to be unloaded. This is not guaranteed to unload every such chunk.
     */
	public bool unloadQueuedChunks()
	{
		return false;
	}

	/**
     * Converts the instance data to a readable string.
     */
	public string makeString()
	{
		return "RandomLevelSource";
	}

	/**
     * Populates chunk with ores etc etc
     */
	public void populate(IChunkProvider p_73153_1_, int p_73153_2_, int p_73153_3_)
	{

	}

	public bool func_177460_a(IChunkProvider p_177460_1_, Chunk p_177460_2_, int p_177460_3_, int p_177460_4_)
	{
		return false;
	}

	/**
     * Two modes of operation: if passed true, save all Chunks in one go.  If passed false, save up to two chunks.
     * Return true if all chunks have been saved.
     */
	public bool saveChunks(bool p_73151_1_, IProgressUpdate progressCallback)
	{
		return true;
	}

	public void recreateStructures(Chunk p_180514_1_, int p_180514_2_, int p_180514_3_)
	{

	}

}
