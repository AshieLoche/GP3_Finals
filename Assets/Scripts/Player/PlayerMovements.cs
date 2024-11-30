using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public bool isInteractable;
    public bool isWin;
    public GameObject interactable;

    public List<GameObject> coins;

    public int spawnNum;
    public int points;
    public int coinsCollected;
    public int chestOpened;
    public Vector2 randomX;
    public Vector2 randomZ;
    public GameObject coinParent;

    public LayerMask mask;

    public TextMeshProUGUI scorePointsText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI chestText;
    public GameObject winPanel;

    private void Start()
    {
        SpawnCoins();
    }

    private void Update()
    {
        if (!isWin)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, 0, z);

            rb.linearvelocity = move * speed;
        }

        if (isInteractable) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (interactable.TryGetComponent<Chest>(out Chest chest)) 
                {
                    chest.Interacted();
                    chestOpened++;
                    chestText.text = "Chest: " + chestOpened;
                }
                else if (interactable.TryGetComponent<Door>(out Door door))
                {
                    door.Interacted();
                }

                isInteractable = false;
                interactable = null;
            }
        }
    }

    public void SpawnCoins() 
    {
        for (int i = 0; i < spawnNum; ) 
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
                    Instantiate(coins[randomCoin], newPos, Quaternion.identity, coinParent.transform);
                    i++;
                }
            }
        }
    }

    public void Collected(int pointsCollected) 
    {
        points += pointsCollected;
        coinsCollected++;

        if (coinsCollected == spawnNum + 12) 
        {
            isWin = true;
            winPanel.SetActive(true);
        }

        scorePointsText.text = "Score: " + points;
        coinsText.text = "Coins: " + coinsCollected;
    }
}
