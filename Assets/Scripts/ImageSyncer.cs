using UnityEngine;
using UnityEngine.UI;

public class ImageSyncer : MonoBehaviour
{
    // Danh sách các Item trong Choosed
    public Transform[] choosedItems;

    // Đối tượng Content để chứa các item
    public Transform contentObject;

    // Kích thước mong muốn cho hình ảnh
    public Vector2 desiredSize = new Vector2(650, 650);

    // Hàm này sẽ được gọi khi nút bấm được click
    public void SyncImagesToContent()
    {
        if (contentObject == null)
        {
            return;
        }

        // Xóa tất cả đối tượng con hiện có trong contentObject
        foreach (Transform child in contentObject)
        {
            Destroy(child.gameObject);
        }

        // Thêm tất cả các item từ danh sách choosedItems vào contentObject
        foreach (Transform choosedItem in choosedItems)
        {
            // Kiểm tra xem choosedItem có con không
            if (choosedItem.childCount > 0)
            {
                Transform imageInChoosed = choosedItem.GetChild(0);

                // Sao chép Image và gán nó vào contentObject
                GameObject newImage = Instantiate(imageInChoosed.gameObject);
                
                // Đặt newImage làm con của contentObject
                newImage.transform.SetParent(contentObject, false);

                // Đảm bảo newImage khớp với kích thước và vị trí của contentObject
                RectTransform rt = newImage.GetComponent<RectTransform>();
                rt.anchoredPosition = Vector2.zero;
                rt.sizeDelta = desiredSize;
                rt.localScale = Vector3.one;

                // Gắn thêm component DraggableItem vào Image mới
                DraggableItem draggableItem = newImage.GetComponent<DraggableItem>();
                if (draggableItem == null)
                {
                    draggableItem = newImage.AddComponent<DraggableItem>();
                }

                // Gán chính Image component của newImage vào trường Image của DraggableItem
                draggableItem.image = newImage.GetComponent<Image>();
            }
        }
    }
}
