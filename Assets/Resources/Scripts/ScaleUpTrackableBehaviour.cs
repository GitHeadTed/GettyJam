using UnityEngine;
using System.Collections;

public class ScaleUpTrackableBehaviour : MonoBehaviour, ITrackableEventHandler
{

    public float scaleInTime = 1;
    public float scaleOutTime = 1;
    private Transform[] transforms;
    private Vector3[] origScales;
    private TrackableBehaviour mTrackableBehaviour;

	// Use this for initialization
    void Awake()
    {
        transforms = GetComponentsInChildren<Transform>();
        origScales = new Vector3[transforms.Length];
        for (int k = 0; k < transforms.Length; k++)
        {
            origScales[k] = transforms[k].localScale;
        }
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    private void OnTrackingFound()
    {
        for (int k = 0; k < transforms.Length; k++)
        {
            StartCoroutine(ScaleUp(transforms[k], origScales[k]));
        }
    }

    private void OnTrackingLost()
    {
        for (int k = 0; k < transforms.Length; k++)
        {
            StartCoroutine(ScaleDown(transforms[k], origScales[k]));
        }
    }

    IEnumerator ScaleUp(Transform trans,Vector3 scale)
    {
        trans.collider.enabled = true;
        trans.renderer.enabled = true;
        float timer = 0;
        while (timer < scaleInTime)
        {
            timer += Time.deltaTime;
            trans.transform.localScale = Vector3.Lerp(Vector3.zero , scale, timer / scaleInTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator ScaleDown(Transform trans, Vector3 scale)
    {
        float timer = 0;
        while (timer < scaleInTime)
        {
            timer += Time.deltaTime;
            trans.transform.localScale = Vector3.Lerp(scale, Vector3.zero, timer / scaleInTime);
            yield return new WaitForEndOfFrame();
        }
        trans.collider.enabled = false;
        trans.renderer.enabled = false;
    }
}
