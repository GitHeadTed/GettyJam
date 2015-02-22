using UnityEngine;
using System.Collections;

public class EnableClickablecripts : MonoBehaviour {

    public bool enableOnStart;
    private Clickable[] items;

	// Use this for initialization
	void Start () {
        items = GetComponentsInChildren<Clickable>();
        if (enableOnStart)
        {
            foreach (Clickable i in items)
            {
                i.enabled = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void enableChildrenItemScripts()
    {
        foreach (Clickable i in items)
        {
            i.enabled = true;
        }
    }
}
