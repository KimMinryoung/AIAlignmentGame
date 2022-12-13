using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UISceneButton : MonoBehaviour
{
    [SerializeField] Image image;
    public string sceneName;
    Button.ButtonClickedEvent onClick;
    Button buttonComponent;

    void Start(){
        Initialize();
    }

    // Create a method to initialize the button
    public void Initialize()
    {
        // Set the button image
        //image.sprite = sprite;

        // Set the button click event
        // onClick = onClickEvent;
        buttonComponent = image.gameObject.AddComponent<Button>();
        buttonComponent.onClick.AddListener(() => SceneManager.LoadScene(sceneName));
    }

    // Create a method to enable or disable the button
    public void SetInteractable(bool interactable)
    {
        // Set the button interactable state
        buttonComponent.interactable = interactable;
    }

    /*

    public Texture2D buttonImage;
    void Start()
    {
        // Create the button GameObject
        GameObject button = new GameObject("Button");

        // Add a RectTransform component to the button
        RectTransform rectTransform = button.AddComponent<RectTransform>();

        // Set the position and size of the button
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10, 100);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 10, 50);

        // Add a CanvasRenderer component to the button
        button.AddComponent<CanvasRenderer>();

        // Add a UI Image component to the button
        Image image = button.AddComponent<Image>();

        // Set the image of the UI Image component to the button image
        image.sprite = Sprite.Create(buttonImage, new Rect(0, 0, buttonImage.width, buttonImage.height), new Vector2(0.5f, 0.5f));

        // Add a Button component to the button
        Button buttonComponent = button.AddComponent<Button>();

        // Register a Click event handler for the Button component
        buttonComponent.onClick.AddListener(() => SceneManager.LoadScene("MainGame"));
    }
    */
}