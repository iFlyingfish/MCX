﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockPos
{

}

public interface IProgressUpdate
{

}

static public class Height
{

}

public class SpawnListEntry
{


}

public enum EnumCreatureType
{
	
}

public interface IChunkProvider {

	/**
     * Checks to see if a chunk exists at x, z
     */
	bool chunkExists(int x, int z);

	/**
     * Will return back a chunk, if it doesn't exist and its not a MP client it will generates all the blocks for the
     * specified chunk from the map seed and chunk seed
     */
	Chunk provideChunk(int x, int z);

	Chunk provideChunk(BlockPos blockPosIn);

	/**
     * Populates chunk with ores etc etc
     */
	void populate(IChunkProvider p_73153_1_, int p_73153_2_, int p_73153_3_);

	bool func_177460_a(IChunkProvider p_177460_1_, Chunk p_177460_2_, int p_177460_3_, int p_177460_4_);

	/**
     * Two modes of operation: if passed true, save all Chunks in one go.  If passed false, save up to two chunks.
     * Return true if all chunks have been saved.
     */
	bool saveChunks(bool p_73151_1_, IProgressUpdate progressCallback);

	/**
     * Unloads chunks that are marked to be unloaded. This is not guaranteed to unload every such chunk.
     */
	bool unloadQueuedChunks();

	/**
     * Returns if the IChunkProvider supports saving.
     */
	bool canSave();

	/**
     * Converts the instance data to a readable string.
     */
	string makeString();

	List<SpawnListEntry> getPossibleCreatures(EnumCreatureType creatureType, BlockPos pos);

	BlockPos getStrongholdGen(World worldIn, string structureName, BlockPos position);

	int getLoadedChunkCount();

	void recreateStructures(Chunk p_180514_1_, int p_180514_2_, int p_180514_3_);

	/**
     * Save extra data not associated with any Chunk.  Not saved during autosave, only during world unload.  Currently
     * unimplemented.
     */
	void saveExtraData();

}
