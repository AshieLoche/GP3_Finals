using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    private bool _isWin;

    public float speed;
    public Rigidbody rb;
    public bool isInteractable;
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

    private void Awake()
    {
        Scoreboard.OnWinEvent.AddListener(HandleWin);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_isWin)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, 0, y);

            rb.velocity = move * speed;
        }
    }

    private void HandleWin()
    {
        _isWin = true;
    }
}
