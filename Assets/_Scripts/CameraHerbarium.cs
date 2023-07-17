using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHerbarium : MonoBehaviour
{
    public float cameraSensitivity = 1f;
    public MainHerbariumManager herbariumManager;
    public Transform container;
    public Transform footstep;
    public SpriteRenderer footstepRenderer;
    public HoverPointer hoverPointer;
    public float maxSpeed =1f;
    private float doubleClickTime = 0.75f;
    private bool isDoubleClicking = false;
    enum PlayerState{
        Idle, Walk
    }

    [Header("Raycasting")]
    public float maxDistance;
    public LayerMask layerMask;
    public RectTransform crosshair;

    private PlayerState state {
        get{
            return _state;
        }
        set{
            _state = value;
            if(value == PlayerState.Idle){
                footstep.gameObject.SetActive(false);
            }else{
                footstep.gameObject.SetActive(true);
            }
        }
    }
    private PlayerState _state = PlayerState.Idle;
    private Vector3 _currentVelocity;
    private float speedMultiplier = 1f;
    private Vector3 targetDestination;

    private void Awake() {
        herbariumManager.herbariumVisited = true;
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
            hoverPointer.gameObject.SetActive(true);
            Vector3 targetPos = hit.point;
            // When footstep moving, keep updating footstep color
            if(hit.collider.CompareTag("PlantTrigger")){
                hoverPointer.hoveringState = HoveringState.Stepping;
                targetPos = hit.transform.position;
            }else{
                hoverPointer.hoveringState = HoveringState.Normal;
            }
            hoverPointer.transform.position = new Vector3(targetPos.x, footstep.position.y, targetPos.z);

            // Detect when player clicked on desired position
            if(Input.GetButtonDown("Fire1")){
                footstep.position = hoverPointer.transform.position;
                targetDestination = new Vector3(footstep.position.x, container.position.y, footstep.position.z);
                state = PlayerState.Walk;
                doubleClickTime = 0.8f;

                //DoubleClicking
                if(state == PlayerState.Walk && isDoubleClicking == false && doubleClickTime > 0){
                    speedMultiplier = 2f;
                    isDoubleClicking = true;
                }

                //Exit if player clicking on the exit door
                if(hit.collider.CompareTag("ExitDoor")){
                    SceneLoader.Instance.LoadScene("Image360View");
                }
            }
        }else{
            hoverPointer.gameObject.SetActive(false);
            crosshair.sizeDelta = new Vector2(12,12);
        }

        // Moving player to the footstep position
        if(state == PlayerState.Walk){
            container.position = Vector3.SmoothDamp(container.position, targetDestination, ref _currentVelocity, 0.3f, maxSpeed * speedMultiplier);
            if((container.position - targetDestination).magnitude <= 0.01f){
                state = PlayerState.Idle;
                speedMultiplier = 1f;
                isDoubleClicking = false;
            }
            doubleClickTime -= Time.deltaTime;
        }
    }
}
