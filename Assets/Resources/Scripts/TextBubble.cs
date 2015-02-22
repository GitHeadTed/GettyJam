using UnityEngine;
using System.Collections;

public class TextBubble : Clickable {

	public string [] dialogue = { "First dialogue.", "Second dialogue" };
	public bool [] textUnlocked = {true, true};
    public GameObject[] objectEnable;
	public int advanceToOnSolve = 0;
	private TextMesh tm;
	private int current;
    private GameObject childTooltip;


	// Use this for initialization
	void Start () {
		for(int i = 0; i < dialogue.Length; i++) dialogue[i] = dialogue[i].Replace("NEWLINE","\n");
		tm = GetComponent<TextMesh>();
		current = 0;
		tm.text = dialogue[current];
        childTooltip = transform.FindChild("Tooltip").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void OnClicked()
	{

		if(current+1 < dialogue.Length && textUnlocked[current + 1]){
			current++;
			tm.text = dialogue[current];
            if(objectEnable[current])
                objectEnable[current].SetActive(true);
			
		}
	}


	public void advance(){
		current = advanceToOnSolve;
		tm.text = dialogue[current];

	}


}