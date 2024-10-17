using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    [SerializeField] float lastPressTime = -1f;
    [SerializeField] bool PlayingActive = false;
    [SerializeField] float timeLimit = 5.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPressTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            lastPressTime = Time.time;
        }

        if (lastPressTime > 0 && Time.time - lastPressTime <= timeLimit)
        {
            Debug.Log("Button or mouse pressed within the last 5 seconds.");
            PlayingActive = true;
        }
        else if (lastPressTime > 0 && Time.time - lastPressTime > timeLimit)
        {
            Debug.Log("More than 5 seconds have passed since the last button press.");
            PlayingActive = false;
        }
    }
}
