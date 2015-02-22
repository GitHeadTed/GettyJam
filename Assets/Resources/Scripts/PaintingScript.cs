using UnityEngine;
using System.Collections;

public class PaintingScript : MonoBehaviour {

	public string ItemName;
	public GameObject nextPainting;
	public GameObject newItem;
	
    /*
    void OnTriggerEnter(Collider other){
		if (other.GetComponent<InventoryItem>().name == ItemName) {
			Destroy (other.gameObject);
			if(nextPainting != null){
			
			}
			if(newItem != null){
			
			}
		}
	}*/

    public void OnSolved()
    {
        Destroy(gameObject);
    }
}
