using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IBlockState
{

}

public class FlatGeneratorInfo
{
	public Dictionary<string, Dictionary<string, string>> getWorldFeatures ()
	{
		return null;
	}
}



public class WorldGenLakes
{

}

public class ChunkProviderFlat : IChunkProvider {

	private World worldObj;
	private System.Random random;
	private readonly IBlockState[] cachedBlockIDs = new IBlockState[256];
	private readonly FlatGeneratorInfo flatWorldGenInfo;
	private readonly List<MapGenStructure> structureGenerators =  new List<MapGenStructure> ();
	private readonly bool hasDecoration;
	private readonly bool hasDungeons;
	private WorldGenLakes waterLakeGenerator;
	private WorldGenLakes lavaLakeGenerator;

	public ChunkProviderFlat(World worldIn, int seed, bool generateStructures, string flatGeneratorSettings)
	{
		this.worldObj = worldIn;
		this.random = new System.Random(seed);
//		this.flatWorldGenInfo = FlatGeneratorInfo.createFlatGeneratorFromString(flatGeneratorSettings);

		if (generateStructures)
		{
			
			Dictionary<string, Dictionary<string, string>> map = this.flatWorldGenInfo.getWorldFeatures();

			if (map.ContainsKey("village"))
			{
				Dictionary<string, string> map1 = map["village"];

				if (!map1.ContainsKey("size"))
				{
					map1["size"] = "1";
				}

//				if (map.containsKey("biome_1"))
//				{
//					this.structureGenerators.add(new MapGenScatteredFeature((Map)map.get("biome_1")));
//				}
//
//				if (map.containsKey("mineshaft"))
//				{
//					this.structureGenerators.add(new MapGenMineshaft((Map)map.get("mineshaft")));
//				}
//
//				if (map.containsKey("stronghold"))
//				{
//					this.structureGenerators.add(new MapGenStronghold((Map)map.get("stronghold")));
//				}
//
//				if (map.containsKey("oceanmonument"))
//				{
//					this.structureGenerators.add(new StructureOceanMonument((Map)map.get("oceanmonument")));
//				}

				this.structureGenerators.Add(new MapGenVillage(map1));
			}
				
		}

//		if (this.flatWorldGenInfo.getWorldFeatures().containsKey("lake"))
//		{
//			this.waterLakeGenerator = new WorldGenLakes(Blocks.water);
//		}
//
//		if (this.flatWorldGenInfo.getWorldFeatures().containsKey("lava_lake"))
//		{
//			this.lavaLakeGenerator = new WorldGenLakes(Blocks.lava);
//		}
			

//		this.hasDungeons = this.flatWorldGenInfo.getWorldFeatures().containsKey("dungeon");
//		int j = 0;
//		int k = 0;
//		boolean flag = true;
//
//		for (FlatLayerInfo flatlayerinfo : this.flatWorldGenInfo.getFlatLayers())
//		{
//			for (int i = flatlayerinfo.getMinY(); i < flatlayerinfo.getMinY() + flatlayerinfo.getLayerCount(); ++i)
//			{
//				IBlockState iblockstate = flatlayerinfo.func_175900_c();
//
//				if (iblockstate.getBlock() != Blocks.air)
//				{
//					flag = false;
//					this.cachedBlockIDs[i] = iblockstate;
//				}
//			}
//
//			if (flatlayerinfo.func_175900_c().getBlock() == Blocks.air)
//			{
//				k += flatlayerinfo.getLayerCount();
//			}
//			else
//			{
//				j += flatlayerinfo.getLayerCount() + k;
//				k = 0;
//			}
//		}

//		worldIn.func_181544_b(j);
//		this.hasDecoration = flag ? false : this.flatWorldGenInfo.getWorldFeatures().containsKey("decoration");
	}

	/**
     * Will return back a chunk, if it doesn't exist and its not a MP client it will generates all the blocks for the
     * specified chunk from the map seed and chunk seed
     */
	public Chunk provideChunk(int x, int z)
	{
		ChunkPrimer chunkprimer = new ChunkPrimer();

		for (int i = 0; i < this.cachedBlockIDs.Length; ++i)
		{
			IBlockState iblockstate = this.cachedBlockIDs[i];

			if (iblockstate != null)
			{
				for (int j = 0; j < 16; ++j)
				{
					for (int k = 0; k < 16; ++k)
					{
						chunkprimer.setBlockState(j, i, k, iblockstate);
					}
				}
			}
		}

		for (int i = 0; i < this.structureGenerators.Count; ++i)
		{
			MapGenBase mapGenBase = this.structureGenerators [i];
			mapGenBase.generate (this, this.worldObj , x, z, chunkprimer);
		}
			

		Chunk chunk = new Chunk (this.worldObj, chunkprimer, x, z);

		BiomeGenBase[] abiomegenbase = this.worldObj.getWorldChunkManager().loadBlockGeneratorData((BiomeGenBase[])null, x * 16, z * 16, 16, 16);
//		byte[] abyte = chunk.getBiomeArray();
//
//		for (int l = 0; l < abyte.length; ++l)
//		{
//			abyte[l] = (byte)abiomegenbase[l].biomeID;
//		}
//
//		chunk.generateSkylightMap();
		return chunk;
	}

	/**
     * Checks to see if a chunk exists at x, z
     */
	public bool chunkExists(int x, int z)
	{
		return true;
	}

//	/**
//     * Populates chunk with ores etc etc
//     */
//	public void populate(IChunkProvider p_73153_1_, int p_73153_2_, int p_73153_3_)
//	{
//		int i = p_73153_2_ * 16;
//		int j = p_73153_3_ * 16;
//		BlockPos blockpos = new BlockPos(i, 0, j);
//		BiomeGenBase biomegenbase = this.worldObj.getBiomeGenForCoords(new BlockPos(i + 16, 0, j + 16));
//		boolean flag = false;
//		this.random.setSeed(this.worldObj.getSeed());
//		long k = this.random.nextLong() / 2L * 2L + 1L;
//		long l = this.random.nextLong() / 2L * 2L + 1L;
//		this.random.setSeed((long)p_73153_2_ * k + (long)p_73153_3_ * l ^ this.worldObj.getSeed());
//		ChunkCoordIntPair chunkcoordintpair = new ChunkCoordIntPair(p_73153_2_, p_73153_3_);
//
//		for (MapGenStructure mapgenstructure : this.structureGenerators)
//		{
//			boolean flag1 = mapgenstructure.generateStructure(this.worldObj, this.random, chunkcoordintpair);
//
//			if (mapgenstructure instanceof MapGenVillage)
//			{
//				flag |= flag1;
//			}
//		}
//
//		if (this.waterLakeGenerator != null && !flag && this.random.nextInt(4) == 0)
//		{
//			this.waterLakeGenerator.generate(this.worldObj, this.random, blockpos.add(this.random.nextInt(16) + 8, this.random.nextInt(256), this.random.nextInt(16) + 8));
//		}
//
//		if (this.lavaLakeGenerator != null && !flag && this.random.nextInt(8) == 0)
//		{
//			BlockPos blockpos1 = blockpos.add(this.random.nextInt(16) + 8, this.random.nextInt(this.random.nextInt(248) + 8), this.random.nextInt(16) + 8);
//
//			if (blockpos1.getY() < this.worldObj.func_181545_F() || this.random.nextInt(10) == 0)
//			{
//				this.lavaLakeGenerator.generate(this.worldObj, this.random, blockpos1);
//			}
//		}
//
//		if (this.hasDungeons)
//		{
//			for (int i1 = 0; i1 < 8; ++i1)
//			{
//				(new WorldGenDungeons()).generate(this.worldObj, this.random, blockpos.add(this.random.nextInt(16) + 8, this.random.nextInt(256), this.random.nextInt(16) + 8));
//			}
//		}
//
//		if (this.hasDecoration)
//		{
//			biomegenbase.decorate(this.worldObj, this.random, blockpos);
//		}
//	}
    
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
//
//	/**
//     * Save extra data not associated with any Chunk.  Not saved during autosave, only during world unload.  Currently
//     * unimplemented.
//     */
//	public void saveExtraData()
//	{
//	}
//
	/**
     * Unloads chunks that are marked to be unloaded. This is not guaranteed to unload every such chunk.
     */
	public bool unloadQueuedChunks()
	{
		return false;
	}

	/**
     * Returns if the IChunkProvider supports saving.
     */
	public bool canSave()
	{
		return true;
	}

	/**
     * Converts the instance data to a readable string.
     */
	public string makeString()
	{
		return "FlatLevelSource";
	}
//
//	public List<BiomeGenBase.SpawnListEntry> getPossibleCreatures(EnumCreatureType creatureType, BlockPos pos)
//	{
//		BiomeGenBase biomegenbase = this.worldObj.getBiomeGenForCoords(pos);
//		return biomegenbase.getSpawnableList(creatureType);
//	}
//
//	public BlockPos getStrongholdGen(World worldIn, String structureName, BlockPos position)
//	{
//		if ("Stronghold".equals(structureName))
//		{
//			for (MapGenStructure mapgenstructure : this.structureGenerators)
//			{
//				if (mapgenstructure instanceof MapGenStronghold)
//				{
//					return mapgenstructure.getClosestStrongholdPos(worldIn, position);
//				}
//			}
//		}
//
//		return null;
//	}
//
//	public int getLoadedChunkCount()
//	{
//		return 0;
//	}
//
	public void recreateStructures(Chunk p_180514_1_, int p_180514_2_, int p_180514_3_)
	{
		foreach (MapGenStructure mapgenstructure in structureGenerators)
		{
			mapgenstructure.generate(this, worldObj, p_180514_2_, p_180514_3_, (ChunkPrimer)null);
		}
	}

	public Chunk provideChunk(BlockPos blockPosIn)
	{
		return provideChunk(blockPosIn.x >> 4, blockPosIn.z >> 4);
	}

}
