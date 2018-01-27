using UnityEngine;
using UnityEngine.UI;

public class ApproachTriggerController : MonoBehaviour {

    public IntersectionController intersectionController;
    public Button switchButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switchButton.gameObject.SetActive(true);
        switchButton.GetComponent<SwitchButtonController>().SetIntersectionController(intersectionController);
        // start sound
        // start lights

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switchButton.gameObject.SetActive(false);
    }
}
