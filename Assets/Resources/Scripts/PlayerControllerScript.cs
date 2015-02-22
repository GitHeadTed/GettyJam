using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

    Camera camera;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
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
                    Item item = hit.transform.GetComponent<Item>();
                    if (item)
                    {
                        item.OnClicked();
                    }
                }
            }
        }
	}
}
