using UnityEngine;
using System.Collections;

public class FadeInPictureTooltip : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(fadeIn());   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startFadeIn()
    {
        StartCoroutine(fadeIn());
    }

    public void setInvis()
    {
        Color temp = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 0);
    }

    IEnumerator fadeIn()
    {

        SpriteRenderer mat = GetComponent<SpriteRenderer>();
        float timer = 0;
        Color startCol = mat.color;
        while (timer < .5f)
        {
            timer += Time.deltaTime;
            mat.color =  new Color(startCol.r, startCol.g, startCol.b, Mathf.Lerp(0, 1, timer / .5f));
            yield return new WaitForEndOfFrame();
        }
    }
}
