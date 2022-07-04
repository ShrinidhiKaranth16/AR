using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceobject : MonoBehaviour
{
    List<GameObject> EnvInstantiateList = new List<GameObject>();
    int spawnCount = 0;
    GameObject EnvInstantiate;
    private GameObject spawnedObjectEnv;
    private ARRaycastManager raycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    bool isPlaced = false;

    GameObject selectedObject;


    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if(Input.touchCount>0)
        {
            touchPos = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPos = default;
        return false;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;

                bool isOverUI = touchPosition.IsPointOverUIObject();


                if (!isOverUI && raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;
                    if(spawnedObjectEnv == null)
                    {
                        spawnedObjectEnv = Instantiate(EnvInstantiate, hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
    }

    public void SetPrefab(GameObject prefab)
    {
        EnvInstantiate = prefab;
        spawnedObjectEnv = null;
    }

    public void SetNull()
    {
        EnvInstantiate = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
