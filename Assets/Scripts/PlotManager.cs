using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour {

    public Text locationText;
    public Text descriptionText;
    public PlayerMovement player;
    private int plot = 0;

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
