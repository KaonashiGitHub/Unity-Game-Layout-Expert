using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    // Reference to the Choosed Item
    public Transform choosedItem1;

    // Reference to the Image object
    public GameObject imageObject;

    void Start()
    {
        // Đảm bảo imageObject đã được gán trong Inspector
        if (imageObject == null)
        {
            imageObject = this.transform.Find("Image").gameObject;
        }
    }

    // This function should be called when the Button is clicked
    public void OnButtonClick()
    {
        ReplaceImageInChoosed();
    }

    void ReplaceImageInChoosed()
    {
        // Xóa bỏ image cũ nếu có
        foreach (Transform child in choosedItem1)
        {
            Destroy(child.gameObject);
        }

        // Clone the Image object and add it to Item 1 in Choosed
        GameObject newImage = Instantiate(imageObject);
        newImage.transform.SetParent(choosedItem1, false); // Set the parent and keep local scale

        // Ensure the new image matches the original in terms of position and scale
        RectTransform rt = newImage.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rt.sizeDelta = imageObject.GetComponent<RectTransform>().sizeDelta;
        rt.localScale = imageObject.GetComponent<RectTransform>().localScale;
    }
}
