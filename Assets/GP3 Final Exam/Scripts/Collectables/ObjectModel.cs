using UnityEngine;

public class ObjectModel : MonoBehaviour
{
    [SerializeField] private int _points;
    public int Points { get { return _points; } }
}