using UnityEngine;
using System.Collections;

public class ClickableItemPickup : Clickable {
	
	// Use this for initialization

    public GameObject itemPrefab;
    private PlayerControllerScript playerScript;
    private GameObject tooltip;

	// Update is called once per frame
	void Update () {
        playerScript = GameObject.FindObjectOfType<PlayerControllerScript>();
        tooltip = transform.FindChild("Tooltip").gameObject;
    }
	
	public override void OnClicked()
	{
	    GameObject temp = (GameObject)Instantiate (itemPrefab, transform.position, Quaternion.identity);
        playerScript.addInventoryItem(temp.GetComponent<InventoryItem>());
        temp.transform.parent = Camera.main.transform;
        temp.collider.enabled = false;
        if(tooltip)
            StartCoroutine(fadeOutChild());
        //Destroy(gameObject);
	}

    IEnumerator fadeOutChild()
    {
        TextMesh text = tooltip.GetComponent<TextMesh>();
        float timer = 0;
        Color startCol = text.color;
        while (timer < .5f)
        {
            timer += Time.deltaTime;
            text.color = new Color(startCol.r, startCol.g, startCol.b, Mathf.Lerp(startCol.a, 0, timer / .5f));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}


