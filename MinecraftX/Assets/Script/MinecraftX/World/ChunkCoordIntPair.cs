using UnityEngine;
using System.Collections;

public class ChunkCoordIntPair {

	/**
     * converts a chunk coordinate pair to an integer (suitable for hashing)
     */
	public static long chunkXZ2Int(int x, int z)
	{
		return (long)x & 4294967295L | ((long)z & 4294967295L) << 32;
	}

}
