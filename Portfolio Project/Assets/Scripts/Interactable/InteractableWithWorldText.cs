using UnityEngine;

public class InteractableWithWorldText : Interactable
{
    [Header("Canvas Refrences")]
    [SerializeField] GameObject WorldCanvas;

    [Header("Text Refrences")]
    [SerializeField] GameObject WorldTextBoxPrefab;
    [SerializeField] string Message;
    

    [Header("Text Settings ")]
    [SerializeField] float lifeTime = 1;
    [SerializeField] float TextFloatSpeed;
    [SerializeField] bool TextFloat = false;
    [SerializeField] bool TextFade = false;
    [SerializeField] Transform DisplayPoint;
    [SerializeField] bool CanToggleText;

    WorldText WorldText;
    GameObject WorldTextBox;


    private void Start()
    {
        WorldTextBox = Instantiate(WorldTextBoxPrefab,WorldCanvas.transform);   
        WorldText = WorldTextBox.gameObject.GetComponent<WorldText>();
        if(WorldText!=null)
        {
            WorldText.SetText(Message);
            WorldText.SetValue(TextFloatSpeed, lifeTime, TextFloat, TextFade, DisplayPoint);
        }
   
        
    }

    private void Update()
    {
        
    }

    override public void Activate()
    {
        base.Activate();

        if(WorldTextBox != null )
        {
            if(!WorldText.started)
            {
                WorldText.WordStart();
            }
            else if( CanToggleText)
            {
                WorldText.HideTexttoggle();
            }
           
        }

    }

}
