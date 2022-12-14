using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    // This is the path to the CSV file that we want to load.
    // You can change this to any path that you like.
    //string csvFilePath = "Assets/Resources/TextScripts/test.csv";
    //string dialogueFileName = "test.csv";

    public PrintDialogue dialoguePrinter;
    
    private string fileName = "test";
    private TextAsset dialogueTextAsset;
    private string[] dialogueLines;
    private int currentLine = 0;

    

    void Start(){
        // Load the CSV file into the lines list.
        //lines = File.ReadAllLines(csvFilePath).ToList();
        dialogueTextAsset = Resources.Load<TextAsset> ("TextScripts/" + fileName);
        dialogueLines = dialogueTextAsset.text.Split('\n');
    }

    void ClickForNextDialogueLine(){
        // if the current line index is within the bounds of the dialogue lines array,
        // write the current line and increment the line index
        if (currentLine < dialogueLines.Length){
            dialoguePrinter.PrintLine(dialogueLines[currentLine]);
            Debug.Log(dialogueLines[currentLine]);
            currentLine++;
        }
    }

    

	int frameWait = 0;
	int fastDialogueFrameLag = 5;
	bool duringSkip = false;
    
    void Update(){
		//if (DuringDialogue ()) {
			if ((Input.GetKeyUp (KeyCode.Return)) || Input.GetKeyUp (KeyCode.KeypadEnter) || Input.GetKeyUp (KeyCode.Space)) {
				ClickForNextDialogueLine ();
			} else if (Input.GetKey (KeyCode.LeftControl) || duringSkip) {
				frameWait++;
				if (frameWait >= fastDialogueFrameLag) {
					frameWait = 0;
					ClickForNextDialogueLine ();
				}
			} /*else if (Input.GetKeyDown (KeyCode.L)) {
				OpenOrCloseLog ();
			}*/
		//}
        /*else{
			if (SceneManager.GetActiveScene ().name == "Story") {
				LoadSaveData ();
			}
		}*/
    }
}