﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
 * Author: Nomi Lakkala
 * 
 * <summary>
 * UI script for colorblind mode selector panel.
 * </summary>
 */
public class ColorblindSelectorPanel : MonoBehaviour
{

	ColorblindModeSimulator simulator;

	void Start()
	{
		simulator = FindObjectOfType<ColorblindModeSimulator>();
	}

	/**
	 * <summary>
	 * Unity UI callback for normal mode button.
	 * </summary>
	 */
	public void OnNormalButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Normal);
	}

	/**
	 * <summary>
	 * Unity UI callback for deuteranomaly mode button.
	 * </summary>
	 */
	public void OnDeuteranomalyButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Deuteranomaly);
	}

	/**
	 * <summary>
	 * Unity UI callback for protanomaly mode button.
	 * </summary>
	 */
	public void OnProtanomalyButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Protanomaly);
	}

	/**
	 * <summary>
	 * Unity UI callback for protanopia mode button.
	 * </summary>
	 */
	public void OnProtanopiaButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Protanopia);
	}

	/**
	 * <summary>
	 * Unity UI callback for deuteranopia mode button.
	 * </summary>
	 */
	public void OnDeuteranopiaButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Deuteranopia);
	}

	/**
	 * <summary>
	 * Unity UI callback for tritanopia mode button.
	 * </summary>
	 */
	public void OnTritanopiaButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Tritanopia);
	}

	/**
	 * <summary>
	 * Unity UI callback for tritanomaly mode button.
	 * </summary>
	 */
	public void OnTritanomalyButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Tritanomaly);
	}

	/**
	 * <summary>
	 * Unity UI callback for monochromacy mode button.
	 * </summary>
	 */
	public void OnMonochromacyButtonClick()
	{
		if (simulator == null)
		{
			simulator = FindObjectOfType<ColorblindModeSimulator>();
		}
		simulator.SetColorblindMode(ColorblindMode.Monochromacy);
	}
}
