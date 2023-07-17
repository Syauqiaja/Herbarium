using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BoardDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainTitleText;
    [SerializeField] private TextMeshProUGUI scientificTitleText;
    [SerializeField] private TextMeshProUGUI plantsCountText;
    [SerializeField] private CanvasGroup panelCanvas;
    private string sceneHolded;

    public void DisplayHerbarium(HerbariumData herbariumData){
        if(panelCanvas.alpha != 0){
            LeanTween.alphaCanvas(panelCanvas, 0, 0.25f).setOnComplete(()=>{
                AssignData(herbariumData);
            });
        }else{
            AssignData(herbariumData);
        }
    }
    void AssignData(HerbariumData herbariumData){
        sceneHolded = herbariumData.scene;
        mainTitleText.text = herbariumData.mainTitle;
        scientificTitleText.text = herbariumData.scientificTitle;
        plantsCountText.text = "Tersimpan : "+ herbariumData.totalPlants.ToString();
        LeanTween.alphaCanvas(panelCanvas, 1, 0.25f);
    }
    public void GoToHerbarium(){
        SceneLoader.Instance.LoadScene(sceneHolded);
    }
}
