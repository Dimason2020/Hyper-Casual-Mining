using System;
using UnityEngine;

public class MineralClickHandler : MonoBehaviour
{
    public bool isPreciousOre;

    private Action<MineralClickHandler> OnKillAction;

    public void OnObjectClicked()
    {
        if (!isPreciousOre)
            return;

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
