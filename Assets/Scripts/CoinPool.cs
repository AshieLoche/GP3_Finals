using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPool : MonoBehaviour
{


    public List<GameObject> coins;

    public int spawnNum;
    public Vector2 randomX;
    public Vector2 randomZ;
    //public GameObject coinParent;

    public LayerMask mask;
    public void SpawnCoins()
    {
        for (int i = 0; i < spawnNum;)
        {
            float x = Random.Range(randomX.x, randomX.y);
            float z = Random.Range(randomZ.x, randomZ.y);

            Vector3 raycastRandomPos = new Vector3(x, 10, z);
            Ray ray = new Ray(raycastRandomPos, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, 2);
                if (colliders.Length == 1)
                {
                    Vector3 newPos = new Vector3(hit.point.x, 1, hit.point.z);
                    int randomCoin = Random.Range(0, coins.Count);
                    Instantiate(coins[randomCoin], newPos, Quaternion.identity, transform);
                    i++;
                }
            }
        }
    }
}
