using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public MapPoint currentLocation;
    [NonSerialized] public MapPoint destination;
    public Text questText;
    public Text goldText;
    [NonSerialized] public float gold;
    public GameObject winPanel;
    public GameObject plotPanel;
    public GameObject exercisePanel;
    public GameObject travelingPanel;
    [NonSerialized] public int actionNumber = 0;
    [NonSerialized] public int questRemaining = 12;

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

    void Update()
    {
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

                    currentLocation.currentQuest = RandomQuest();
                    if (!currentLocation.currentQuest) return;
                    if (currentLocation.currentQuest.actions[actionNumber] == ActionOrder.Plot)
                    {
                        plotPanel.SetActive(true);
                    }
                    else
                    {
                        exercisePanel.SetActive(true);
                    }
                }
            }
        }
        goldText.text = "Gold: " + gold.ToString();
        questText.text = "Quests remaining: " + questRemaining.ToString();
        if (questRemaining == 0)
        {
            winPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    MapQuest RandomQuest()
    {
        if (currentLocation.quests.Count > 0)
            return currentLocation.quests[UnityEngine.Random.Range(0, currentLocation.quests.Count)];
        else
            return null;
    }
}
