using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public MapPoint currentLocation;
    [NonSerialized] public MapPoint destination;
    public GameObject travelingPanel;

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                MapPoint clickedPoint = hit.collider.GetComponent<MapPoint>();
                if (clickedPoint == currentLocation) return;
                if (currentLocation.destinations.Contains(clickedPoint))
                {
                    destination = clickedPoint;
                    travelingPanel.SetActive(true);
                    transform.position = hit.collider.transform.position;
                    currentLocation = destination;
                }
            }
        }
    }
}
