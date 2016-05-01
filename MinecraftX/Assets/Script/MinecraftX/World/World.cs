using UnityEngine;
using System.Collections;

public class World : IBlockAccess {

	/** The WorldProvider instance that World uses. */
	public readonly WorldProvider provider;

	public WorldChunkManager getWorldChunkManager()
	{
		return this.provider.getWorldChunkManager();
	}
}
