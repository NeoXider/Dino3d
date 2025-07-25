using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DinoController>())
            GameController.Instance.GameOver();
    }
}