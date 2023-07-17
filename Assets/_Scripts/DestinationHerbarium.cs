using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationHerbarium : Destination360
{
    [SerializeField] private BoardDisplayer boardDisplayer;
    [SerializeField] private HerbariumData herbariumData;
    public override void GoToNext(Transform camera)
    {
        boardDisplayer.DisplayHerbarium(herbariumData);
    }
}
