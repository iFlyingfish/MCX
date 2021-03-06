﻿using UnityEngine;
using System.Collections;

public class ChunkPrimer {
	
	private readonly short[] data = new short[65536];
	private readonly IBlockState defaultState = Blocks.air.getDefaultState();
//	private readonly IBlockState defaultState;

	public IBlockState getBlockState(int x, int y, int z)
	{
		int i = x << 12 | z << 8 | y;
		return getBlockState (i);
	}

	public IBlockState getBlockState(int index)
	{
		if (index >= 0 && index < data.Length) {
			IBlockState iblockstate = (IBlockState)Block.BLOCK_STATE_IDS.getByValue (data [index]);
			return iblockstate != null ? iblockstate : defaultState;
		} else {
			Debug.Log ("The coordinate is out of range");
			return null;
		}
	}

	public void setBlockState(int x, int y, int z, IBlockState state)
	{
		int i = x << 12 | z << 8 | y;
		this.setBlockState(i, state);
	}

	public void setBlockState(int index, IBlockState state)
	{
		if (index >= 0 && index < this.data.Length)
		{
			this.data[index] = (short)Block.BLOCK_STATE_IDS.get(state);
		}
		else
		{
			Debug.Log ("The coordinate is out of range");
			//throw new IndexOutOfBoundsException("The coordinate is out of range");
		}
	}
}
