using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RehtseStudio.InGameInputsManager;
using RehtseStudio.MonoSingleton;
using RehtseStudio.PlayerAttackController;

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

        private RS_PlayerAttackController _playerAttackController;
        private Rigidbody _rb;
        private Vector3 _movement;
        private Vector3 _moveDirection;
        [SerializeField] private float _movementSpeed;

        private Camera _mainCamera;
        private float targetAngle;
        private float turnSmoothVelocity;

        private void OnEnable()
        {

            _playerAttackController = GetComponent<RS_PlayerAttackController>();

            _rb = GetComponent<Rigidbody>();

            _mainCamera = Camera.main;

        }
        
        private void Update()
        {
            
            MovePlayer();
            _playerAttackController.Attacking();
           
        }
      
        private void MovePlayer()
        {

            _xInput = RS_InGameInputsManager.Instance.MoveAction().x;
            _yInput = RS_InGameInputsManager.Instance.MoveAction().y;

            _movement = new Vector3(_xInput, 0, _yInput);
            _movement.y = _rb.velocity.y;
            _speed = Mathf.Abs(_xInput) + Mathf.Abs(_yInput);

            if (_speed > 0 && _playerAttackController.IsPlayerAttacking() == false)
            {

                //targetAngle = Mathf.Atan2(_movement.x, _movement.z) * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;
                //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
                //transform.rotation = Quaternion.Euler(0f, angle, 0f);
                //_moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //_moveDirection = _mainCamera.transform.TransformDirection(_movement);
                //_rb.velocity = _moveDirection;
                //transform.rotation = Quaternion.Euler(0f, _mainCamera.transform.rotation.x, 0f);
                _rb.velocity = _movement * _movementSpeed;
                                                
            }
            else
            {

                _rb.velocity = new Vector3(0,_rb.velocity.y,0);
               
            }

            _playerAttackController.Running(_speed);

        }

    }

}

