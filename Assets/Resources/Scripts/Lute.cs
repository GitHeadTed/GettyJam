using UnityEngine;
using System.Collections;

public class Lute : Item {
	
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
	}
	
	public override void OnClicked()
	{
		if (this.inPainting) {
			inPainting = false;
			if (inventoryPos == 0) {
				Instantiate (Resources.Load ("Prefabs/TestCube"), transform.position, Quaternion.identity);
			}
		}
	}
}


