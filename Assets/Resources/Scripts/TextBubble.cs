using UnityEngine;
using System.Collections;

public class TextBubble : MonoBehaviour {

	public string [] dialogue = { "First dialogue.", "Second dialogue" };
	public bool [] textUnlocked = {true, true};
	private TextMesh tm;
	private int current;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
		current = 0;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void OnClicked()
	{
		next();
	}
	
	public void next(){
		bool unlocked = true;
		if(current + 1 < textUnlocked.Length){
			unlocked = textUnlocked[current + 1];
		}
		
		if(current+1 < dialogue.Length && unlocked){
			current++;
			tm.text = dialogue[current];
		                                      
		}
	}
}
