using UnityEngine;
using System.Collections;

public class PaintingScript : MonoBehaviour {

	public string ItemName;
	public GameObject nextPainting;
	public GameObject newItem;
	public GameObject textToAdvance;
    private GameObject successSound;

    void Start()
    {
        successSound = Resources.Load<GameObject>("Prefabs/SuccessSound");
    }
	
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
		if (textToAdvance != null)
			textToAdvance.GetComponent<TextBubble>().advance ();
        //Destroy(gameObject);
        Instantiate(successSound, transform.position, Quaternion.identity);
    }
}
