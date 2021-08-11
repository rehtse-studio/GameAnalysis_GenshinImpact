using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Namespace to use
using Cinemachine;
using RehtseStudio.TouchInputManager;
using RehtseStudio.InGameInputsManager;
using RehtseStudio.MobileInputUIManager;

namespace RehtseStudio.CinemachineInputManager
{
    public class RS_CinemachineInputManager : MonoBehaviour
    {

        [SerializeField] private GameObject _rsMobileInputUICanvas;

        [SerializeField] private float _touchSensitivityX = 10f;
        [SerializeField] private float _touchSensitivityY = 10f;

        private string TouchXInputMapTo = "Mouse X";
        private string TouchYInputMapTo = "Mouse Y";

        private void OnEnable()
        {

            RS_MobileInputUIManager.onGetChangeTouchSensitivityX_Value += TouchSensitivityXValue;
            RS_MobileInputUIManager.onGetChangeTouchSensitivityY_Value += TouchSensitivityYValue;
            
        }

        void Start()
        {

            CinemachineCore.GetInputAxis = GetInputAxis;
            
        }

        private float GetInputAxis(string axisName)
        {

            if(_rsMobileInputUICanvas.activeInHierarchy == false)
            {

                if (axisName == TouchXInputMapTo)
                    return RS_InGameInputsManager.Instance.LookAction().x / _touchSensitivityX;
                if (axisName == TouchYInputMapTo)
                    return RS_InGameInputsManager.Instance.LookAction().y / _touchSensitivityY;

            }
            else if(_rsMobileInputUICanvas.activeInHierarchy == true)
            {

                if (axisName == TouchXInputMapTo)
                    return RS_TouchInputManager.Instance._rsTouchInputVector.x / _touchSensitivityX;
                if (axisName == TouchYInputMapTo)
                    return RS_TouchInputManager.Instance._rsTouchInputVector.y / _touchSensitivityY;

            }        

            return Input.GetAxis(axisName);

        }

        private void TouchSensitivityXValue(float xValue)
        {
            _touchSensitivityX = xValue;
        }

        private void TouchSensitivityYValue(float yValue)
        {
            _touchSensitivityY = yValue;
        }

        private void OnDisable()
        {
            RS_MobileInputUIManager.onGetChangeTouchSensitivityX_Value -= TouchSensitivityXValue;
            RS_MobileInputUIManager.onGetChangeTouchSensitivityY_Value -= TouchSensitivityYValue;
        }

    }

}


