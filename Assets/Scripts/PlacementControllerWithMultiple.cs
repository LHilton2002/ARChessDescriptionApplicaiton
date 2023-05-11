using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ARRaycastManager))]


public class PlacementControllerWithMultiple : MonoBehaviour
{

    [SerializeField]
    private Button wayneBtn;
    [SerializeField]
    private Button patrickBtn;
    private GameObject placedPrefab;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        ChangePrefabTo("Wayne");
        //assumes your prefabs are named Wayne and Patrick (Could be white_knight)
        wayneBtn.onClick.AddListener(() => ChangePrefabTo("Wayne"));
        patrickBtn.onClick.AddListener(() => ChangePrefabTo("Patrick"));
    }


    void Update()
    {
        if (placedPrefab == null)
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                bool isOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                Debug.Log(isOverUI);

                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Debug.Log(" blocked raycast");
                    return;
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && (hit.transform.tag == "knight"))
                {
                    Debug.Log(" raycast");
                    if (Input.GetTouch(0).deltaTime > 0.2f)

                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
                else if (!isOverUI && arRaycastManager.Raycast(touchPosition, hits,
               UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                {
                    Debug.Log(" arraycast"); var hitPose = hits[0].pose;
                    Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }

    }


    void ChangePrefabTo(string prefabName)
    {
        placedPrefab = Resources.Load<GameObject>($"prefabs/{prefabName}");
        if (placedPrefab == null)
        {
            Debug.LogError($"Prefab with name {prefabName} could not be loaded, make sure you check the naming of your prefabs...");
        }
        Color wc = wayneBtn.image.color;
        Color pc = patrickBtn.image.color;
        Debug.Log("is wayne" + wc.a + " " + pc.a);
        switch (prefabName)
        {
            case "Wayne":
                wc.a = 1f;
                pc.a = 0.5f;
                break;
            case "Patrick":
                Debug.Log("is pat");
                wc.a = 0.5f;
                pc.a = 1f;
                break;
        }
        wayneBtn.image.color = wc;
        patrickBtn.image.color = pc;
    }
}