using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class TimerFillAmountView : MonoBehaviour
{
    private Timer _timer;
    private Image _image;

    [Inject]
    private void Construct(Timer timer)
    {
        _timer = timer;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.type = Image.Type.Filled;
    }

    private void FixedUpdate()
    {
        SetFillAmount(_timer.GetPercent());
    }

    private void SetFillAmount(float percent)
    {
        if (percent < 0 || percent > 100)
            return;

        // перевод процентов в 1 и не вид 0 до 1 а вид 1 до 0
        _image.fillAmount = 1 - (percent / 100);
    }
}
