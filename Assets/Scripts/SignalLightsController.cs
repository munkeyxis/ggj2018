using UnityEngine;

public class SignalLightsController : MonoBehaviour {
    public SpriteRenderer[] leftSignalLights;
    public SpriteRenderer[] rightSignalLights;
    public Sprite inactiveLight;
    public Sprite activeLight;

    public void SetLightOn(bool rightLightsOn)
    {
        if (rightLightsOn)
        {
            foreach (SpriteRenderer renderer in rightSignalLights)
            {
                renderer.sprite = activeLight;
            }

            foreach (SpriteRenderer renderer in leftSignalLights)
            {
                renderer.sprite = inactiveLight;
            }
        }
        else
        {
            foreach (SpriteRenderer renderer in rightSignalLights)
            {
                renderer.sprite = inactiveLight;
            }

            foreach (SpriteRenderer renderer in leftSignalLights)
            {
                renderer.sprite = activeLight;
            }
        }
    }
}
