using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public string name;
	// Use this for initialization
	void Awake () {
        enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnClicked()
    {
        Instantiate(Resources.Load("Prefabs/TestCube"), transform.position, Quaternion.identity);
    }
}
