using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BiomeCache{

	/** Reference to the WorldChunkManager */
	private readonly WorldChunkManager chunkManager;

	/** The last time this BiomeCache was cleaned, in milliseconds. */
	private long lastCleanupTime;
	private Dictionary<long,BiomeCache.Block> cacheMap = new Dictionary<long, BiomeCache.Block> (); //originally some Class HashMap
	private List<BiomeCache.Block> cache = new List<BiomeCache.Block> ();

	public BiomeCache(WorldChunkManager chunkManagerIn)
	{
		chunkManager = chunkManagerIn;
	}

	/**
     * Returns a biome cache block at location specified.
     */
	public BiomeCache.Block getBiomeCacheBlock(int x, int z)
	{
		x = x >> MinecraftConfig.chunkBitSize;
		z = z >> MinecraftConfig.chunkBitSize;
		long i = (long)x & 4294967295L | ((long)z & 4294967295L) << 32;
		BiomeCache.Block biomecache_block = null;
		if (cacheMap.ContainsKey (i)) {
		   biomecache_block = (BiomeCache.Block)cacheMap [i];
		}

		if (biomecache_block == null)
		{
			biomecache_block = new BiomeCache.Block(x, z, this);
			cacheMap.Add(i, biomecache_block);
			this.cache.Add(biomecache_block);
		}

		biomecache_block.lastAccessTime = MinecraftServer.getCurrentTimeMillis();
		return biomecache_block;
	}

	/**
     * Returns the array of cached biome types in the BiomeCacheBlock at the given location.
     */
	public BiomeGenBase[] getCachedBiomes(int x, int z)
	{
		return  getBiomeCacheBlock(x, z).biomes;
	}
		

	public class Block
	{
		public float[] rainfallValues = new float[256];
		public BiomeGenBase[] biomes = new BiomeGenBase[256];
		public int xPosition;
		public int zPosition;
		public long lastAccessTime;

		public Block(int x, int z, BiomeCache biomeCache)
		{
			xPosition = x;
			zPosition = z;
			biomeCache.chunkManager.getRainfall(rainfallValues, x << MinecraftConfig.chunkBitSize, z << MinecraftConfig.chunkBitSize, MinecraftConfig.chunkSize, MinecraftConfig.chunkSize);
			biomeCache.chunkManager.getBiomeGenAt(biomes, x << MinecraftConfig.chunkBitSize, z << MinecraftConfig.chunkBitSize, MinecraftConfig.chunkSize, MinecraftConfig.chunkSize, false);
		}

		public BiomeGenBase getBiomeGenAt(int x, int z)
		{
			return biomes [x & (MinecraftConfig.chunkSize - 1) | (z & (MinecraftConfig.chunkSize - 1)) << MinecraftConfig.chunkBitSize]; 
		}
	}
}
