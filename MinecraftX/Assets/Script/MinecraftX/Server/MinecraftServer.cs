using UnityEngine;
using System.Collections;
using System;

public class MinecraftConfig {

	public static readonly long tickDelta = 50L;
	public static readonly int loadSize= 192 * 2;
	public static readonly int chunkSize = 16;
	public static readonly int chunkBitSize = 4;

}

public abstract class MinecraftServer {

	private readonly System.Random random = new System.Random ();
    long currentTime = getCurrentTimeMillis();
	/** The server world instances. */
	public WorldServer[] worldServers;
	/**
     * Indicates whether the server is running or not. Set to false to initiate a shutdown.
     */
	private bool serverRunning = true;

	virtual protected void loadAllWorlds()
	{
		worldServers = new WorldServer[1];
		worldServers [0] = new WorldServer ();
		initialWorldChunkLoad ();
	}

	protected void initialWorldChunkLoad()
	{
		int i = 16;
		int j = 4;
		int k = 192;
		int l = 625;
		int i1 = 0;
		//Debug.Log ("menu.generatingTerrain");
		int j1 = 0;
		//Debug.Log ("Preparing start region for level {0}, j1");

		WorldServer worldserver = worldServers[j1];
		BlockPos blockPos = worldserver.getSpawnPoint ();
		long k1 = getCurrentTimeMillis ();

		for (int x = -MinecraftConfig.loadSize / 2; x < MinecraftConfig.loadSize / 2; x += MinecraftConfig.chunkSize) {
			for (int z = -MinecraftConfig.loadSize / 2; z < MinecraftConfig.loadSize / 2; z += MinecraftConfig.chunkSize) {
				long j2 = getCurrentTimeMillis ();

				if (j2 - k1 > 1000L) {
					Debug.Log ("Preparing spawn area {0}, i1 * 100 / ((loadSize / chunkSize) * (loadSize / chunkSize))");
					k1 = j2;
				}

				++i1;
				worldserver.theChunkProviderServer.loadChunk (blockPos.x + x >> MinecraftConfig.chunkBitSize, blockPos.z + z >> MinecraftConfig.chunkBitSize);

			}
		}
	}

	public void run()
	{
		if (startServer ()) 
		{
			currentTime = getCurrentTimeMillis ();
			long totalTime = 0L;

			while (serverRunning) {
				long realCurTime = getCurrentTimeMillis ();
				long duration = realCurTime - currentTime;
				if (duration < 0L) {
					duration = 0L;
				}

				totalTime += duration;
				currentTime = realCurTime;

				while (totalTime > MinecraftConfig.tickDelta) {
					totalTime -= MinecraftConfig.tickDelta;
					tick ();
				}

					
			}
		} 
		else 
		{

		}
	}

	/**
     * Main function called by run() every loop.
     */
	virtual public void tick()
	{

	}

	public void updateTimeLightAndEntities()
	{
		for (int i = 0; i < worldServers.Length; ++i) 
		{
			WorldServer worldServer = worldServers [i];
			worldServer.tick ();
		}
	}

	public static long getCurrentTimeMillis()
	{
		return (long)(DateTime.UtcNow - new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
	}

	/**
     * Initialises the server and starts it.
     */
	protected abstract bool startServer ();

}
