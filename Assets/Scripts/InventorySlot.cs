using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GridLayoutGroup targetGridLayoutGroup; // Đối tượng Grid Layout Group cần điều chỉnh kích thước

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            if (draggableItem != null)
            {
                draggableItem.parentAfterDrag = transform;

                // Hiển thị lại Item
                draggableItem.parentAfterDrag.gameObject.SetActive(true);
            }
        }
    }
}
