using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public MapPoint currentLocation;

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (currentLocation.Destinations.Contains(hit.collider.GetComponent<MapPoint>()))
                {
                    transform.position = hit.collider.transform.position;
                    currentLocation = hit.collider.GetComponent<MapPoint>();
                }
            }
        }
    }
}
