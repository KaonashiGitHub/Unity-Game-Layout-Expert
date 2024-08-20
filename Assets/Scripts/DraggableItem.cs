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

    // Tag để kiểm tra đối tượng Content và Viewport
    public string contentTag = "Content";
    public string viewportTag = "Viewport";

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
        // Sử dụng Raycast để kiểm tra các đối tượng mà chuột đang nằm trên
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        Transform targetTransform = null;

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag(viewportTag))
            {
                // Nếu đối tượng là Viewport, tìm Content bên trong Viewport
                Transform viewportTransform = result.gameObject.transform;
                Transform contentTransform = FindChildWithTag(viewportTransform, contentTag);
                if (contentTransform != null)
                {
                    targetTransform = contentTransform;
                }
                break;
            }
            else if (result.gameObject.CompareTag(contentTag))
            {
                // Nếu đối tượng là Content, gán trực tiếp
                targetTransform = result.gameObject.transform;
                break;
            }
        }

        // Đặt lại parent là đối tượng Content nếu tìm thấy
        if (targetTransform != null)
        {
            transform.SetParent(targetTransform, false);
        }
        else
        {
            // Nếu không, trả lại vị trí cũ
            transform.SetParent(parentAfterDrag, false);
        }

        // Làm cho image có thể nhận raycast
        image.raycastTarget = true;
        image.transform.localScale = Vector2.one;
    }

    // Tìm con của đối tượng với tag nhất định
    private Transform FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child;
            }
        }
        return null;
    }
}
