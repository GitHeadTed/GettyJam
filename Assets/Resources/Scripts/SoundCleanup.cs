using UnityEngine;
using System.Collections;

public class SoundCleanup : MonoBehaviour {

    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator cleanupSound()
    {
        while (source.isPlaying)
            yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
