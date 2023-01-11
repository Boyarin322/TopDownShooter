using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _speed = 7;

    private Rigidbody2D _playerRb;

    private Vector2 _moveDirection;
    private Vector2 _lookDirection;
    private Vector2 _mousePosition;
    

    private void Awake()
    {
        _playerRb= GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        _moveDirection.x = Input.GetAxisRaw("Horizontal");
        _moveDirection.y = Input.GetAxisRaw("Vertical");
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        _playerRb.MovePosition(_playerRb.position + _moveDirection * Time.fixedDeltaTime * _speed);
        _lookDirection = _mousePosition - _playerRb.position;
        _playerRb.rotation = Mathf.Atan2(_lookDirection.y, _lookDirection.x)* Mathf.Rad2Deg - 90;
    }
}
