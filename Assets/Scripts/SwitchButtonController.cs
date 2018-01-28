using UnityEngine;

public class SwitchButtonController : MonoBehaviour {

    private IntersectionController intersectionController;

    public AudioClip switch_sound;

	public void ToggleIntersection()
    {
    	GetComponent<AudioSource>().clip = switch_sound;
    	GetComponent<AudioSource>().Play();
    	
        intersectionController.ToggleTarget();
    }

    public void SetIntersectionController(IntersectionController cont)
    {
        intersectionController = cont;
    }
}
