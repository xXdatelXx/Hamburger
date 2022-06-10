using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _minLoadTime;
    private AsyncOperation _scene;
    private int _sceneCount => SceneManager.sceneCountInBuildSettings;
    public int CurentSceneId => SceneManager.GetActiveScene().buildIndex;
    public event Action OnLoad;

    public void AsyncLoad(int sceneId)
    {
        if (IdValidity(sceneId))
        {
            _scene = SceneManager.LoadSceneAsync(sceneId);
            _scene.allowSceneActivation = false;
            OnLoad?.Invoke();
            StartCoroutine(Switch());
        }
    }

    private IEnumerator Switch()
    {
        yield return new WaitForSeconds(_minLoadTime);
        _scene.allowSceneActivation = true;
    }

    public bool IdValidity(int sceneId)
    {
        return sceneId >= 0 && sceneId < _sceneCount;
    }
}
