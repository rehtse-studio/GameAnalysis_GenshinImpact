using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RehtseStudio.MonoSingleton;
using RehtseStudio.InGameInputsManager;

namespace RehtseStudio.PlayerAnimatorController
{

    public class RS_PlayerAnimatorController : RS_MonoSingleton<RS_PlayerAnimatorController>
    {

        private Animator _anim;
        private int _speedFloatParameterAnim;
        private int _isPlayerAttackingBoolParameterAnim;
        private int _attackTriggerParameterAnim;

        private bool _isPlayerAttacking = false;
        private int _attackClick = 0;
        private float _lastTimeAttackClick = 0;
        private float _comboDelay = 1;

        private void OnEnable()
        {

            _anim = GetComponent<Animator>();
            AnimationsId();

        }
        private void AnimationsId()
        {
            _speedFloatParameterAnim = Animator.StringToHash("Speed");
            _isPlayerAttackingBoolParameterAnim = Animator.StringToHash("isPlayerAttacking");
            _attackTriggerParameterAnim = Animator.StringToHash("Attack_001");
        }

        public void Running(float _speed)
        {
            _anim.SetFloat(_speedFloatParameterAnim, _speed);
        }
        public void Attacking()
        {

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

