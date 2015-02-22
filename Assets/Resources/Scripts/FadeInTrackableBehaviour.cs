using UnityEngine;
using System.Collections;

public class FadeInTrackableBehaviour : MonoBehaviour, ITrackableEventHandler
{

    public float fadeInTime = 1;
    public float fadeOutTime= 1;
    private Transform[] transforms;
    private TrackableBehaviour mTrackableBehaviour;

    // Use this for initialization
    void Awake()
    {
        transforms = GetComponentsInChildren<Transform>();
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
    void Update()
    {

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
            if (transforms[k].GetComponent<Clickable>())
            {
                if (transforms[k].GetComponent<Clickable>().enabled)
                {
                    FadeIn(transforms[k]);
                }
            }
            else
            {
                FadeIn(transforms[k]);
            }
        }
    }

    private void OnTrackingLost()
    {
        for (int k = 0; k < transforms.Length; k++)
        {
            if (transforms[k].GetComponent<Clickable>())
            {
                if (transforms[k].GetComponent<Clickable>().enabled)
                {
                    FadeOut(transforms[k]);
                }
            }
            else
            {
                FadeOut(transforms[k]);
            }
        }
    }

    IEnumerator FadeIn(Transform trans)
    {
       
        Renderer renderer =  trans.renderer;
        renderer.enabled = true;
        trans.collider.enabled = true;
        float timer = 0;
        Color startCol = renderer.material.GetColor(0);
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            renderer.material.SetColor(0,new Color(startCol.r,startCol.g,startCol.b,Mathf.Lerp(0,1,timer/fadeInTime)));
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeOut(Transform trans)
    {
        Renderer renderer =  trans.renderer;
        float timer = 0;
        Color startCol = renderer.material.GetColor(0);
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            renderer.material.SetColor(0,new Color(startCol.r,startCol.g,startCol.b,Mathf.Lerp(1,0,timer/fadeOutTime)));
            yield return new WaitForEndOfFrame();
        }
        renderer.enabled = false;
        trans.collider.enabled = false;
    }
    
}
