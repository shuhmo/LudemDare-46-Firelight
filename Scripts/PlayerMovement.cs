using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    InputController _inputController;
    WorldGrid worldGrid;
    bool _isMoving = false;
    Vector2 _lookDir;
    Player _player;
    [SerializeField]
    bool _isPlayerMovementLocked;

    [SerializeField]
    float _movementSpeed;

    [SerializeField]
    Animator _playerAnimator;

    Vector2 _lastMoveDir;


    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        worldGrid = FindObjectOfType<WorldGrid>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _inputController = FindObjectOfType<InputController>();
    }
    private void Start()
    {
        _inputController.OnThridInteractionPressed += PlayerThirdInteract;
        _inputController.OnInteractionPressed += PlayerInteract;
        _inputController.OnUpKeyPressed += PlayerMoveUp;
        _inputController.OnDownKeyPressed += PlayerMoveDown;
        _inputController.OnLeftKeyPressed += PlayerMoveLeft;
        _inputController.OnRightKeyPressed += PlayerMoveRight;
        _inputController.OnSecondaryInteractionPressed += PlayerSecondaryInteract;

    }

    public void setPlayerMovementLocked(bool isLocked) {
        _isPlayerMovementLocked = isLocked;
    }
    public bool getPlayerMovementLocked() {
        return _isPlayerMovementLocked;
    }
    public void PlayerInteract() {
        Vector2 targetPoint = worldGrid.WorldPointToGridPoint(transform.position.x, transform.position.y) + _lookDir;
        Debug.Log("target int point :" + targetPoint);
        GridObject gridObject = worldGrid.GetWorldGridPoint((int)targetPoint.x, (int)targetPoint.y);

        if (gridObject != null)
        {
            gridObject.OnGridObjectInteract(_player);
        }
    }
    public void PlayerSecondaryInteract() {

        Vector2 targetPoint = worldGrid.WorldPointToGridPoint(transform.position.x, transform.position.y) + _lookDir;
        Debug.Log("target int point :" + targetPoint);
        GridObject gridObject = worldGrid.GetWorldGridPoint((int)targetPoint.x, (int)targetPoint.y);

        if (gridObject != null)
        {
            gridObject.OnSecondaryGridObjectInteract(_player);
        }
    }
    public void PlayerThirdInteract() {
        Vector2 targetPoint = worldGrid.WorldPointToGridPoint(transform.position.x, transform.position.y) + _lookDir;
        Debug.Log("target int point :" + targetPoint);
        GridObject gridObject = worldGrid.GetWorldGridPoint((int)targetPoint.x, (int)targetPoint.y);

        if (gridObject != null)
        {
            gridObject.OnThridGridObjectInteract(_player);
        }
    }
    public void PlayerMoveUp() {
        _lookDir = new Vector2(0, 1);
        


        //Debug.Log("Up Pressed!");
    }
    public void PlayerMoveDown() {
        _lookDir = new Vector2(0, -1);
        


        //Debug.Log("Down Pressed!");
    }
    public void PlayerMoveRight() {
        _lookDir = new Vector2(1, 0);
        


        //Debug.Log("Right Pressed!");
    }
    public void PlayerMoveLeft() {
        _lookDir = new Vector2(-1, 0);
        


        //Debug.Log("Left Pressed!");
    }

    private void FixedUpdate()
    {
        //Debug.Log("LookDir : " + _lookDir);
        //print("grid point: " + worldGrid.WorldPointToGridPoint(transform.position.x, transform.position.y));
        //Debug.Log("inputsPressed:" + _inputController.movementKeysPressed());
        if (!_isPlayerMovementLocked)
        {
            Vector2 inputVector = _inputController.getInputVector();
            _rigidBody.velocity = inputVector * _movementSpeed * Time.deltaTime;

            //Debug.Log("input Vector: " + inputVector);

            if (inputVector == Vector2.up && _lastMoveDir != Vector2.up)
            {
                _lastMoveDir = Vector2.up;
                _playerAnimator.SetInteger("yDir", 1);
                _playerAnimator.SetInteger("xDir", 0);
            }
            else if (inputVector == Vector2.down && _lastMoveDir != Vector2.down)
            {
                _lastMoveDir = Vector2.down;
                _playerAnimator.SetInteger("yDir", -1);
                _playerAnimator.SetInteger("xDir", 0);

            }
            else if (inputVector == Vector2.left && _lastMoveDir != Vector2.left)
            {
                _lastMoveDir = Vector2.left;
                _playerAnimator.SetInteger("xDir", -1);
                _playerAnimator.SetInteger("yDir", 0);

            }
            else if (inputVector == Vector2.right && _lastMoveDir != Vector2.right)
            {
                _lastMoveDir = Vector2.right;
                _playerAnimator.SetInteger("xDir", +1);
                _playerAnimator.SetInteger("yDir", 0);

            }
            else if (inputVector == Vector2.zero && _lastMoveDir != Vector2.zero)
            {
                _lastMoveDir = Vector2.zero;
                _playerAnimator.SetInteger("xDir", 0);
                _playerAnimator.SetInteger("yDir", 0);
            }
            else if (inputVector == new Vector2(1, 1))
            {
                _lastMoveDir = Vector2.zero;
                _playerAnimator.SetInteger("xDir", 1);
                _playerAnimator.SetInteger("yDir", 0);
            }
            else if (inputVector == new Vector2(-1, 1))
            {
                _lastMoveDir = Vector2.zero;
                _playerAnimator.SetInteger("xDir", -1);
                _playerAnimator.SetInteger("yDir", 0);
            }
            else if (inputVector == new Vector2(1, -1))
            {
                _lastMoveDir = Vector2.zero;
                _playerAnimator.SetInteger("xDir", 1);
                _playerAnimator.SetInteger("yDir", 0);
            }
            else if (inputVector == new Vector2(-1, -1))
            {
                _lastMoveDir = Vector2.zero;
                _playerAnimator.SetInteger("xDir", -1);
                _playerAnimator.SetInteger("yDir", 0);
            }
        }
    }
}
