using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntCache : MonoBehaviour {

	const int CACHE_SIZE = 256;

	private static int intCacheSize = CACHE_SIZE;
	private static List<int[]> freeSmallArrays = new List<int[]>();
	private static List<int[]> inUseSmallArrays = new List<int[]> ();
	private static List<int[]> freeLargeArrays = new List<int[]> ();
	private static List<int[]> inUseLargeArrays = new List<int[]> ();

	public static int[] getIntCache(int area)  //need to be synchronized method
	{
		if (area <= CACHE_SIZE) {
			if (freeSmallArrays.Count == 0) {
				int[] aint4 = new int[CACHE_SIZE];
				inUseSmallArrays.Add (aint4);
				return aint4;
			} else {
				int[] aint3 = (int[])freeSmallArrays [freeSmallArrays.Count - 1];
				freeSmallArrays.RemoveAt (freeSmallArrays.Count - 1);
				inUseSmallArrays.Add (aint3);
				return aint3;
			}
		} else if (area > intCacheSize) {
			intCacheSize = CACHE_SIZE;
			freeLargeArrays.Clear ();
			inUseLargeArrays.Clear ();
			int[] aint2 = new int[intCacheSize];
			inUseLargeArrays.Add (aint2);
			return aint2;
		} else if (freeLargeArrays.Count == 0) {
			int[] aint1 = new int[intCacheSize];
			inUseLargeArrays.Add (aint1);
			return aint1;
		} else {
			int[] aint = (int[])freeLargeArrays [freeLargeArrays.Count - 1];
			freeLargeArrays.RemoveAt (freeLargeArrays.Count - 1);
			inUseLargeArrays.Add (aint);
			return aint;
		}
	}
}
