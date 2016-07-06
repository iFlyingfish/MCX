using UnityEngine;
using System.Collections;

public class BlockPos {

	private int _x;
	private int _y;
	private int _z;

	public int x
	{
		get {return x;}
		set {_x = value;}
	}

	public int y
	{
		get {return y;}
		set {_y = value;}
	}

	public int z
	{
		get {return z;}
		set {_z = value;}
	}

	public BlockPos(int x, int y, int z)
	{
		this._x = x;
		this._y = y;
		this._z = z;
	}
}
