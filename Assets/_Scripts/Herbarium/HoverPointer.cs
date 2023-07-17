using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPointer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite1, sprite2;
    [Header("Color Variations")]
    [SerializeField] private Color normalStateColor;
    [SerializeField] private Color steppingStateColor;
    [SerializeField] private Color disabledStateColor;
    public HoveringState hoveringState{
        get{
            return _hoveringState;
        }
        set{
            switch(value){
                case HoveringState.Normal:
                    sprite1.color = normalStateColor;
                    sprite2.color = normalStateColor;
                    break;
                case HoveringState.Stepping:
                    sprite1.color = steppingStateColor;
                    sprite2.color = steppingStateColor;
                    break;
                case HoveringState.Disabled:
                    sprite2.color = disabledStateColor;
                    sprite1.color = disabledStateColor;
                    break;
            }
        }
    }
    private HoveringState _hoveringState = HoveringState.Normal;
    
}

public enum HoveringState{
    Normal,
    Stepping,
    Disabled,
}
