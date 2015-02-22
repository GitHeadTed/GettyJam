using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerScript : MonoBehaviour {

    Camera camera;
    private Transform currentlyDraggedObject;
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
                if (hit.transform.GetComponent<Clickable>())
                {
                    hit.transform.GetComponent<Clickable>().OnClicked();
                }
                else if (hit.transform.GetComponent<InventoryItem>() )
                {
                    currentlyDraggedObject = hit.transform;
                    currentlyDraggedObject.collider.enabled = false;

                }
            }
            else
            {
                currentlyDraggedObject = null;
            }
        }
		else if (Input.GetTouch (0).phase == TouchPhase.Moved) {
            if (currentlyDraggedObject)
            {
                Touch touch = Input.GetTouch(0);
                Transform pickedObject = currentlyDraggedObject;
                Vector2 screenDelta = touch.deltaPosition;
                screenDelta *= 3;

                float halfScreenWidth = 0.5f * Screen.width;
                float halfScreenHeight = 0.5f * Screen.height;

                float dx = screenDelta.x / halfScreenWidth;
                float dy = screenDelta.y / halfScreenHeight;

                Vector3 objectToCamera =
                    pickedObject.transform.position - Camera.main.transform.position;
                float distance = objectToCamera.magnitude;

                float fovRad = Camera.main.fieldOfView * Mathf.Deg2Rad;
                float motionScale = distance * Mathf.Tan(fovRad / 2);

                Vector3 translationInCameraRef =
                    new Vector3(motionScale * dx, motionScale * dy, 0);

                Vector3 translationInWorldRef =
                    Camera.main.transform.TransformDirection(translationInCameraRef);

                pickedObject.position += translationInWorldRef;
            }
		}
        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (currentlyDraggedObject)
            {
                currentlyDraggedObject.GetComponent<InventoryItem>().returnToInventory();
                RaycastHit hit = new RaycastHit();
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
                {
                    if (hit.transform.GetComponent<PaintingScript>().ItemName == currentlyDraggedObject.GetComponent<InventoryItem>().name)
                    {
                        hit.transform.GetComponent<PaintingScript>().OnSolved();
                        Destroy(currentlyDraggedObject.gameObject);
                    }
                }
                currentlyDraggedObject = null;
            }
        }
	}

    public void addInventoryItem(InventoryItem item)
    {

    }
}
