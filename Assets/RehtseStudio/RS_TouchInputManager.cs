using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Calling the namespaces for the scripts to use
using RehtseStudio.MonoSingleton;
using RehtseStudio.InGameInputsManager;
using UnityEngine.EventSystems;

namespace RehtseStudio.TouchInputManager
{
    public class RS_TouchInputManager : RS_MonoSingleton<RS_TouchInputManager>, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        [HideInInspector] public Vector2 _rsTouchInputVector;
        private Touch _rsMyTouch;
        private bool _isPlayerPressingTheArea = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            if (_isPlayerPressingTheArea == true)
            {

                if (Input.touchCount > 0)
                {
                                       
                    for (int i = 0; i < Input.touchCount; i++)
                    {

                        _rsMyTouch = Input.GetTouch(i);
                        
                        if (_rsMyTouch.position.x > Screen.width / 2)
                        {

                            switch (_rsMyTouch.phase)
                            {

                                case UnityEngine.TouchPhase.Began:
                                    break;
                                case UnityEngine.TouchPhase.Moved:
                                    _rsTouchInputVector = new Vector2(_rsTouchInputVector.normalized.x, _rsTouchInputVector.normalized.y);
                                    break;
                                case UnityEngine.TouchPhase.Stationary:
                                    _rsTouchInputVector = new Vector2();
                                    break;
                                case UnityEngine.TouchPhase.Ended:
                                    break;
                                case UnityEngine.TouchPhase.Canceled:
                                    break;
                                default:
                                    break;

                            }

                        }
                        
                    }
                    
                }

            }
            else
            {

                _rsTouchInputVector = new Vector2();
                _rsTouchInputVector = new Vector2(RS_InGameInputsManager.Instance.LookAction().x, RS_InGameInputsManager.Instance.LookAction().y);

            }

        }

        public void OnPointerDown(PointerEventData dataOnPointerDown)
        {
            _isPlayerPressingTheArea = true;
        }

        public void OnPointerUp(PointerEventData dataOnPointerUp)
        {
            _isPlayerPressingTheArea = false;
        }

        public void OnBeginDrag(PointerEventData dataOnBeginDrag)
        {
            
        }

        public void OnDrag(PointerEventData dataOnDrag)
        {

            _rsTouchInputVector = dataOnDrag.delta;
            

        }

        public void OnEndDrag(PointerEventData dataOnEndDrag)
        {
            _isPlayerPressingTheArea = false;
            _rsTouchInputVector = new Vector2();
        }

        

        

    }

}

