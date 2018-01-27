using UnityEngine;
using UnityEngine.UI;

public class ApproachTriggerController : MonoBehaviour {

    public IntersectionController intersectionController;
    public Button switchButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switchButton.gameObject.SetActive(true);
        // tell button to talk to me
        // start sound
        // start lights

    }
}
