using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PairInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoTitle, infoContent;
    public void AssignData(string title, string content){
        infoTitle.text = title;
        infoContent.text = content;
    }
}
