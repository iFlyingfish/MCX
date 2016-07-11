using UnityEngine;
using System.Collections;

public class Chunk {

	/**
     * Used to store block IDs, block MSBs, Sky-light maps, Block-light maps, and metadata. Each entry corresponds to a
     * logical segment of 16x16x16 blocks, stacked vertically.
     */
	private readonly ExtendBlockStorage[] storageArrays;

	public Chunk(World worldIn, ChunkPrimer primer, int x, int z)
    {
      
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
}
