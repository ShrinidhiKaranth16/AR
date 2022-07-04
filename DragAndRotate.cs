using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRotate : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;
    public bool isActive = false;
    void Update()
    {
        if(isActive)
        {
            if (Input.touchCount == 1)
            {
                Touch touchToRotate = Input.GetTouch(0);

                if (touchToRotate.phase == TouchPhase.Moved)
                {
                    Quaternion rotationx = Quaternion.Euler(0f, -touchToRotate.deltaPosition.x * 20f * Time.deltaTime, 0f);
                    transform.rotation = rotationx * transform.rotation;
                }


                if (touchToRotate.phase == TouchPhase.Ended)
                {
                    isActive = false;
                }
            }

            if (Input.touchCount == 2)
            {
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);
                if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
                {
                    return;
                }

                if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = transform.localScale;
                }
                else
                {
                    var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    if (Mathf.Approximately(initialDistance, 0))
                    {
                        return;
                    }

                    var factor = currentDistance / initialDistance;
                    transform.localScale = initialScale * factor;
                }
            }
        }
    }
}
