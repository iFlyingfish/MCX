using UnityEngine;
using System.Collections;

public class WorldType {

	/** Default world type. */
	public static readonly WorldType DEFAULT = new WorldType (0, "default", 1);

	/** Flat world type. */
	public static readonly WorldType FLAT = new WorldType (1, "flat");

	/** ID for this world type. */
	private readonly int worldTypeID;
	private readonly string worldType;

	/** The int version of the ChunkProvider that generated this world. */
	private readonly int generatorVersion;

	private WorldType(int id, string name) : this(id, name, 0)
	{
		
	}

	private WorldType(int id, string name, int version)
	{
		worldType = name;
		generatorVersion = version;
		worldTypeID = id;
	}
}
