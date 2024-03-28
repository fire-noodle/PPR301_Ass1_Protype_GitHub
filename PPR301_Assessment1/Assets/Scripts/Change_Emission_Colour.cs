using UnityEngine;

public class Change_Emission_Colour : MonoBehaviour
{
    // Reference to the Light component
    private Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Light component attached to the object
        lightComponent = GetComponent<Light>();
    }

    // Function to change emission color

    public void ChangeEmission(Color newColor)
    {
        // Set the new emission color
        lightComponent.color = newColor;
    }
}