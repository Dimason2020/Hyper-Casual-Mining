using UnityEngine;
using UnityEngine.Events;

public class PointStorage : MonoBehaviour
{
    public static PointStorage instance;

    public static UnityEvent<int> OnPointsAmountChanged = new UnityEvent<int>();

    private int Points
    {
        get => PlayerPrefs.GetInt("points", 0);
        set
        {
            PlayerPrefs.SetInt("points", value);
        }
    }

    private void Awake()
    {
        instance = this;
        OnPointsAmountChanged?.Invoke(Points);
    }

    public void AddPoints(int newPoints)
    {
        Points += newPoints;
        OnPointsAmountChanged?.Invoke(Points);
    }
}
