using TMPro;
using UnityEngine;

public class CoordinatesView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(Vector2 coordinates)
    {
        _text.text = $"Coordinates: {coordinates}";
    }
}
