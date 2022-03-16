using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;

    public UnityEvent onLongClick;
    public Player player;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Player.Carregar();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        if(Player.podeatirar)
        {
            Player.Tiro();
            player.Shoot();
            Player.esfriar = true;
        }
       
    }



   
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Reset();
            }
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
}
