using UnityEngine;
using System.Collections;

public class WorldChunkManager {

	private GenLayer genBiomes;

	/** A GenLayer containing the indices into BiomeGenBase.biomeList[] */
	private GenLayer biomeIndexLayer;

	/** The biome list. */
	private BiomeCache biomeCache;
	private string field_180301_f;


	protected WorldChunkManager()
	{
		biomeCache = new BiomeCache (this);
	}

	public WorldChunkManager(long seed, WorldType worldType, string worldGeneratorOptions) : this()
	{
		//to be implemented the POINT!
		field_180301_f = worldGeneratorOptions;
		GenLayer[] agenLayer = GenLayer.initializeAllBiomeGenerators(seed, worldType, worldGeneratorOptions);
		genBiomes = agenLayer [0];
		biomeIndexLayer = agenLayer [1];
	}

	public WorldChunkManager (World worldIn) : this (worldIn.getSeed (), worldIn.getWorldInfo ().getTerrainType (), worldIn.getWorldInfo ().getGeneratorOptions ())
	{
		
	}

	/**
     * Returns biomes to use for the blocks and loads the other data like temperature and humidity onto the
     * WorldChunkManager Args: oldBiomeList, x, z, width, depth
     */
	public BiomeGenBase[] loadBlockGeneratorData(BiomeGenBase[] oldBiomeList, int x, int z, int width, int depth)
	{
		return this.getBiomeGenAt(oldBiomeList, x, z, width, depth, true);
	}

	/**
     * Return a list of biomes for the specified blocks. Args: listToReuse, x, y, width, length, cacheFlag (if false,
     * don't check biomeCache to avoid infinite loop in BiomeCacheBlock)
     */
	public BiomeGenBase[] getBiomeGenAt(BiomeGenBase[] listToReuse, int x, int z, int width, int length, bool cacheFlag)
	{
//		IntCache.resetIntCache();

		if (listToReuse == null || listToReuse.Length < width * length)
		{
			listToReuse = new BiomeGenBase[width * length];
		}

		if (cacheFlag && width == 16 && length == 16 && (x & 15) == 0 && (z & 15) == 0)
		{
			BiomeGenBase[] abiomegenbase = biomeCache.getCachedBiomes(x, z);
			System.Array.Copy (abiomegenbase, 0, listToReuse, 0, width * length);
			return listToReuse;
		}
		else
		{
			int[] aint = biomeIndexLayer.getInts(x, z, width, length);

			for (int i = 0; i < width * length; ++i)
			{
				listToReuse[i] = BiomeGenBase.getBiomeFromBiomeList(aint[i], BiomeGenBase.field_180279_ad);
			}

			return listToReuse;
		}
	}

	/**
     * Returns a list of rainfall values for the specified blocks. Args: listToReuse, x, z, width, length.
     */
	public float[] getRainfall(float[] listToReuse, int x, int z, int width, int length)
	{
		IntCache.resetIntCache();

		if (listToReuse == null || listToReuse.Length < width * length)
		{
			listToReuse = new float[width * length];
		}

		int[] aint = this.biomeIndexLayer.getInts(x, z, width, length);

		for (int i = 0; i < width * length; ++i)
		{

			float f = (float)BiomeGenBase.getBiomeFromBiomeList (aint [i], BiomeGenBase.field_180279_ad).getIntRainfall () / 65536.0F;

			if (f > 1.0F) {
				f = 1.0F;
			}

			listToReuse [i] = f;
			

		}

		return listToReuse;

	}
}
