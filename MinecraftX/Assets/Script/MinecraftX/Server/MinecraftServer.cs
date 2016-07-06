using UnityEngine;
using System.Collections;
using System;

public class MinecraftServer {
	
	private const long tickDelta = 50L;
	private const int loadSize = 192 * 2;
	private const int chunkSize = 16;
	private const int chunkBitSize = 4;

	private readonly System.Random random = new System.Random ();
	private long currentTime = getCurrentTimeMillis();
	/** The server world instances. */
	public WorldServer[] worldServers;
	/**
     * Indicates whether the server is running or not. Set to false to initiate a shutdown.
     */
	private bool serverRunning = true;

	protected void loadAllWorlds()
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
		Debug.Log ("menu.generatingTerrain");
		int j1 = 0;
		Debug.Log ("Preparing start region for level {0}", j1);
		WorldServer worldserver = this.worldServers [j1];
		BlockPos blockPos = worldserver.getSpawnPoint ();
		long k1 = getCurrentTimeMillis ();

		for (int x = -loadSize / 2; x < loadSize / 2; x += chunkSize) {
			for (int z = -loadSize / 2; z < loadSize / 2; z += chunkSize) {
				long j2 = getCurrentTimeMillis ();

				if (j2 - k1 > 1000L) {
					Debug.Log ("Preparing spawn area", i1 * 100 / ((loadSize / chunkSize) * (loadSize / chunkSize)));
					k1 = j2;
				}

				++i1;
				worldserver.theChunkProviderServer.loadChunk (blockPos.x + x >> chunkBitSize, blockPos.z + z >> chunkBitSize);

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

				while (totalTime > tickDelta) {
					totalTime -= tickDelta;
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
	public void tick()
	{

	}

	public void updateTimeLightAndEntities()
	{
		for (int i = 0; i < worldServers.Length; ++i) 
		{
			WorldServer worldServer = WorldServer [i];
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
