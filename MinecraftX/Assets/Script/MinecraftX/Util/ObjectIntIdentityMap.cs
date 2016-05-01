using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectIntIdentityMap <T> {

	private readonly Dictionary<T, int> identityMap = new Dictionary<T, int> ();

	public int get(T key)
	{
		int interger = (int)this.identityMap [key];
		return interger == null ? -1 : interger;
	}
}
