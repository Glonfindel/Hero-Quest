using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelingScript : MonoBehaviour {

    public Text description;
    public Text helpText;
    public Slider slider;
    public Button button;
    public PlayerMovement player;
    private float startTime;
    private bool started = false;
    private int distance;

    private void OnEnable()
    {
        distance = Mathf.RoundToInt(Vector3.Distance(player.currentLocation.transform.position, player.destination.transform.position)) * 10;
        description.text = "You are traveling to " + player.destination.name + "\r\nMake high knees for " + distance + " seconds to reach your destination";
    }

    private void Update()
    {
        if (started)
        {
            slider.value = (Time.time - startTime) / (distance - 1);
        }
        if (slider.value == 1)
        {
            started = false;
            slider.value = 0;
            button.gameObject.SetActive(true);
            helpText.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void StartExercise()
    {
        startTime = Time.time;
        button.gameObject.SetActive(false);
        helpText.gameObject.SetActive(false);
        started = true;
    }

}
