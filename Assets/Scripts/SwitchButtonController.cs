using UnityEngine;

public class SwitchButtonController : MonoBehaviour {

    private IntersectionController intersectionController;

	public void ToggleIntersection()
    {
        intersectionController.ToggleTarget();
    }

    public void SetIntersectionController(IntersectionController cont)
    {
        intersectionController = cont;
    }
}
