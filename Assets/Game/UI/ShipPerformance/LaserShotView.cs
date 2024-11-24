using TMPro;
using UnityEngine;

public class LaserShotView: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(int amountShots)
    {
        _text.text = $"Shots left: {amountShots}";
    }
}