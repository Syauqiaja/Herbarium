using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationButton : Destination360
{
    public BoardDisplayer boardDisplayer;
    public override void GoToNext(Transform camera)
    {
        boardDisplayer.GoToHerbarium();
    }
}
