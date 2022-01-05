using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShildButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{   

    public bool isHold = false;
    [SerializeField] private Player _player;

    public void OnPointerDown(PointerEventData pointerEventData)
    { 
        isHold = true;
        _player.Invulnerability();
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isHold = false;
        _player.Vulnerability();
    }
}
