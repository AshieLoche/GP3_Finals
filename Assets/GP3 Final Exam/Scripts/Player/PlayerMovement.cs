using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rb;
    private Vector3 _move;
    private float _x, _y;
    private bool _isWin;

    private void Awake()
    {
        Scoreboard.OnWinEvent.AddListener(HandleWin);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_isWin)
        {
            _x = Input.GetAxis("Horizontal");
            _y = Input.GetAxis("Vertical");

            _move = new Vector3(_x, 0, _y);

            _rb.velocity = _move * _speed;
        }
    }

    private void HandleWin()
    {
        _isWin = true;
    }
}
