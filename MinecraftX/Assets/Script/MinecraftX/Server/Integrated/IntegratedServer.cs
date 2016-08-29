using UnityEngine;
using System.Collections;

public class IntegratedServer : MinecraftServer {

	private static IntegratedServer instance; 

	public static IntegratedServer getInstance()
	{
		if (instance == null) {
			instance = new IntegratedServer ();
		}

		return instance;

	}

	/**
     * Initialises the server and starts it.
     */
    override protected bool startServer()
	{
		loadAllWorlds ();
		return true;
	}

	override protected void loadAllWorlds()
	{
		worldServers = new WorldServer[1];
		worldServers [0] = new WorldServer ();
		WorldServer worldServer = worldServers [0];
		initialWorldChunkLoad ();
	}

	public void updateTimeLightAndEntities()
	{

	}

	public void run()
	{
		startServer ();
	}

	/**
     * Main function called by run() every loop.
     */
	override public void tick()
	{
		base.tick ();
		foreach (WorldServer worldserver in worldServers)
		{
			if (worldserver != null) {
				
			}
		}
	}
}
