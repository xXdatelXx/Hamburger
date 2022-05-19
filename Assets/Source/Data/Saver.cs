using UnityEngine;
using System.IO;
using System;

public class Saver<T> where T : SerializableClass
{
    private const string Folder = "/Data/Statistics";
    private readonly string _path;

    public Saver(string fileName, T defaultValue)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, fileName + ".json");
#else
        _path = Path.Combine(Application.dataPath + Folder, fileName + ".json");
#endif
        if (!File.Exists(_path))
            Save(defaultValue);
    }

    public void Save(T value)
    {
        File.WriteAllText(_path, JsonUtility.ToJson(value, true));
    }

    public T Load()
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(_path));
    }
}

[Serializable]
public abstract class SerializableClass
{
}
