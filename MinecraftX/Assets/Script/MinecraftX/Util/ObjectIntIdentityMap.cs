using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectIntIdentityMap <T> {

	private readonly Dictionary<T, int> identityMap = new Dictionary<T, int> ();
	private readonly List<T> objectList = new List<T> ();

	public int get(T key)
	{
		int interger = (int)this.identityMap [key];
		return interger == null ? -1 : interger;
	}

	public T getByValue(int value)
	{
		return value >= 0 && value < objectList.Count ? (T)objectList [value] : default(T);
	}
}
