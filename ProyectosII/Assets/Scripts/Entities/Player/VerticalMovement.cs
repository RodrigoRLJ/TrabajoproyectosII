using Entities.Player;
using UnityEngine;

public class VerticalMovement
{
    #region Attribute declaration

    //Animation objects
    private Animator _animator;

    //Stats objects
    private readonly PlayerVerticalMovement _verticalMovementStats;

    //Controller objects
    private VectorController _vectorController;
    private LateralMovement _lateralMovement;

    //Variables
    /**
     * Time this jump has been charged
     */
    private double _timeCharging;

    /**
     * Phase of the jump
     */
    private JumpStates _jumpState;

    /**
     * Amount of jumps the player has left
     */
    private int _jumpsLeft;

    private bool _refreshAnims;

    #endregion

    public VerticalMovement(
        Animator animator,
        PlayerVerticalMovement verticalMovementStats,
        VectorController vectorController,
        LateralMovement lateralMovement
    )
    {
        this._animator = animator;
        this._verticalMovementStats = verticalMovementStats;
        this._vectorController = vectorController;
        this._lateralMovement = lateralMovement;

        this._resetChargeTime();
        this._jumpState = JumpStates.NotJumping;
        this._jumpsLeft = this._verticalMovementStats.jumps;
        this._refreshAnims = false;

        this._susbscribeEvents();
    }

    private void Destroy()
    {
        this._unsusbscribeEvents();
    }

    private void _susbscribeEvents()
    {
        EventSystem.PlayerTouchedGround += this._fallToGround;
    }

    private void _unsusbscribeEvents()
    {
        EventSystem.PlayerTouchedGround -= this._fallToGround;
    }

    private void _fallToGround()
    {
        this._jumpsLeft = this._verticalMovementStats.jumps;
    }

    private void _changeAnimation()
    {
        this._animator.SetInteger("jumpPhase", (int)this._jumpState);
    }

    private void _startJump()
    {
        this._jumpState = JumpStates.StartJump;
        this._changeAnimation();
        this._resetChargeTime();
        this._lateralMovement.BlockMovement();
    }

    private void _resetChargeTime()
    {
        this._timeCharging = 0D;
    }

    private void _chargeJump()
    {
        this._jumpState = JumpStates.ChargeJump;
        this._changeAnimation();
        this._timeCharging += Time.deltaTime;
    }

    private void _releaseJump()
    {
        this._jumpState = JumpStates.ReleaseJump;
        this._changeAnimation();
        this._endJumpAction();
    }

    private void _endJumpAction()
    {
        this._lateralMovement.AllowMovement();
        this._loseJump();
        this._applyJumpForce();
        this._jumpState = JumpStates.NotJumping;
        this._refreshAnims = true;
    }

    private void _loseJump()

    {
        this._jumpsLeft--;
    }

    private void _applyJumpForce()
    {
        this._vectorController.ChangeSpeedVectorY(this._calculateJumpForce());
    }

    private float _calculateJumpForce()
    {
        float jumpForce;

        jumpForce = (float)this._timeCharging * this._verticalMovementStats.jumpChargeSpeed +
                    this._verticalMovementStats.minJumpForce;

        if (jumpForce > this._verticalMovementStats.maxJumpForce)
        {
            jumpForce = this._verticalMovementStats.maxJumpForce;
        }
        else if (jumpForce < this._verticalMovementStats.minJumpForce)
        {
            jumpForce = this._verticalMovementStats.minJumpForce;
        }

        return jumpForce;
    }

    /**
     * Activated when the player presses the jump key
     * Change later on to take into account the time the key is pressed
     */
    private void _jump()
    {
        if (this._jumpsLeft <= 0)
        {
            return;
        }

        switch (this._jumpState)
        {
            case JumpStates.NotJumping:
                this._startJump();
                break;
            case JumpStates.StartJump:
            case JumpStates.ChargeJump:
                this._chargeJump();
                break;
        }
    }

    private void _heavyFall()
    {
        Debug.Log("Do heavyFall");
    }

    public void UpdateActions()
    {
        if (this._refreshAnims)
        {
            this._refreshAnims = false;
            this._changeAnimation();
        }

        bool hasCharged = false;
        if (Input.GetKey(key: KeyCode.W) || Input.GetKeyDown(key: KeyCode.Space))
        {
            this._jump();
            hasCharged = true;
        }

        if (Input.GetKey(key: KeyCode.S))
            this._heavyFall();

        if (!hasCharged && this._jumpState == JumpStates.ChargeJump)
        {
            this._releaseJump();
        }
    }
}