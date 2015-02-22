using UnityEngine;
using System.Collections;

public class TooltipFadein : MonoBehaviour {



	// Use this for initialization
	void Start () {
        StartCoroutine(fadeIn());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    IEnumerator fadeIn()
    {
        
        TextMesh text = GetComponent<TextMesh>();
        float timer = 0;
        Color startCol = text.color;
        while (timer < .5f)
        {
            timer += Time.deltaTime;
            text.color = new Color(startCol.r, startCol.g, startCol.b, Mathf.Lerp(0, 1, timer / .5f));
            yield return new WaitForEndOfFrame();
        }
    }
}
