using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    private PlantInformationPanel informationPanel;
    
    private void Awake() {
        informationPanel = transform.parent.GetComponent<PlantInformationPanel>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            informationPanel.Show();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            informationPanel.Hide();
        }
    }
}
