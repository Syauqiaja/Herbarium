using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private RectTransform blackPanel;
    public static SceneLoader Instance{
        get{
            return instance;
        }
        set{}
    }
    private static SceneLoader instance;
    private void Awake() {
        if(Instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadScene(string sceneName){
        StartCoroutine(Load(sceneName));
    }
    
    private IEnumerator Load(string sceneName){
        AsyncOperation progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        progress.allowSceneActivation = false;
        Vector2 startPos = new Vector2(Screen.width, 0f);
        Vector2 endPos = new Vector2(-Screen.width, 0f);
        blackPanel.anchoredPosition = startPos;
        blackPanel.gameObject.SetActive(true);
        LeanTween.value(blackPanel.gameObject, 0f, 1f, 1f).setOnUpdate((float value) => {
            blackPanel.anchoredPosition = Vector2.Lerp(startPos, Vector2.zero, value);
        }).setOnComplete(()=>{
            progress.allowSceneActivation = true;
        });
        while(!progress.isDone){
            yield return null;
        }
        LeanTween.value(blackPanel.gameObject, 0f, 1f, 1f).setOnUpdate((float value) => {
            blackPanel.anchoredPosition = Vector2.Lerp(Vector2.zero, endPos, value);
        }).setOnComplete(()=>{
            progress.allowSceneActivation = true;
            blackPanel.gameObject.SetActive(false);
        });
        yield return null;
    }
}
