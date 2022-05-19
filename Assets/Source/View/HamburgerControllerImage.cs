using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HamburgerControllerImage : MonoBehaviour
{
    [SerializeField] private Sprite _hideSprite;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Set(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void Hide()
    {
        _image.sprite = _hideSprite;
    }
}
