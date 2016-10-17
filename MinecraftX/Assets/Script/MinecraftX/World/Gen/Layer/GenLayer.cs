﻿using UnityEngine;
using System.Collections;

public abstract class GenLayer {

	/** seed from World#getWorldSeed that is used in the LCG prng */
	protected long worldGenSeed;

	/** parent GenLayer that was provided via the constructor */
	protected GenLayer parent;

	/**
     * final part of the LCG prng that uses the chunk X, Z coords along with the other two seeds to generate
     * pseudorandom numbers
     */
	private long chunkSeed;

	/** base seed to the LCG prng provided via the constructor */
	protected long baseSeed;

	public GenLayer(long seed)
	{
		baseSeed = seed;
		baseSeed *= baseSeed * 6364136223846793005L + 6364136223846793005L;
		baseSeed += seed;
		baseSeed *= this.baseSeed * 6364136223846793005L + 1442695040888963407L;
		baseSeed += seed;
		baseSeed *= this.baseSeed * 6364136223846793005L + 1442695040888963407L;
		baseSeed += seed;
	}

	/**
     * Returns a list of integer values generated by this layer. These may be interpreted as temperatures, rainfall
     * amounts, or biomeList[] indices based on the particular GenLayer subclass.
     */
	public abstract int[] getInts(int areaX, int areaY, int areaWidth, int areaHeight);

	protected static bool biomesEqualOrMesaPlateau(int biomeIDA, int biomeIDB)
	{
		
		if (biomeIDA == biomeIDB) {
			return true;
		} else if (biomeIDA != BiomeGenBase.mesaPlateau_F.biomeID && biomeIDA != BiomeGenBase.mesaPlateau.biomeID) {
			 BiomeGenBase biomegenbase = BiomeGenBase.getBiome (biomeIDA);
			 BiomeGenBase biomegenbase1 = BiomeGenBase.getBiome (biomeIDB);
		
			return (biomegenbase != null && biomegenbase1 != null) ? biomegenbase.isEqualTo (biomegenbase1) : false;
		} else {
			return biomeIDB == BiomeGenBase.mesaPlateau_F.biomeID || biomeIDB == BiomeGenBase.mesaPlateau.biomeID; 
		}
	}

	/**
     * Initialize layer's local worldGenSeed based on its own baseSeed and the world's global seed (passed in as an
     * argument).
     */
	public void initWorldGenSeed(long seed)
	{
		worldGenSeed = seed;

		if (this.parent != null)
		{
			this.parent.initWorldGenSeed(seed);
		}

		worldGenSeed *= worldGenSeed * 6364136223846793005L + 1442695040888963407L;
		worldGenSeed += baseSeed;
		worldGenSeed *= worldGenSeed * 6364136223846793005L + 1442695040888963407L;
		worldGenSeed += baseSeed;
		worldGenSeed *= worldGenSeed * 6364136223846793005L + 1442695040888963407L;
		worldGenSeed += baseSeed;
	}

	/**
     * Initialize layer's current chunkSeed based on the local worldGenSeed and the (x,z) chunk coordinates.
     */
	public void initChunkSeed(long p_75903_1_, long p_75903_3_)
	{
		chunkSeed = worldGenSeed;
		chunkSeed *= chunkSeed * 6364136223846793005L + 1442695040888963407L;
		chunkSeed += p_75903_1_;
		chunkSeed *= chunkSeed * 6364136223846793005L + 1442695040888963407L;
		chunkSeed += p_75903_3_;
		chunkSeed *= chunkSeed * 6364136223846793005L + 1442695040888963407L;
		chunkSeed += p_75903_1_;
		chunkSeed *= chunkSeed * 6364136223846793005L + 1442695040888963407L;
		chunkSeed += p_75903_3_;
	}

	/**
     * returns a LCG pseudo random number from [0, x). Args: int x
     */
	protected int nextInt(int p_75902_1_)
	{
		int i = (int)((chunkSeed >> 24) % (long)p_75902_1_);

		if (i < 0)
		{
			i += p_75902_1_;
		}

		chunkSeed *= chunkSeed * 6364136223846793005L + 1442695040888963407L;
		chunkSeed += worldGenSeed;
		return i;
	}

	/**
     * returns true if the biomeId is one of the various ocean biomes.
     */
	protected static bool isBiomeOceanic(int p_151618_0_)
	{
		return p_151618_0_  == BiomeGenBase.deepOcean.biomeID; // not added ocean and frozen ocean yet
	}

	/**
     * selects a random integer from a set of provided integers
     */
	protected int selectRandom(params int[] p_151619_1_)
	{
		return p_151619_1_[nextInt(p_151619_1_.Length)];
	}

	/**
     * returns the most frequently occurring number of the set, or a random number from those provided
     */
	protected int selectModeOrRandom(int p_151617_1_, int p_151617_2_, int p_151617_3_, int p_151617_4_)
	{
		return p_151617_2_ == p_151617_3_ && p_151617_3_ == p_151617_4_ ? p_151617_2_ : (p_151617_1_ == p_151617_2_ && p_151617_1_ == p_151617_3_ ? p_151617_1_ : (p_151617_1_ == p_151617_2_ && p_151617_1_ == p_151617_4_ ? p_151617_1_ : (p_151617_1_ == p_151617_3_ && p_151617_1_ == p_151617_4_ ? p_151617_1_ : (p_151617_1_ == p_151617_2_ && p_151617_3_ != p_151617_4_ ? p_151617_1_ : (p_151617_1_ == p_151617_3_ && p_151617_2_ != p_151617_4_ ? p_151617_1_ : (p_151617_1_ == p_151617_4_ && p_151617_2_ != p_151617_3_ ? p_151617_1_ : (p_151617_2_ == p_151617_3_ && p_151617_1_ != p_151617_4_ ? p_151617_2_ : (p_151617_2_ == p_151617_4_ && p_151617_1_ != p_151617_3_ ? p_151617_2_ : (p_151617_3_ == p_151617_4_ && p_151617_1_ != p_151617_2_ ? p_151617_3_ : this.selectRandom(new int[] {p_151617_1_, p_151617_2_, p_151617_3_, p_151617_4_}))))))))));
	}
}
