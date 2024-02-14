using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string Tag;
    
    void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag(Tag);

        if (objs.Length > 1)
        {
            // foreach (var obj in objs)
            // {
            //     Destroy(obj);
            // }
            
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}