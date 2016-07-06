﻿using UnityEngine;
using System.Collections;

public class IntegratedServer : MinecraftServer {

	public WorldServer[] worldServers;

	/**
     * Initialises the server and starts it.
     */
	protected bool startServer()
	{
		loadAllWorlds ();
		return true;
	}

	protected void loadAllWorlds()
	{
		worldServers = new WorldServer[1];
		worldServers [0] = new WorldServer ();
		initialWorldChunkLoad ();
	}

	public void updateTimeLightAndEntities()
	{

	}

	/**
     * Main function called by run() every loop.
     */
	public void tick()
	{
		base.tick ();
		foreach (WorldServer worldserver in worldServers)
		{
			if (worldserver != null) {
				
			}
		}
	}
}