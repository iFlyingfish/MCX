using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenVillage : MapGenStructure {

	/** World terrain type, 0 for normal, 1 for flat map */
	private int terrainType;
	private int field_82665_g;
	private int field_82666_h;


	public MapGenVillage()
	{
		this.field_82665_g = 32;
		this.field_82666_h = 8;
	}


	public MapGenVillage(Dictionary<string, string> p_i2093_1_)
	{
//		this();
//
//		for (Entry<String, String> entry : p_i2093_1_.entrySet())
//		{
//			if (((String)entry.getKey()).equals("size"))
//			{
//				this.terrainType = MathHelper.parseIntWithDefaultAndMax((String)entry.getValue(), this.terrainType, 0);
//			}
//			else if (((String)entry.getKey()).equals("distance"))
//			{
//				this.field_82665_g = MathHelper.parseIntWithDefaultAndMax((String)entry.getValue(), this.field_82665_g, this.field_82666_h + 1);
//			}
//		}
	}
}
