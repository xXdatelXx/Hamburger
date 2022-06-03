using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AchievementImage : MonoBehaviour
{
    [SerializeField] private Sprite _achieveSprite;
    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Achieve()
    {
        _image.sprite = _achieveSprite;
    }
}
