using UnityEngine;
using UnityEngine.InputSystem;
public class ActivateOnKeypress : MonoBehaviour
{
    public KeyCode ActivationKey = KeyCode.LeftControl;
    public int PriorityBoostAmount = 10;
    public GameObject Reticle;

    Cinemachine.CinemachineVirtualCameraBase vcam;
    bool boosted = false;

    void Start()
    {
        vcam = GetComponent<Cinemachine.CinemachineVirtualCameraBase>();
    }

    void Update()
    {
        if (vcam != null)
        {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                if (!boosted)
                {
                    vcam.Priority += PriorityBoostAmount;
                    boosted = true;
                }
            }
            else if (boosted)
            {
                vcam.Priority -= PriorityBoostAmount;
                boosted = false;
            }
        }
        if (Reticle != null)
            Reticle.SetActive(boosted);
    }
}
