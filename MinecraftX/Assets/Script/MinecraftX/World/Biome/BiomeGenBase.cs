using UnityEngine;
using System.Collections;

public class BiomeGenBase {

	/** The id number to this biome, and its index in the biomeList array. */
	public readonly int biomeID;

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
	public static readonly BiomeGenBase deepOcean = new BiomeGenOcean (24);
	public static readonly BiomeGenBase birchForest = new BiomeGenForest (27, 2);
	public static readonly BiomeGenBase roofedForest = new BiomeGenForest (29, 3);
	public static readonly BiomeGenBase coldTaiga = new BiomeGenTaiga (30, 0);
	public static readonly BiomeGenBase megaTaiga = new BiomeGenTaiga (32, 1);
	public static readonly BiomeGenBase savanna = new BiomeGenSavana (35);
	public static readonly BiomeGenBase mesaPlateau_F = new BiomeGenMesa (38, false, true);
	public static readonly BiomeGenBase mesaPlateau = new BiomeGenMesa (39, false, false);

	protected BiomeGenBase(int id)
	{
		biomeID = id;
	}
}
