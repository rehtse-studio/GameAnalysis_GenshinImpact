using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Calling the necesary namespace to have acces to the RS_MonoSingleton Script and to the Input Action Map
using RehtseStudio.MonoSingleton;
using RehtseStudio.InGameInputActionsMap;
using UnityEngine.InputSystem;

namespace RehtseStudio.InGameInputsManager
{
    public class RS_InGameInputsManager : RS_MonoSingleton<RS_InGameInputsManager>
    {

        //Calling Your Input Actions Map
        private RehtseStudio_InGameInputActionsMap _inGameInputActionsMap;

        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _interactionAction;
        private InputAction _attackAction;

        private void OnEnable()
        {
            _inGameInputActionsMap = new RehtseStudio_InGameInputActionsMap();
            _inGameInputActionsMap.Enable();

            _moveAction = _inGameInputActionsMap.Player.Move;
            _moveAction.Enable();

            _lookAction = _inGameInputActionsMap.Player.Look;
            _lookAction.Enable();

            _interactionAction = _inGameInputActionsMap.Player.ActionInteraction;
            _interactionAction.Enable();

            _attackAction = _inGameInputActionsMap.Player.FireAttack;
            _attackAction.Enable();
        }
       
        public Vector2 MoveAction()
        {
            return _moveAction.ReadValue<Vector2>();
        }

        public Vector2 LookAction()
        {
            return _lookAction.ReadValue<Vector2>();
        }

        public bool InteractionAction()
        {
            return _interactionAction.triggered;
        }

        public bool AttackAction()
        {

            return _attackAction.WasPerformedThisFrame();

        }

        private void OnDisable()
        {

            _inGameInputActionsMap.Disable();
            _moveAction.Disable();
            _lookAction.Disable();
            _interactionAction.Disable();
            _attackAction.Disable();

        }
    }

}

