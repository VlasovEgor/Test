using TMPro;
using UnityEngine;

public class AngleRotationView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(float angle)
    {
        _text.text = $"Angle Rotation: {angle}";
    }
}
