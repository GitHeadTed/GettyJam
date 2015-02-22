using UnityEngine;
using System.Collections;

public class EnableItemScripts : MonoBehaviour {

    public bool enableOnStart;
    private Item[] items;

	// Use this for initialization
	void Start () {
        items = GetComponentsInChildren<Item>();
        if (enableOnStart)
        {
            foreach(Item i in items){
                i.enabled = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void enableChildrenItemScripts()
    {
        foreach (Item i in items)
        {
            i.enabled = true;
        }
    }
}
