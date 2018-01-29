using UnityEngine;

public class TrainController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Managers.trainManager.activeTrain == gameObject)
        {
            Rigidbody2D thisRB = GetComponent<Rigidbody2D>();
            float currentForce = thisRB.velocity.magnitude;
            collision.otherRigidbody.AddForce(new Vector2(0, currentForce * 100));
            thisRB.drag = 4;
            Debug.Log("collision " + currentForce);
        }
    }
}
