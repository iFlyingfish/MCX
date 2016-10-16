﻿using UnityEngine;
using System.Collections;

public class GenLayerBiome : GenLayer{

	private BiomeGenBase[] field_151623_c = new BiomeGenBase[] {BiomeGenBase.desert, BiomeGenBase.desert, BiomeGenBase.desert, BiomeGenBase.savanna, BiomeGenBase.plains};

	private BiomeGenBase[] field_151621_d = new BiomeGenBase[] {
		BiomeGenBase.forest,
		BiomeGenBase.roofedForest,
		BiomeGenBase.extremeHills,
		BiomeGenBase.plains ,
		BiomeGenBase.birchForest,
		BiomeGenBase.swampland
	};

	private BiomeGenBase[] field_151622_e = new BiomeGenBase[] {BiomeGenBase.forest, BiomeGenBase.extremeHills, BiomeGenBase.tagia, BiomeGenBase.plains};

	private BiomeGenBase[] field_151620_f = new BiomeGenBase[] {BiomeGenBase.icePlains, BiomeGenBase.icePlains, BiomeGenBase.icePlains, BiomeGenBase.coldTaiga};

	private readonly ChunkProviderSettings field_175973_g;

	public GenLayerBiome(long seed, GenLayer parentGenLayer, WorldType worldType, string biomeAttriStr) : base(seed)
	{
		parent = parentGenLayer;
		field_175973_g = null;
	}

	/**
     * Returns a list of integer values generated by this layer. These may be interpreted as temperatures, rainfall
     * amounts, or biomeList[] indices based on the particular GenLayer subclass.
     */
	public override int[] getInts(int areaX, int areaY, int areaWidth, int areaHeight)
	{
		int[] aint = parent.getInts(areaX, areaY, areaWidth, areaHeight);
		int[] aint1 = IntCache.getIntCache(areaWidth * areaHeight);

		for (int i = 0; i < areaHeight; ++i)
		{
			for (int j = 0; j < areaWidth; ++j)
			{
				this.initChunkSeed((long)(j + areaX), (long)(i + areaY));
				int k = aint[j + i * areaWidth];
				int l = (k & 3840) >> 8;
				k = k & -3841;

				if (this.field_175973_g != null && this.field_175973_g.fixedBiome >= 0)
				{
					aint1[j + i * areaWidth] = this.field_175973_g.fixedBiome;
				}
				else if (isBiomeOceanic(k))
				{
					aint1[j + i * areaWidth] = k;
				}
				else if (k == BiomeGenBase.mushroomIsland.biomeID)
				{
					aint1[j + i * areaWidth] = k;
				}
				else if (k == 1)
				{
					if (l > 0)
					{
						if (this.nextInt(3) == 0)
						{
							aint1[j + i * areaWidth] = BiomeGenBase.mesaPlateau.biomeID;
						}
						else
						{
							aint1[j + i * areaWidth] = BiomeGenBase.mesaPlateau_F.biomeID;
						}
					}
					else
					{
						aint1[j + i * areaWidth] = field_151623_c[nextInt(field_151623_c.Length)].biomeID;
					}
				}
				else if (k == 2)
				{
					if (l > 0)
					{
						aint1[j + i * areaWidth] = BiomeGenBase.jungle.biomeID;
					}
					else
					{
						aint1[j + i * areaWidth] = this.field_151621_d[this.nextInt(this.field_151621_d.Length)].biomeID;
					}
				}
				else if (k == 3)
				{
					if (l > 0)
					{
						aint1[j + i * areaWidth] = BiomeGenBase.megaTaiga.biomeID;
					}
					else
					{
						aint1[j + i * areaWidth] = this.field_151622_e[nextInt(this.field_151622_e.Length)].biomeID;
					}
				}
				else if (k == 4)
				{
					aint1[j + i * areaWidth] = this.field_151620_f[nextInt(this.field_151620_f.Length)].biomeID;
				}
				else
				{
					aint1[j + i * areaWidth] = BiomeGenBase.mushroomIsland.biomeID;
				}
			}
		}

		return aint1;
	}

} 