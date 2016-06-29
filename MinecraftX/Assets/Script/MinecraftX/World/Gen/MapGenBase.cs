using UnityEngine;
using System.Collections;
using System;
	
public class MapGenBase : MonoBehaviour {
	/** The number of Chunks to gen-check in any given direction. */
	protected int range = 8;

	/** The RNG used by the MapGen classes. */
	protected System.Random rand;

	/** This world object. */
	protected World worldObj;

	public void generate(IChunkProvider chunkProviderIn, World worldIn, int x, int z, ChunkPrimer chunkPrimerIn)
	{
		int i = this.range;
		this.worldObj = worldIn;
		this.rand = new System.Random (worldIn.getSeed ());
		int j = this.rand.Next ();
		int k = this.rand.Next ();

		for (int l = x - i; i <= x + i; ++l) 
		{
			for (int i1 = z - i; i1 <= z + i; ++i1) 
			{
				int j1 = l * j;
				int k1 = i1 * k;

				this.rand = new System.Random (j1 ^ k1 ^ worldIn.getSeed ());
				this.recursiveGenerate (worldIn, l, i1, x, z, chunkPrimerIn);
			}
		}
	}

	/**
     * Recursively called by generate()
     */
	protected void recursiveGenerate(World worldIn, int chunkX, int chunkZ, int p_180701_4_, int p_180701_5_, ChunkPrimer chunkPrimerIn)
	{
		
	}
}
