using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AchievemntsCountView : MonoBehaviour
{
    [SerializeField] private AchievemntsCount _count;
    [SerializeField] private Image _allCompletedImage;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = _count.CompletedCount + "/" + _count.AllCount;
        if (_count.CompletedCount == _count.AllCount)
            _allCompletedImage.enabled = true;
    }
}
