using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject object1; // Reference to Object 1
    public GameObject object2; // Reference to Object 2
    public GameObject object3; // Reference to Object 3

    void Update()
    {
        // Check for numpad key presses to toggle objects
        if (Input.GetKeyDown(KeyCode.Keypad1)) // Numpad 1
        {
            ToggleObject(object1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) // Numpad 2
        {
            ToggleObject(object2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) // Numpad 3
        {
            ToggleObject(object3);
        }
    }

    // Method to toggle the active state of a GameObject
    void ToggleObject(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(!obj.activeSelf); // Toggle the active state
        }
    }
}
