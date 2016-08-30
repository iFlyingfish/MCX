using UnityEngine;
using System.Collections;

public class WorldInfo : World {
  
	private int _spawnX;
	private int _spawnY;
	private int _spawnZ;

	protected WorldInfo()
	{

	}

	//temp
	public WorldInfo(int spawnX, int spawnY, int spawnZ)
	{
		_spawnX = spawnX;
		_spawnY = spawnY;
		_spawnZ = spawnZ;
	}
	//

	public int spawnX
	{
		get { return _spawnX; }
	}

	public int spawnY
	{
		get { return _spawnY; }
	}

	public int spawnZ
	{
		get { return _spawnZ; }
	}



}
