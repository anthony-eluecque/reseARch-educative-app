using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VScriptButtonManager : MonoBehaviour
{

    public GameObject yourObjectToControl;
    public string virtualButtonName;

    private VirtualButtonBehaviour virtualButton; 
    public VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        virtualButton = yourObjectToControl.GetComponentInChildren<VirtualButtonBehaviour>();
        Debug.Log("oui bonjour");

        if (virtualButton)
        {
            Debug.Log("ça rentre bien ds la boucle");
            virtualButton.RegisterOnButtonPressed(OnButtonPressed);
            virtualButton.RegisterOnButtonReleased(OnButtonReleased);
        }
        else
        {
            Debug.LogError("Virtual Button not found. Make sure it is set up in the Vuforia configuration.");
        }

    }
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Pressed!");
        player.Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Released!");
        player.Pause();
    }


}
