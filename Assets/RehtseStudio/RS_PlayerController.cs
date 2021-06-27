using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RehtseStudio.InGameInputsManager;
using RehtseStudio.MonoSingleton;
namespace RehtseStudio.PlayerController
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]

    public class RS_PlayerController : RS_MonoSingleton<RS_PlayerController>
    {

        private Animator _anim;
        private int _speedFloatParameterAnim;
        private int _isPlayerAttackingBoolParameterAnim;
        private int _attackTriggerParameterAnim;

        private bool _isPlayerAttacking = false;
        private int _attackClick = 0;
        private float _lastTimeAttackClick = 0;
        private float _comboDelay = 1;

        private Vector2 _playerInputs;
        private float _xInput;
        private float _yInput;
        private float _speed;

        private Rigidbody _rb;
        private Vector3 _movement;
        private Vector3 _moveDirection;
        [SerializeField] private float _movementSpeed;

        private Camera _mainCamera;
        private float targetAngle;
        private float turnSmoothVelocity;

        private void OnEnable()
        {

            _anim = GetComponent<Animator>();
            _speedFloatParameterAnim = Animator.StringToHash("Speed");
            _isPlayerAttackingBoolParameterAnim = Animator.StringToHash("isPlayerAttacking");
            _attackTriggerParameterAnim = Animator.StringToHash("Attack_001");

            _rb = GetComponent<Rigidbody>();

            _mainCamera = Camera.main;

        }

        private void Update()
        {
            Debug.Log("Movement W Speed :: " + (_speed/_movementSpeed));
            MovePlayer();

            if (Time.time - _lastTimeAttackClick > _comboDelay)
            {
                _attackClick = 0;
                _isPlayerAttacking = false;
                _anim.SetBool(_isPlayerAttackingBoolParameterAnim, _isPlayerAttacking);
               
            }

            if (RS_InGameInputsManager.Instance.AttackAction())
            {
                Attack();
            }

        }
      
        private void MovePlayer()
        {

            _xInput = RS_InGameInputsManager.Instance.MoveAction().x;
            _yInput = RS_InGameInputsManager.Instance.MoveAction().y;
            _movement = new Vector3(_xInput, 0, _yInput);
            _speed = Mathf.Abs(_xInput) + Mathf.Abs(_yInput);

            if (_speed > 0 && _isPlayerAttacking == false)
            {

                targetAngle = Mathf.Atan2(_movement.x, _movement.z) * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                _moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _rb.velocity = _moveDirection * _movementSpeed;

            }
            else
            {

                _rb.velocity = new Vector3();

            }

            _anim.SetFloat(_speedFloatParameterAnim, _speed);

        }

        public void Attack()
        {

            _lastTimeAttackClick = Time.time;
            _attackClick++;
            _isPlayerAttacking = true;
            if (_attackClick == 1)
            {
                _anim.SetTrigger(_attackTriggerParameterAnim);
                _anim.SetBool(_isPlayerAttackingBoolParameterAnim, _isPlayerAttacking);

            }

            _attackClick = Mathf.Clamp(_attackClick, 0, 3);
                
        }

        public int AttackClick()
        {
            return _attackClick;
        }

        public bool IsPlayerAttacking()
        {
            return _isPlayerAttacking;
        }

    }

}

