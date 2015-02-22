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
        tooltip = GameObject.Find("Indicator").gameObject;
        tooltip.renderer.enabled = false;
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
        collider.enabled = false;
        Material mat = tooltip.renderer.material;
        float timer = 0;
        Color startCol = mat.color;
        while (timer < .5f)
        {
            timer += Time.deltaTime;
            mat.color = new Color(startCol.r, startCol.g, startCol.b, Mathf.Lerp(startCol.a, 0, timer / .5f));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}


