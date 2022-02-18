using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MineralClickHandler : MonoBehaviour, IPointerClickHandler
{
    public bool isPreciousOre;

    private Action<MineralClickHandler> OnKillAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isPreciousOre)
            return;

        Debug.Log("Oops");
        OnKillAction(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnKillAction(this);
        }
    }

    public void Init(Action<MineralClickHandler> action)
    {
        OnKillAction = action;
    }
}
