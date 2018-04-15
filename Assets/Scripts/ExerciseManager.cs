using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour {

    public Text locationText;
    public Text description;
    public Image image;
    public Text helpText;
    public Text timer;
    public Button button;
    public PlayerMovement player;
    private List<Sprite> sprites;
    private float startTime;
    private bool started = false;
    public int exerciseNumber = 0;
    private int i = -1;

    private void OnEnable()
    {
        sprites = new List<Sprite>(player.currentLocation.currentQuest.exercises[exerciseNumber].exercise);
        locationText.text = player.currentLocation.name;
        description.text = player.currentLocation.currentQuest.exercises[exerciseNumber].exerciseText;
        InvokeRepeating("Change", 0, 0.25f);
    }

    private void Update()
    {
        if (started)
        {
            timer.text = Mathf.RoundToInt(player.currentLocation.currentQuest.exercises[exerciseNumber].time - (Time.time - startTime)).ToString();
        }
        if (Mathf.RoundToInt(player.currentLocation.currentQuest.exercises[exerciseNumber].time - (Time.time - startTime)) <= 0 && started)
        {
            started = false;
            timer.text = "0";
            timer.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
            helpText.gameObject.SetActive(true);
            Next();
        }
    }

    public void StartExercise()
    {
        startTime = Time.time;
        button.gameObject.SetActive(false);
        helpText.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        started = true;
    }

    void Change()
    {
        i++;
        if (i > sprites.Count - 1)
        {
            i = 0;
        }
        image.sprite = sprites[i];
    }

    public void Next()
    {
        CancelInvoke();
        exerciseNumber++;
        player.plotPanel.SetActive(false);
        player.exercisePanel.SetActive(false);
        player.actionNumber++;
        if (player.actionNumber > player.currentLocation.currentQuest.actions.Count)
        {
            exerciseNumber = 0;
            player.plotPanel.GetComponent<PlotManager>().plot = 0;
            player.actionNumber = 0;
            player.gold += player.currentLocation.currentQuest.goldValue;
            player.currentLocation.quests.Remove(player.currentLocation.currentQuest);
            int questRemaining = 0;
            foreach (var point in FindObjectsOfType<MapPoint>())
            {
                questRemaining += point.quests.Count;
            }
            player.questRemaining = questRemaining;
            return;
        }
        else if (player.currentLocation.currentQuest.actions[player.actionNumber] == ActionOrder.Plot)
        {
            player.plotPanel.SetActive(true);
        }
        else
        {
            player.exercisePanel.SetActive(true);
        }
    }

}
