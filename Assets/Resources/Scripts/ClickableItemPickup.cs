using UnityEngine;
using System.Collections;

public class ClickableItemPickup : Clickable {
	
	// Use this for initialization

    public GameObject itemPrefab;

	// Update is called once per frame
	void Update () {
		
	}
	
	public override void OnClicked()
	{
		if (this.inPainting) {
			inPainting = false;
			Instantiate (itemPrefab, transform.position, Quaternion.identity);
		}
	}
}


