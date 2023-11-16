using Entities.Player;
using UnityEngine;

public class LateralMovement
{
    #region Attribute declaration

    //Animation objects
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    //Stats objects
    private readonly PlayerLateralMovement _lateralMovementStats;

    //Controller objects
    private VectorController _vectorController;

    //Variables 
    private float _currentSpeed;
    private Directions _currentDirection;
    private bool _movementLocked;

    #endregion

    public LateralMovement(
        Animator animator,
        SpriteRenderer spriteRenderer,
        PlayerLateralMovement lateralMovementStats,
        VectorController vectorController
    )
    {
        this._animator = animator;
        this._spriteRenderer = spriteRenderer;
        this._lateralMovementStats = lateralMovementStats;
        this._vectorController = vectorController;
        this._movementLocked = false;
    }


    private void _moveRight()
    {
        this._currentDirection = Directions.Right;
        this._moveRoutine();
    }

    private void _moveLeft()
    {
        this._currentDirection = Directions.Left;
        this._moveRoutine();
    }

    private void _moveRoutine()
    {
        if (!this._movementLocked)
        {
            this._accelerate();
        }

        this._changeSpriteDirection();
    }

    private void _accelerate()
    {
        if (this._currentSpeed < this._lateralMovementStats.playerMaxSpeed)
        {
            this._currentSpeed += this._lateralMovementStats.playerAcceleration;
        }
        else
        {
            this._currentSpeed = this._lateralMovementStats.playerMaxSpeed;
        }

        this._applyNewSpeed();
    }

    private void _decelerate()
    {
        if (this._currentSpeed > 0)
        {
            this._currentSpeed -= this._lateralMovementStats.playerDeceleration;
        }
        else
        {
            this._currentSpeed = 0;
        }

        this._applyNewSpeed();
    }

    private void _applyNewSpeed()
    {
        switch (this._currentDirection)
        {
            case Directions.Right:
                this._vectorController.ChangeSpeedVectorX(this._currentSpeed);
                break;
            case Directions.Left:
                this._vectorController.ChangeSpeedVectorX(-this._currentSpeed);
                break;
        }

        this._changeAnimation();
    }

    private void _changeAnimation()
    {
        if (this._currentSpeed > 0)
        {
            this._animator.SetBool("isRunning", true);
        }
        else
        {
            this._animator.SetBool("isRunning", false);
        }
    }

    private void _changeSpriteDirection()
    {
        switch (this._currentDirection)
        {
            case Directions.Right:
                this._spriteRenderer.flipX = false;
                break;
            case Directions.Left:
                this._spriteRenderer.flipX = true;
                break;
        }
    }

    public void BlockMovement()
    {
        this._movementLocked = true;
        this._currentSpeed = 0;
        this._applyNewSpeed();
    }

    public void AllowMovement()
    {
        this._movementLocked = false;
    }

    public void UpdateActions()
    {
        bool movedLateral = false;

        if (Input.GetKey(key: KeyCode.D))
        {
            this._moveRight();
            movedLateral = true;
        }

        if (Input.GetKey(key: KeyCode.A))
        {
            this._moveLeft();
            movedLateral = true;
        }

        if (!movedLateral)
        {
            this._decelerate();
        }
    }
}