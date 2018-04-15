using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour {

    public Text locationText;
    public Text descriptionText;
    public PlayerMovement player;
    public int plot = 0;

    private void OnEnable()
    {
        locationText.text = player.currentLocation.name;
        descriptionText.text = player.currentLocation.currentQuest.descriptions[plot];
    }

    public void Next()
    {
        plot++;
        player.plotPanel.SetActive(false);
        player.exercisePanel.SetActive(false);
        player.actionNumber++;
        if (player.actionNumber > player.currentLocation.currentQuest.actions.Count - 1)
        {
            plot = 0;
            player.exercisePanel.GetComponent<ExerciseManager>().exerciseNumber = 0;
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
