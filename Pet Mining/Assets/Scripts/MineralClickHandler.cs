using System;
using UnityEngine;

public class MineralClickHandler : MonoBehaviour
{
    public bool isPreciousOre;

    private PointStorage pointStorage;

    private Action<MineralClickHandler> OnKillAction;

    private void Start()
    {
        pointStorage = PointStorage.instance;
    }

    public void OnObjectClicked()
    {
        if (!isPreciousOre)
            return;

        pointStorage.AddPoints(5);
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
