using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource cần tắt/mở
    public Sprite muteSprite; // Sprite cho trạng thái mute
    public Sprite unmuteSprite; // Sprite cho trạng thái unmute
    private bool isMuted = false; // Trạng thái âm thanh
    private Image buttonImage; // Hình ảnh của nút

    void Start()
    {
        // Lấy hình ảnh của nút
        buttonImage = GetComponent<Image>();

        // Gán sự kiện click cho nút
        GetComponent<Button>().onClick.AddListener(ToggleAudio);
    }

    // Phương thức tắt/mở âm thanh
    void ToggleAudio()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            audioSource.Pause(); // Tắt âm thanh
            buttonImage.sprite = unmuteSprite; // Đổi hình ảnh thành unmute
        }
        else
        {
            audioSource.Play(); // Mở âm thanh
            buttonImage.sprite = muteSprite; // Đổi hình ảnh thành mute
        }
    }
}
