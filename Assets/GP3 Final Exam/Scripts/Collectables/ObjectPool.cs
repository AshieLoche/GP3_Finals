using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _objPrefab;
    [SerializeField] private Transform _objParent;
    [SerializeField] private Transform _objReserveParent;
    [SerializeField] private Vector2 _randomX;
    [SerializeField] private Vector2 _randomZ;

    [SerializeField] private LayerMask _mask;

    private readonly List<GameObject> _objPool = new();
    private readonly List<GameObject> _objPoolReserve = new();
    private GameObject _objClone;

    protected abstract void Awake();

    public void SetObjects(int poolAmount)
    {
        for (int i = 1; i <= poolAmount;)
        {
            float x = Random.Range(_randomX.x, _randomX.y);
            float z = Random.Range(_randomZ.x, _randomZ.y);

            Vector3 raycastRandomPos = new Vector3(x, 10, z);
            Ray ray = new Ray(raycastRandomPos, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _mask))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, 2);

                bool validPosition = !colliders.Any(collider => !collider.CompareTag("Platform"));

                if (validPosition)
                {
                    Vector3 newPos = new Vector3(hit.point.x, 1, hit.point.z);
                    SpawnObject(newPos, _objParent, $"{_objPrefab.name} {i}");
                    i++;
                }
            }
        }
    }

    public void SetReserveObjects(int poolReserveAmount)
    {
        for (int i = 1; i < poolReserveAmount; i++)
        {
            SpawnObject(Vector3.zero, _objReserveParent, $"{_objPrefab.name} Reserve {i}");
        }
    }

    private void SpawnObject(Vector3 pos, Transform parent, string objName)
    {
        _objClone = Instantiate(_objPrefab, pos, Quaternion.identity, parent);
        _objClone.SetActive(false);
        _objClone.name = objName;
        if (objName.Contains("Reserve"))
        {
            _objPoolReserve.Add(_objClone);
        }
        else
        {
            _objPool.Add(_objClone);
        }
    }

    public GameObject GetObject()
    {
        return _objPool.FirstOrDefault(obj => !obj.activeInHierarchy);
    }

    public GameObject GetReserveObject()
    {
        return _objPoolReserve.FirstOrDefault(obj => !obj.activeInHierarchy);
    }
}