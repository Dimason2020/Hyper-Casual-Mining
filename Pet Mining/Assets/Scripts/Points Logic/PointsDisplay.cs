using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private int pointsAmount;

    [SerializeField] private Animator animator;

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

        animator.SetBool("OnOreErned", true);
    }

    public void FinishedAnimation()
    {
        animator.SetBool("OnOreErned", false);
    }
}
