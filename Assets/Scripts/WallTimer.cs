using UnityEngine;

public class WallTimer : MonoBehaviour
{
    // How many seconds before the wall disappears
    public float timeUntilDelete = 60f;

    void Start()
    {
        // Destroy this wall after the set time
        Destroy(gameObject, timeUntilDelete);
    }
}
