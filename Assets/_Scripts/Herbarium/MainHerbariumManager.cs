using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(menuName = "Herbarium/HerbariumManager")]
public class MainHerbariumManager : ScriptableObject
{
    public List<PlantData> plantDatas;
    public event Action<PlantData> displayData;
    [HideInInspector] public bool herbariumVisited;

    private void OnApplicationQuit() {
        herbariumVisited = false;
    }
}
