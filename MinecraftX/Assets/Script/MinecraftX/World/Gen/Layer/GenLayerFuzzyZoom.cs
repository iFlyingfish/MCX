using UnityEngine;
using System.Collections;

public class GenLayerFuzzyZoom : GenLayerZoom {

	public GenLayerFuzzyZoom(long seed, GenLayer parentGenLayer) : base(seed, parentGenLayer)
	{

	}

	/**
     * returns the most frequently occurring number of the set, or a random number from those provided
     */
	protected int selectModeOrRandom(int p_151617_1_, int p_151617_2_, int p_151617_3_, int p_151617_4_)
	{
		return selectRandom (new int[]{ p_151617_1_, p_151617_2_, p_151617_3_, p_151617_4_ });
	}
}
