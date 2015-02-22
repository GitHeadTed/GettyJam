using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour {

    public int inventorySlot = 0;
    public float movementSpeed = 3;
    public string name;
    private Vector3 inventoryPos;

	// Use this for initialization
	void Start () {
        inventoryPos = GameObject.Find("Inventory" + inventorySlot).transform.position;
        StartCoroutine(lerpToInventorySlot());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void returnToInventory()
    {
        StartCoroutine(lerpToInventorySlot());
    }

    IEnumerator lerpToInventorySlot()
    {
        float timer = 0;
        float distanceToDest = Vector3.Distance(transform.position,inventoryPos);
        float movementDuration = distanceToDest / movementSpeed;
        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, inventoryPos, timer / movementDuration);
            yield return new WaitForEndOfFrame();
        }
    }
}
