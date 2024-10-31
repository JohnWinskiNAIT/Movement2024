using UnityEngine.Events;

static public class MyEvents
{
    static public UnityEvent Deactivate = new();
    static public UnityEvent Activate = new();
    static public UnityEvent<float, float, float> Update = new();

    static public UnityEvent<int> AddScore = new();
}
