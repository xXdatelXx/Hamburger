using UnityEngine;
using UnityEngine.UI;

public class HamburgerControllerImage : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _hideImage;

    public void Set(Sprite sprite)
    {
        _hideImage.enabled = false;
        _image.sprite = sprite;
    }

    public void Hide()
    {
        _hideImage.enabled = true;
    }
}
