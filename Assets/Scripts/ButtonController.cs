using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;
    // Button RecommendationsButton;
    // Button ManualsButton;
    // Button GuestBoookButton;
    // Button RestaurantsButton;
    // Button MuseumsBackButton;
    // Button ParksButton;
    // Button AmenitiesButton;
    // Button SubmitButton;
    // Button CancelButton;
    
    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    void OnButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonType.ONE:
                //Call other code that is necessary to start the game like levelManager.StartGame()
                canvasManager.SwitchCanvas(CanvasType.Recommendations);
                break;
            case ButtonType.TWO:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Restaurants);
                break;
            case ButtonType.THREE:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Museums);
                break;
            case ButtonType.FOUR:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Parks);
                break;
            case ButtonType.FIVE:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Amenities);
                break;
            case ButtonType.SIX:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.Manuals);
                break;
            case ButtonType.SEVEN:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.GuestBook);
                break;
            default:
                break;
        }
    }
}

