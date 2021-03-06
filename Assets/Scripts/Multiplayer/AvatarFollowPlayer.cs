﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Author: Nomi Lakkala
 * 
 * <summary>
 * Handles syncing avatar position with the real player position. Also disables avatar rendering for local avatar.
 * </summary>
 */
[RequireComponent(typeof(PhotonView))]
public class AvatarFollowPlayer : MonoBehaviour
{

	public PlayerPosition player;
	public PhotonView photonView;

	public Transform rightHand;
	public Transform leftHand;
	public Transform head;

	void Start()
	{
		photonView = GetComponent<PhotonView>();
		if (photonView.IsMine)
		{
			player = FindObjectOfType<PlayerPosition>();

			// Disable renderers for local player. Should maybe move to different layer (and player camera wouldn't render that) in the future.
			foreach (var rend in GetComponentsInChildren<Renderer>())
			{
				rend.enabled = false;
			}
		}

	}

	void Update()
	{
		if (player == null || photonView == null || !photonView.IsMine)
		{
			return;
		}
		transform.position = player.GetPosition();
		transform.rotation = player.GetRotation();

		if (player.IsTrackingHands())
		{
			rightHand.position = player.GetRightHandPosition();
			rightHand.rotation = player.GetRightHandRotation();

			leftHand.position = player.GetLeftHandPosition();
			leftHand.rotation = player.GetLeftHandRotation();
		}

		if (player.IsTrackingHead())
		{
			head.transform.position = transform.position + (Vector3.up * player.GetHeadHeightFromBase());
		}
	}

	public bool IsLocal()
	{
		return photonView.IsMine;
	}
}
