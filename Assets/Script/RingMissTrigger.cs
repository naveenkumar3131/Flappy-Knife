using UnityEngine;

public class RingMissTrigger : MonoBehaviour
{
    private bool passedThrough = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !passedThrough)
        {
            Debug.Log("Ring Skipped ❌");
            FindObjectOfType<HeartManager>().TakeDamage();
        }
    }

    public void MarkPassed()
    {
        passedThrough = true;
    }
}
