using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", order = 1)]
public class MapQuest : ScriptableObject {

    public List<ActionOrder> actions;
    public List<string> descriptions;
    public List<QuestExercise> exercises;
    public float goldValue;
}

public enum ActionOrder { Plot, Exercise }
