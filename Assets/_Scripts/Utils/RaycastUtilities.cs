using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RaycastUtilities
{
    public static bool PointerIsOverUI(Vector2 screenPos){
        GameObject hitObject = UIRaycast(ScreenPosToPointerData(screenPos));
        return hitObject != null && hitObject.layer == LayerMask.NameToLayer("UI");
    }
    static GameObject UIRaycast (PointerEventData pointerEventData){
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        return results.Count < 1 ? null : results[0].gameObject;
    }
    static PointerEventData ScreenPosToPointerData(Vector2 screenPos){
        return new(EventSystem.current){position = screenPos};
    }
}
