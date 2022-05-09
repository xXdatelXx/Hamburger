using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class ResultView : MonoBehaviour
{
    [SerializeField] private UnityEvent _onNewRecord;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void View()
    {
        _text.text = GetResult().ToString();

        if (NewRecord())
            _onNewRecord.Invoke();
    }

    protected abstract float GetResult();
    protected abstract bool NewRecord();
}
