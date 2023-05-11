using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleManager : MonoBehaviour
{
    public ARRaycastManager raycastmanager;
    public GameObject Reticle;

    // Start is called before the first frame update
    void Start()
    {
        raycastmanager = FindObjectOfType<ARRaycastManager>();
        Reticle = this.transform.GetChild(0).gameObject;
        Reticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        raycastmanager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.Planes);
        if (hitpoint.Count > 0)
        {
            transform.position = hitpoint[0].pose.position;
            transform.rotation = hitpoint[0].pose.rotation;
            if (!Reticle.activeInHierarchy)
            {
                Reticle.SetActive(true);
            }
        }



    }
}
