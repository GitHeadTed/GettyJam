using UnityEngine;
using System.Collections;

public class PaintingScript : MonoBehaviour {

	public string ItemName;
	void OnTriggerEnter(Collider other){
		if (other.GetComponent<InventoryItem>().name == ItemName) {
			Destroy (other.gameObject);
		}
	}
}
