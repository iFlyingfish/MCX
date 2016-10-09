using UnityEngine;
using System.Collections;

public class ChunkProviderGenerate : IChunkProvider {

	private readonly double[] field_147434_q;
	private World worldObj;

	/** The biomes that are used to generate the chunk */
	private BiomeGenBase[] biomesForGeneration;

	public ChunkProviderGenerate(World worldIn, int seed, bool generateStructures, string generatorSettings)
	{
		worldObj = worldIn;
		field_147434_q = new double[825];

	}

	public void setBlocksInChunk(int x, int z, ChunkPrimer chunkPrimer)
	{
		for (int i = 0; i < 4; ++i)
		{
			int j = i * 5;
			int k = (i + 1) * 5;

			for (int l = 0; l < 4; ++l)
			{
				int i1 = (j + l) * 33;
				int j1 = (j + l + 1) * 33;
				int k1 = (k + l) * 33;
				int l1 = (k + l + 1) * 33;

				for (int i2 = 0; i2 < 32; ++i2)
				{
					double d0 = 0.125D;
					double d1 = this.field_147434_q[i1 + i2];
					double d2 = this.field_147434_q[j1 + i2];
					double d3 = this.field_147434_q[k1 + i2];
					double d4 = this.field_147434_q[l1 + i2];
					double d5 = (this.field_147434_q[i1 + i2 + 1] - d1) * d0;
					double d6 = (this.field_147434_q[j1 + i2 + 1] - d2) * d0;
					double d7 = (this.field_147434_q[k1 + i2 + 1] - d3) * d0;
					double d8 = (this.field_147434_q[l1 + i2 + 1] - d4) * d0;

					for (int j2 = 0; j2 < 8; ++j2)
					{
						double d9 = 0.25D;
						double d10 = d1;
						double d11 = d2;
						double d12 = (d3 - d1) * d9;
						double d13 = (d4 - d2) * d9;

						for (int k2 = 0; k2 < 4; ++k2)
						{
							double d14 = 0.25D;
							double d16 = (d11 - d10) * d14;
							double lvt_45_1_ = d10 - d16;

							for (int l2 = 0; l2 < 4; ++l2)
							{
								if ((lvt_45_1_ += d16) > 0.0D)
								{
									chunkPrimer.setBlockState(i * 4 + k2, i2 * 8 + j2, l * 4 + l2, Blocks.stone.getDefaultState());
								}
//								else if (i2 * 8 + j2 < this.settings.seaLevel)
//								{
//									chunkPrimer.setBlockState(i * 4 + k2, i2 * 8 + j2, l * 4 + l2, this.field_177476_s.getDefaultState());
//								}
							}

							d10 += d12;
							d11 += d13;
						}

						d1 += d5;
						d2 += d6;
						d3 += d7;
						d4 += d8;
					}
				}
			}
		}
	}

	/**
     * Will return back a chunk, if it doesn't exist and its not a MP client it will generates all the blocks for the
     * specified chunk from the map seed and chunk seed
     */
	public Chunk provideChunk(int x, int z)
	{
		ChunkPrimer chunkprimer = new ChunkPrimer ();
		setBlocksInChunk (x, z, chunkprimer);
		biomesForGeneration = worldObj.getWorldChunkManager ().loadBlockGeneratorData (biomesForGeneration, x * MinecraftConfig.chunkSize, z * MinecraftConfig.chunkSize, MinecraftConfig.chunkSize, MinecraftConfig.chunkSize);

		Chunk chunk = new Chunk (worldObj, chunkprimer, x, z);
		byte[] abyte = chunk.getBiomeArray ();
//		for (int i = 0; i < abyte.Length; ++i) {
//			abyte [i] = (byte)biomesForGeneration [i].biomeID;
//		}

		return chunk;
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
