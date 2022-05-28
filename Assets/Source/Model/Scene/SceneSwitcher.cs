using UnityEngine.SceneManagement;
using System;

public class SceneSwitcher
{
    private int _sceneCount => SceneManager.sceneCountInBuildSettings;
    private int _curentSceneId => SceneManager.GetActiveScene().buildIndex;

    public void Switch(int sceneId)
    {
        if (SceneIdvalidity(sceneId))
            SceneManager.LoadScene(sceneId);
    }

    public void Switch(Direction direction)
    {
        int sceneId = direction switch
        {
            Direction.Left => _curentSceneId - 1,
            Direction.Down => _curentSceneId - 1,
            Direction.Right => _curentSceneId + 1,
            Direction.Up => _curentSceneId + 1,
            _ => throw new InvalidOperationException()
        };

        Switch(sceneId);
    }

    private bool SceneIdvalidity(int sceneId)
    {
        return sceneId >= 0 && sceneId < _sceneCount;
    }
}
