using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera360Viewer : MonoBehaviour
{
    public float cameraSensitivity = 1f;
    public MainHerbariumManager herbariumManager;
    public Transform lastDestination;
    public Transform container;

    [Header("Raycasting")]
    public float maxDistance;
    public LayerMask layerMask;
    public RectTransform crosshair;

    private void Awake() {
        if(herbariumManager.herbariumVisited){
            container.position = lastDestination.position;
        }
    }
    private void LateUpdate() {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        container.Rotate(new Vector3(0, x,0)*Time.deltaTime * cameraSensitivity);
        transform.Rotate(new Vector3(-y, 0,0)*Time.deltaTime * cameraSensitivity);
    }

    private void Update() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask)){
            if(Input.GetButtonDown("Fire1")){
                hit.collider.GetComponent<Destination360>().GoToNext(container);
                crosshair.sizeDelta = new Vector2(18,18);
            }else{
                crosshair.sizeDelta = new Vector2(25,25);
            }
        }else{
            crosshair.sizeDelta = new Vector2(12,12);
        }
    }
}
