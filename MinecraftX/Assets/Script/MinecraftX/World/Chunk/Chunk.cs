using UnityEngine;
using System.Collections;

public class Chunk {

	/**
     * Used to store block IDs, block MSBs, Sky-light maps, Block-light maps, and metadata. Each entry corresponds to a
     * logical segment of 16x16x16 blocks, stacked vertically.
     */
	private readonly ExtendBlockStorage[] storageArrays;

	/**
     * Contains a 16x16 mapping on the X/Z plane of the biome ID to which each colum belongs.
     */
	private readonly byte[] blockBiomeArray;

	public Chunk(World worldIn, ChunkPrimer primer, int x, int z)
    {
		blockBiomeArray = new byte[MinecraftConfig.chunkSize * MinecraftConfig.chunkSize];
    }

	/**
     * Called when this Chunk is loaded by the ChunkProvider
     */
	public void onChunkLoad()
	{

	}

	public void populateChunk(IChunkProvider p_76624_1_, IChunkProvider p_76624_2_, int p_76624_3_, int p_76624_4_)
	{

	}

	public IBlockState getBlockState(BlockPos pos)
	{
		if (pos.y >= 0 && pos.y >> MinecraftConfig.chunkBitSize < storageArrays.Length) {
			ExtendBlockStorage extendedblockstorage = storageArrays [pos.y >> 4];

			if (extendedblockstorage != null) {
				int j = pos.x & (MinecraftConfig.chunkSize - 1);
				int k = pos.y & (MinecraftConfig.chunkSize - 1);
				int i = pos.z & (MinecraftConfig.chunkSize - 1);
				return extendedblockstorage.get (j, k, i);
			}

		}

		return Blocks.air.getDefaultState ();
	}

	/**
     * Returns an array containing a 16x16 mapping on the X/Z of block positions in this Chunk to biome IDs.
     */
	public byte[] getBiomeArray()
	{
		return blockBiomeArray;
	}

	/**
     * Accepts a 256-entry array that contains a 16x16 mapping on the X/Z plane of block positions in this Chunk to
     * biome IDs.
     */
	public void setBiomeArray(byte[] biomeArray)
	{
		if (blockBiomeArray.Length != biomeArray.Length) {
			Debug.LogErrorFormat ("Could not set level chunk biomes, array length is {0} instead of {1}", biomeArray.Length, blockBiomeArray.Length);
		} else {
			for (int i = 0; i < blockBiomeArray.Length; ++i) {
				blockBiomeArray [i] = biomeArray [i];
			}
		}
	}
}
