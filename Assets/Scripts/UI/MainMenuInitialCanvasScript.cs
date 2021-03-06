﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Author: Nomi Lakkala
 * 
 * <summary>
 * UI script for the initial main menu. Handles the flow of UI.
 * </summary>
 */
public class MainMenuInitialCanvasScript : MonoBehaviour
{

	public AwaitableUIPanel loginPanel;
	public AwaitableUIPanel vrPcSelector;
	public string pcLobbyScene;
	public string vrLobbyScene;

    void Start()
    {
		StartCoroutine(LoginAndSelectMode());
    }

	private IEnumerator LoginAndSelectMode(){

		if(!GlobalValues.loggedIn){
			vrPcSelector.gameObject.SetActive(false);
			loginPanel.gameObject.SetActive(true);

			yield return loginPanel.WaitForFinish();

			vrPcSelector.gameObject.SetActive(true);
			loginPanel.gameObject.SetActive(false);

			yield return vrPcSelector.WaitForFinish();

			vrPcSelector.gameObject.SetActive(false);

			if(!GlobalValues.loggedIn && !GlobalValues.offlineMode){
				StartCoroutine(LoginAndSelectMode());
				Debug.Log("Selection aborted. Back to login.");
				yield break;
			}
		}


		if(GlobalValues.controllerMode == ControllerMode.PC){
			SceneManager.LoadScene(pcLobbyScene);
		}else if(GlobalValues.controllerMode == ControllerMode.VR){
			SceneManager.LoadScene(vrLobbyScene);
		}else{
			Debug.LogError("GlobalValues.GameMode is undefined: " + GlobalValues.controllerMode, this);
		}
	}

}
