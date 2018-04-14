using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Exercise", order = 1)]
public class QuestExercise : ScriptableObject {

    public string exerciseText;
    public List<Sprite> exercise;
    public int time;

}
