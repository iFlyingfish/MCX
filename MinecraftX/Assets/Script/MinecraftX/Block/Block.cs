using UnityEngine;
using System.Collections;

public class Block {

	private IBlockState defaultBlockState;

	public static readonly ObjectIntIdentityMap<IBlockState> BLOCK_STATE_IDS = new ObjectIntIdentityMap<IBlockState> ();

	public IBlockState getDefaultState()
	{
		return defaultBlockState;
	}
}
