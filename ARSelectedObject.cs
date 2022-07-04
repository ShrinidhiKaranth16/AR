using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARSelectedObject : MonoBehaviour
{
    GameObject selectedObject;
    Touch touch;
    public GameObject DelBtn;

    public GameObject InfoPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    selectedObject = hit.transform.gameObject;
                    var sobj = selectedObject.GetComponent<DragAndRotate>();
                    sobj.isActive = true;
                    if(selectedObject != null)
                    {
                        DelBtn.SetActive(true);
                    }
                    else
                    {
                        DelBtn.SetActive(false);
                    }
                }
            }
        }

    }

    public void DestroySelected()
    {
        Destroy(selectedObject);
    }

    public void HideInfoPanel()
    {
        if(!InfoPanel.activeSelf)
        {
            InfoPanel.SetActive(true);
        }
        else
        {
            InfoPanel.SetActive(false);
        }
    }

    public void ExitApp()
    { 
        Application.Quit(); 
    }

}
