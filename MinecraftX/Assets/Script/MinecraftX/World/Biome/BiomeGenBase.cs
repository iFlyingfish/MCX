﻿using UnityEngine;
using System.Collections;

public class BiomeGenBase {

        public enum TempCategory
	{
           OCEAN,
	   COLD,
	   MEDIUM,
	   WARM
	}

	/** The id number to this biome, and its index in the biomeList array. */
	public readonly int biomeID;

	/** An array of all the biomes, indexed by biome id. */
	private static readonly BiomeGenBase[] biomeList = new BiomeGenBase[256];
	public static readonly BiomeGenBase ocean = new BiomeGenOcean (0);
	public static readonly BiomeGenBase plains = new BiomeGenPlains (1);
	public static readonly BiomeGenBase desert = new BiomeGenDesert (2);
	public static readonly BiomeGenBase extremeHills = new BiomeGenHills (3, false);
	public static readonly BiomeGenBase forest = new BiomeGenForest (4, 0);
	public static readonly BiomeGenBase tagia = new BiomeGenTaiga (5, 0);
	public static readonly BiomeGenBase swampland = new BiomeGenSwamp (6);

	/** Is the biome used for sky world. */
	public static readonly BiomeGenBase icePlains = new BiomeGenSnow (12, false);
	public static readonly BiomeGenBase mushroomIsland = new BiomeGenMushroomIsland (14);

	/** Jungle biome identifier */
	public static readonly BiomeGenBase jungle = new BiomeGenJungle (21, false);
	public static readonly BiomeGenBase jungleEdge = new BiomeGenJungle (23, true);
	public static readonly BiomeGenBase deepOcean = new BiomeGenOcean (24);
	public static readonly BiomeGenBase birchForest = new BiomeGenForest (27, 2);
	public static readonly BiomeGenBase roofedForest = new BiomeGenForest (29, 3);
	public static readonly BiomeGenBase coldTaiga = new BiomeGenTaiga (30, 0);
	public static readonly BiomeGenBase megaTaiga = new BiomeGenTaiga (32, 1);
	public static readonly BiomeGenBase extremeHillsPlus = new BiomeGenHills (34, true);
	public static readonly BiomeGenBase savanna = new BiomeGenSavana (35);
	public static readonly BiomeGenBase mesaPlateau_F = new BiomeGenMesa (38, false, true);
	public static readonly BiomeGenBase mesaPlateau = new BiomeGenMesa (39, false, false);

	/** The temperature of this biome. */
	public float temperature;

	protected BiomeGenBase(int id)
	{
		biomeID = id;
		biomeList[id] = this;
	}
		
	/**
     * returns true if the biome specified is equal to this biome
     */
	public bool isEqualTo(BiomeGenBase biome)
	{
		return biome == this ? true : (biome == null ? false : GetType () == biome.GetType ());
	}

	public BiomeGenBase.TempCategory getTempCategory()
	{
		return (double)temperature < 0.2D ? BiomeGenBase.TempCategory.COLD : ((double)temperature < 1.0D ? BiomeGenBase.TempCategory.MEDIUM : BiomeGenBase.TempCategory.WARM);
	}

	/**
     * return the biome specified by biomeID, or 0 (ocean) if out of bounds
     */
	public static BiomeGenBase getBiome(int id)
	{
		return getBiomeFromBiomeList (id, (BiomeGenBase)null);
	}

	public static BiomeGenBase getBiomeFromBiomeList(int biomeId, BiomeGenBase biome)
	{
		if (biomeId >= 0 && biomeId <= biomeList.Length) {
			BiomeGenBase biomegenbase = biomeList [biomeId];
			return biomegenbase == null ? biome : biomegenbase;
		} else {
			Debug.LogFormat ("Biome ID is out of bounds: " + biomeId + ", defaulting to 0 (Ocean)");
			return ocean;
		}

	}
		
}
