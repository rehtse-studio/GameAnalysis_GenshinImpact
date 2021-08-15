using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RehtseStudio.InGameInputsManager;
using RehtseStudio.MonoSingleton;
using RehtseStudio.PlayerAnimatorController;

namespace RehtseStudio.PlayerController
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]

    public class RS_PlayerController : RS_MonoSingleton<RS_PlayerController>
    {

        private Vector2 _playerInputs;
        private float _xInput;
        private float _yInput;
        private float _speed;

        private RS_PlayerAnimatorController _playerAnimatorController;
        private Rigidbody _rb;
        private Vector3 _movement;
        private Vector3 _moveDirection;
        [SerializeField] private float _movementSpeed = 0;

        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _ground;
        [SerializeField] private RaycastHit _raycastHit;
        [SerializeField] private bool _isPlayerGrounded;
        private CapsuleCollider _cap;

        private Camera _mainCamera;
        private float targetAngle;
        private float turnSmoothVelocity;

        private void OnEnable()
        {

            _playerAnimatorController = GetComponent<RS_PlayerAnimatorController>();

            _rb = GetComponent<Rigidbody>();

            _mainCamera = Camera.main;

        }
        
        private void Update()
        {

            _isPlayerGrounded = Physics.CheckSphere(_ground.position, 0.28f, _groundLayer, QueryTriggerInteraction.Ignore);

            _xInput = RS_InGameInputsManager.Instance.MoveAction().x;
            _yInput = RS_InGameInputsManager.Instance.MoveAction().y;

            _movement = new Vector3(_xInput, 0, _yInput);
            _movement.y = _rb.velocity.y;
            _speed = Mathf.Abs(_xInput) + Mathf.Abs(_yInput);

            MovePlayer();
            Attack();
            
        }
      
        private void MovePlayer()
        {
            
            _movementSpeed = _speed > 0.7 ? 6 : 3;

            if (_speed > 0 && _playerAnimatorController.IsPlayerAttacking() == false)
            {

                targetAngle = Mathf.Atan2(_movement.x, _movement.z) * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                _moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _moveDirection *= _movementSpeed;
                _moveDirection.y = _movement.y;
                _rb.velocity = _moveDirection;
              
            }
            else
            {

                _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
               
            }

            if(_isPlayerGrounded == false)
            {
                Jump(true);
                
            }
            else
            {
                Jump(false);
                _playerAnimatorController.Running(_speed);
            }
            

        }

        private void Attack()
        {

            _playerAnimatorController.Attacking();

        }

        private void Jump(bool _jumpingState)
        {
            _playerAnimatorController.Jump(_jumpingState);
        }


        //Debuging Section
        void OnDrawGizmosSelected()
        {
            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (_isPlayerGrounded) Gizmos.color = transparentGreen;
            else Gizmos.color = transparentRed;

            Gizmos.DrawSphere(_ground.position, 0.28f);

        }

    }

}

