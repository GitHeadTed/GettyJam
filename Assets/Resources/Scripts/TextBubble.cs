using UnityEngine;
using System.Collections;

public class TextBubble : Clickable {

	public string [] dialogue = { "First dialogue.", "Second dialogue" };
	public bool [] textUnlocked = {true, true};
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
		
		bool unlocked = true;
		if(current + 1 < textUnlocked.Length){
			unlocked = textUnlocked[current + 1];
		}
		
		if(current+1 < dialogue.Length){
			current++;
			tm.text = dialogue[current];

			
		}
	}
	
	public void next(){
		if(current+1 < dialogue.Length){
			current++;
			tm.text = dialogue[current];
			
		}
		
	}
}
