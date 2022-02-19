using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private int pointsAmount;

    private void OnEnable()
    {
        PointStorage.OnPointsAmountChanged.AddListener(UpdateText);
    }

    private void OnDisable()
    {
        PointStorage.OnPointsAmountChanged.RemoveListener(UpdateText);
    }

    private void UpdateText(int value)
    { 
        pointsAmount = value;
        pointsText.SetText(pointsAmount.ToString());
    }
}
