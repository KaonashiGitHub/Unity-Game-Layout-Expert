using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    private RectTransform rectTransform;

    private void Awake()
    {
        // Lấy RectTransform của đối tượng
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        // Di chuyển theo vị trí chuột
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Trả lại vị trí cũ và làm cho image có thể nhận raycast
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
