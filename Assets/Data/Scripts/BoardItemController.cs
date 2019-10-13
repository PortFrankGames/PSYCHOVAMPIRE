using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine.SceneManagement;


public class BoardItemController : MonoBehaviour
{
    private Vector3 mOffset;
    private float mCoordinates;
    public GameObject mainCamera;
    public int visionStartup;
    public bool visionStartupBool;
    public bool itemSpawnBool;
    private bool mouseOver;

    private void Start()
    {
        gameObject.GetComponent<cakeslice.Outline>().enabled = false;
        visionStartupBool = true;
    }

    public void Update()
    {
        if (mouseOver = true && Input.GetMouseButton(1))
        {
            OnRightMouseButton();
        }
    }

    void OnRightMouseButton()
    {
        if (visionStartupBool == true)
        {
            if (visionStartup == 10)
            {
                LoadVision();
                visionStartupBool = false;
            }
            else if(visionStartup == 5)
            {
                SpawnItems();
            }
            else
            {
                visionStartup++;
            }
        }

    }

    void SpawnItems()
    {
        if(itemSpawnBool == false)
        {
            //spawn the items
            itemSpawnBool = true;
        }
        else
        {
            return;
        }
    }

    void LoadVision()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Vision");
    }

    void OnMouseEnter()
    {
        mouseOver = true;
        gameObject.GetComponent<cakeslice.Outline>().enabled = true;
    }

    void OnMouseDown()
    {
        mCoordinates = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mCoordinates;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        gameObject.GetComponent<cakeslice.Outline>().enabled = false;
    }
}
