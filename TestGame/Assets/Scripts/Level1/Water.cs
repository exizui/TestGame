
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.GameOver();
            Pause.Instance.Loose();
        }
    }
}
