using TMPro;
using UnityEngine;

public class InstantaneousSpeedView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(float speed)
    {
        _text.text = $"Instantaneous Speed: {speed:F2}";
    }
}
