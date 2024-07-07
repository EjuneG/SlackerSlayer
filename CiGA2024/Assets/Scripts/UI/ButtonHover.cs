using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text tmpText; // Reference to the TMP_Text component
    public Color hoverColor = Color.red; // Color when hovering
    private Color originalColor; // Store the original color

    private void Start()
    {
        if (tmpText == null)
        {
            tmpText = GetComponentInChildren<TMP_Text>();
        }
        originalColor = tmpText.color; // Store the original color of the text
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tmpText.color = hoverColor; // Change to hover color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tmpText.color = originalColor; // Revert to original color
    }
}