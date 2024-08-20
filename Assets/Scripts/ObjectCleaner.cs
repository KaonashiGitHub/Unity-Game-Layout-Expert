using UnityEngine;

public class ChildRemover : MonoBehaviour
{
    // Mảng để kéo thả các đối tượng cha trong Inspector
    public GameObject[] parentObjects;

    // Hàm xóa các đối tượng con từ danh sách các đối tượng cha
    public void RemoveChildObjects()
    {
        foreach (GameObject parent in parentObjects)
        {
            // Lấy tất cả các đối tượng con của đối tượng cha hiện tại
            foreach (Transform child in parent.transform)
            {
                // Xóa đối tượng con
                Destroy(child.gameObject);
            }
        }
    }
}