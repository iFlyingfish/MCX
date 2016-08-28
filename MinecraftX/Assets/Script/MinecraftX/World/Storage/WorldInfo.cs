using UnityEngine;
using System.Collections;

public class WorldInfo : World {
  
	private int _spawnX;
	private int _spawnY;
	private int _spawnZ;

	protected WorldInfo()
	{

	}

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
