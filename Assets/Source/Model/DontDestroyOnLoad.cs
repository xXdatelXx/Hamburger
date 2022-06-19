using UnityEngine;
using System.Linq;

public class DontDestroyOnLoad : MonoBehaviour
{
    [field: SerializeField] public int Id { get; private set; }

    private void Awake()
    {
        transform.parent = null;

        if (FindObjectsOfType<DontDestroyOnLoad>().Where(obj => obj.Id == Id).Count() > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
