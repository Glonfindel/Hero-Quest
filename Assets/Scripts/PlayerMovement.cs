using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public MapPoint currentLocation;
    [NonSerialized] public MapPoint destination;
    public GameObject plotPanel;
    public GameObject exercisePanel;
    public GameObject travelingPanel;
    [NonSerialized] public int actionNumber = 0;

    private void Start()
    {
        currentLocation.currentQuest = RandomQuest();
        if (currentLocation.currentQuest.actions[actionNumber] == ActionOrder.Plot)
        {
            plotPanel.SetActive(true);
        }
        else
        {
            exercisePanel.SetActive(true);
        }
    }

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

    MapQuest RandomQuest()
    {
        return currentLocation.quests[UnityEngine.Random.Range(0, currentLocation.quests.Count)];
    }
}
