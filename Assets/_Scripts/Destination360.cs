using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination360 : MonoBehaviour
{
    [SerializeField] private Transform nextDestination;

    public virtual void GoToNext(Transform camera){
        camera.position = nextDestination.position;
    }
}
