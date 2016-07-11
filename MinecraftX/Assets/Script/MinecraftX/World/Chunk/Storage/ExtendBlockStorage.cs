using UnityEngine;
using System.Collections;

public class ExtendBlockStorage {


	private char[] data;

	public IBlockState get(int x, int y, int z)
	{
		IBlockState iblockstate = (IBlockState)Block.BLOCK_STATE_IDS.getByValue (data [y << (MinecraftConfig.chunkBitSize * 2) | z << MinecraftConfig.chunkBitSize | x]);
		return iblockstate != null ? iblockstate : Blocks.air.getDefaultState ();
	}

}
