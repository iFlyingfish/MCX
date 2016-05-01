using UnityEngine;
using System.Collections;

public class WorldChunkManager {

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
//			BiomeGenBase[] abiomegenbase = this.biomeCache.getCachedBiomes(x, z);
//			System.arraycopy(abiomegenbase, 0, listToReuse, 0, width * length);
			return listToReuse;
		}
		else
		{
//			int[] aint = this.biomeIndexLayer.getInts(x, z, width, length);
//
//			for (int i = 0; i < width * length; ++i)
//			{
//				listToReuse[i] = BiomeGenBase.getBiomeFromBiomeList(aint[i], BiomeGenBase.field_180279_ad);
//			}

			return listToReuse;
		}
	}
}
