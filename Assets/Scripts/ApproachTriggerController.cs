using UnityEngine;
using UnityEngine.UI;

public class ApproachTriggerController : MonoBehaviour {

    public IntersectionController intersectionController;
    public AudioClip crossing_bell;
    private Button switchButton;

    private void Start()
    {
        switchButton = Managers.uiManager.switchButton;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switchButton.gameObject.SetActive(true);
        switchButton.GetComponent<SwitchButtonController>().SetIntersectionController(intersectionController);

        GetComponent<AudioSource>().clip = crossing_bell;
        GetComponent<AudioSource>().Play();
        // start sound
        // start lights
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switchButton.gameObject.SetActive(false);
        GetComponent<AudioSource>().Stop();
    }
}
