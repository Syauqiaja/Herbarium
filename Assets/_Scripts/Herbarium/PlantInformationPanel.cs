using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantInformationPanel : MonoBehaviour
{
    [SerializeField] private PlantData defaultPlantData;
    [Header("Canvasses")]
    [SerializeField] private CanvasGroup canvas1;
    private Vector3 canvas1Pos;
    [SerializeField] private CanvasGroup canvas2;
    private Vector3 canvas2Pos;
    [SerializeField] private CanvasGroup canvas3;
    private Vector3 canvas3Pos;

    [Header("UI Component")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private List<PairInfo> pairInfos;
    private int infoCount = 0;
    private void Awake() {
        if(defaultPlantData != null) AssignData(defaultPlantData);
        canvas1Pos = canvas1.transform.localPosition;
        canvas2Pos = canvas2.transform.localPosition;
        canvas3Pos = canvas3.transform.localPosition;
    }

    public void AssignData(PlantData plantData){
        titleText.text = plantData.Title;
        if(plantData.Kingdom != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Kingdom:", plantData.Kingdom);
            infoCount++;
        }
        if(plantData.Subkingdom != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Subkingdom:", plantData.Subkingdom);
            infoCount++;
        }
        if(plantData.Superdivisi != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Superdivisi:", plantData.Superdivisi);
            infoCount++;
        }
        if(plantData.Divisi != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Divisi:", plantData.Divisi);
            infoCount++;
        }
        if(plantData.Kelas != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Kelas:", plantData.Kelas);
            infoCount++;
        }
        if(plantData.Subkelas != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Subkelas:", plantData.Subkelas);
            infoCount++;
        }
        if(plantData.Ordo != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Ordo:", plantData.Ordo);
            infoCount++;
        }
        if(plantData.Subordo != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Subordo:", plantData.Subordo);
            infoCount++;
        }
        if(plantData.Famili != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Famili:", plantData.Famili);
            infoCount++;
        }
        if(plantData.Genus != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Genus:", plantData.Genus);
            infoCount++;
        }
        if(plantData.Spesies != ""){
            pairInfos[infoCount].gameObject.SetActive(true);
            pairInfos[infoCount].AssignData("Spesies:", plantData.Spesies);
            infoCount++;
        }
    }

    public void Hide(){
        LeanTween.cancel(canvas1.gameObject);
        LeanTween.cancel(canvas2.gameObject);
        LeanTween.cancel(canvas3.gameObject);
        LeanTween.alphaCanvas(canvas1, 0, 0.3f);
        LeanTween.alphaCanvas(canvas2, 0, 0.3f);
        LeanTween.alphaCanvas(canvas3, 0, 0.3f);
    }

    public void Show(){
        canvas1.transform.localPosition = canvas1Pos + new Vector3(50f, 0f, 0f);
        canvas2.transform.localPosition = canvas2Pos + new Vector3(-50f, 0f, 0f);
        canvas3.transform.localPosition = canvas3Pos + new Vector3(0f, -20f, 0f);
        LeanTween.moveLocal(canvas1.gameObject, canvas1Pos, 0.5f).setEaseOutSine();
        LeanTween.moveLocal(canvas2.gameObject, canvas2Pos, 0.5f).setEaseOutSine();
        LeanTween.moveLocal(canvas3.gameObject, canvas3Pos, 0.5f).setEaseOutSine();
        LeanTween.alphaCanvas(canvas1, 1, 0.5f);
        LeanTween.alphaCanvas(canvas2, 1, 0.5f);
        LeanTween.alphaCanvas(canvas3, 1, 0.5f);
    }
}
