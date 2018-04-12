using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// In this game, React, we want to display a stimulus (rectangle) for a defined duration.
/// During that duration, the player needs to respond as quickly as possible.
/// Each Trial also has a defined delay to keep the player from guessing.
/// Some appropriate visual feedback is also displayed according to the player's response.
/// </summary>
public class React2 : React
{
    const string INSTRUCTIONS_RED = "Do not press <color=cyan>Spacebar</color>.";

    protected override IEnumerator DisplayStimulus(Trial t)
    {
        GameObject stim = stimulus;
        stim.SetActive(false);

        yield return new WaitForSeconds(t.delay);

        StartInput();
        stim.GetComponent<RectTransform>().localPosition = new Vector3(t.x, t.y, 0);
        if (t.isRed)
        {
            stim.GetComponent<Image>().color = Color.red;
            instructionsText.text = INSTRUCTIONS_RED;
        }
        else{
            stim.GetComponent<Image>().color = Color.white;

            instructionsText.text = INSTRUCTIONS;
        }
        stim.SetActive(true);

        yield return new WaitForSeconds(((ReactTrial)t).duration);
        stim.SetActive(false);
        EndInput();

        yield break;
    }
    //protected override void AddResult(Trial t, float time)
    
}
