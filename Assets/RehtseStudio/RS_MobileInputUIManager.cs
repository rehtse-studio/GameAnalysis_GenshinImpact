using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Namespace To Use
using System;
using UnityEngine.UI;
using RehtseStudio.CinemachineInputManager;

namespace RehtseStudio.MobileInputUIManager
{
    public class RS_MobileInputUIManager : MonoBehaviour
    {

        public static Action<float> onGetChangeTouchSensitivityX_Value;
        public static Action<float> onGetChangeTouchSensitivityY_Value;

        private void OnEnable()
        {
            
        }
        public void ChangeTouchSensitivityXValue(float xValue)
        {
            
            if (onGetChangeTouchSensitivityX_Value != null)
                onGetChangeTouchSensitivityX_Value(xValue);

        }

        public void ChangeTouchSensitivityYValue(float yValue)
        {

            if (onGetChangeTouchSensitivityY_Value != null)
                onGetChangeTouchSensitivityY_Value(yValue);

        }

        public void CloseApplication()
        {
            Application.Quit();
        }
    }

}

