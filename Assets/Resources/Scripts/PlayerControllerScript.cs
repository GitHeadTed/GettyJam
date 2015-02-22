﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerScript : MonoBehaviour {

    Camera camera;
    
	public List<InventoryItem> playerInventory;
	// Use this for initialization
	void Start () {
        camera = Camera.main;
		bool focusModeSet;
		focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		
		if (!focusModeSet) {
			Debug.Log("Failed to set focus mode (unsupported mode).");
		}
        playerInventory = new List<InventoryItem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray mouseRay = camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(mouseRay, out hit))
            {
                if (hit.transform.tag == "Clickable")
                {
                    hit.transform.GetComponent<Clickable>().OnClicked();
                }
                else if (hit.transform.tag == "Draggable")
                {
                    
                }
            }
        }
		if (Input.GetTouch (0).phase == TouchPhase.Moved) {

		}
	}
}
