using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class ResultView : MonoBehaviour
{
    [SerializeField] private UnityEvent _onNewRecord;
    [SerializeField] private bool _awakeView;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();

        if (_awakeView)
            View();
    }

    public void View()
    {
        _text.text = GetResult().ToString();

        if (NewRecord())
            _onNewRecord.Invoke();
    }

    protected abstract float GetResult();
    protected virtual bool NewRecord()
    {
        return false;
    }
}
