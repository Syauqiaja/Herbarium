using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Herbarium/Herbarium Data", fileName = "Herbarium Data")]
public class HerbariumData : ScriptableObject
{
    public string mainTitle;
    public string scientificTitle;
    public int totalPlants;
    public string scene;
}
