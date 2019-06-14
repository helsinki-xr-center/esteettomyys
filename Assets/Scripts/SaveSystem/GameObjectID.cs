﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EasyHumanIds;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif


namespace SaveSystem
{

	/**
	 * Author: Nomi Lakkala
	 * 
	 * <summary>
	 * A unique ID for a GameObject. Primarily used with the SaveSystem classes but can be attached to any GameObject to make it referencable in saves.
	 * Only works for GameObjects in a scene.
	 * </summary>
	 */
	[ExecuteInEditMode]
	[AddComponentMenu("Saving/GameObjectID")]
	public class GameObjectID : MonoBehaviour
	{
		private static readonly System.Random r = new System.Random();
		private static readonly Dictionary<string, GameObjectID> allIds = new Dictionary<string, GameObjectID>();
		public string id;

		private void Awake()
		{
			if (!string.IsNullOrEmpty(id))
			{
				if (!allIds.ContainsKey(id))
				{
					allIds.Add(id, this);
				}
			}
		}

#if UNITY_EDITOR
		
		void Update()
		{
			if (Application.isPlaying)
				return;

			CheckID();
		}

		void OnDestroy()
		{
			if (!String.IsNullOrEmpty(id))
			{
				allIds.Remove(id);
			}
		}

		/**
		 * <summary>
		 * Checks the ID of this GameObject and changes it if necessary.
		 * </summary>
		 */
		private void CheckID()
		{
			if (gameObject.scene == null)
			{
				id = String.Empty;
				return;
			}
			if (String.IsNullOrEmpty(id))
			{
				id = GenerateNewId();
				if(allIds.ContainsKey(id))
				{
					id = null;
					return;
				}
				else
				{
					allIds[id] = this;
				}
			}
			if(allIds.ContainsKey(id) && allIds[id] != this)
			{
				id = null;
				return;
			}
			if(!allIds.ContainsKey(id))
			{
				allIds[id] = this;
			}	
		}

		/**
		 * <summary>
		 * Generates a new unique ID.
		 * </summary>
		 */
		private string GenerateNewId()
		{
			return gameObject.scene.name + "-" + HumanIds.Generate(r);
			//return gameObject.scene.name + "_" + Guid.NewGuid(); //more traditional guids. or if EasyHumanIds ever breaks
		}
#endif

		/**
		 * <summary>
		 * Finds a GameObject that has the provided id. If not found, returns null.
		 * </summary>
		 */
		public static GameObject GetObjectByID(string id)
		{
			if(!allIds.ContainsKey(id))
			{
				Debug.Log($"No GameObject with key {id} found!");
				return null;
			}

			return allIds[id].gameObject;
		}

		
	}
}