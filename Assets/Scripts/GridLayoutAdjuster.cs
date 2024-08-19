using UnityEngine;
using UnityEngine.UI;

public class GridLayoutAdjuster : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup[] gridLayoutGroups; // Danh sách nhiều Grid Layout Group

    // Method to adjust the size of the DraggableItem
    public void AdjustItemSize(DraggableItem draggableItem, GridLayoutGroup targetGridLayoutGroup)
    {
        // Get the size of a cell in the selected Grid Layout Group
        Vector2 cellSize = targetGridLayoutGroup.cellSize;

        // Apply this size to the draggable item
        RectTransform itemRectTransform = draggableItem.GetComponent<RectTransform>();
        itemRectTransform.sizeDelta = cellSize;
    }
}
