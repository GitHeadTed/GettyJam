using UnityEngine;
using System.Collections;

public class TextBubble : Clickable {

	public string [] dialogue = { "First dialogue.", "Second dialogue" };
	public bool [] textUnlocked = {true, true};
	public int advanceToOnSolve = 0;
	private TextMesh tm;
	private int current;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
		current = 0;
		tm.text = dialogue[current];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void OnClicked()
	{

		if(current+1 < dialogue.Length && textUnlocked[current + 1]){
			current++;
			tm.text = dialogue[current];

			
		}
	}


	public void advance(){
		current = advanceToOnSolve;
		tm.text = dialogue[current];

	}


}