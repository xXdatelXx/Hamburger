using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HamburgerControllerImage : MonoBehaviour
{
    [SerializeField] private UnityEvent _hide;
    [SerializeField] private UnityEvent _impose;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Set(Sprite sprite)
    {
        _image.sprite = sprite;
        _impose.Invoke();
    }

    public void Hide()
    {
        _hide.Invoke();
    }
}
