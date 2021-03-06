﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author : Veli-Matti Vuoti
/// 
/// Adds BoxColliders for gameobjects childs
/// </summary>
public class BoxColliderChildSetter : MonoBehaviour
{

	public bool manualEditing;

	private void OnValidate()
	{
		if (!manualEditing)
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				if (transform.GetChild(i).GetComponent<BoxCollider>() == null)
				{
					transform.GetChild(i).gameObject.AddComponent<BoxCollider>();
				}
			}
		}
	}
}
