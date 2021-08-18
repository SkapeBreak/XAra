using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    START_GAME,
    KILL_PLAYER
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;
    
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
            case ButtonType.START_GAME:
                //Call other code that is necessary to start the game like levelManager.StartGame()
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.KILL_PLAYER:
                //Do More Things like SaveSystem.Save()
                canvasManager.SwitchCanvas(CanvasType.EndScreen);
                break;
            default:
                break;
        }
    }
}

