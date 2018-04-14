using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour {

    public string symbol;
    public List<MapQuest> quests;
    public List<MapPoint> destinations;
    [NonSerialized] public MapQuest currentQuest;
    [NonSerialized] public bool started;

}
