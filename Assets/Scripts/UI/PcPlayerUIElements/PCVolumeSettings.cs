﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCVolumeSettings : MonoBehaviour
{

	[SerializeField] Slider[] sliders;

    void Start()
    {
		sliders = new Slider[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			sliders[i] = transform.GetChild(i).gameObject.GetComponentInChildren<Slider>();
		}
		
    }



}
