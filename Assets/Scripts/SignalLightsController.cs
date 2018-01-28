using UnityEngine;

public class SignalLightsController : MonoBehaviour {
    public Animator[] leftSignalLights;
    public Animator[] rightSignalLights;
    public Sprite inactiveLight;
    public Sprite activeLight;

    //Animator light_animator;


    public void SetLightOn(bool rightLightsOn)
    {
        if (rightLightsOn)
        {
            foreach (Animator light_animator in rightSignalLights)
            {
                light_animator.SetBool("is_flashing", false);
            }

            foreach (Animator light_animator in leftSignalLights)
            {
                light_animator.SetBool("is_flashing", true);
            }
        }
        else
        {
            foreach (Animator light_animator in rightSignalLights)
            {
                light_animator.SetBool("is_flashing", false);
            }

            foreach (Animator light_animator in leftSignalLights)
            {
                light_animator.SetBool("is_flashing", true);
            }
        }
    }
}
