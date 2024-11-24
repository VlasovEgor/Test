using TMPro;
using UnityEngine;

public class LaserRechargeView: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(float rechargeTime)
    {
        _text.text = $"Recharge Time: {rechargeTime:F2}";
    }
}