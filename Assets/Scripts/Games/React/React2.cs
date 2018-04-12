using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// In this game, React, we want to display a stimulus (rectangle) for a defined duration.
/// During that duration, the player needs to respond as quickly as possible.
/// Each Trial also has a defined delay to keep the player from guessing.
/// Each Trial can have different position or random position according to the given settings.
/// Each Trial can be red. Correct response to the red trial is to do nothing.
/// Some appropriate visual feedback is also displayed according to the player's response.
/// </summary>
public class React2 : React
{
    /// <summary>
    /// Instruction displayed when the red stimulus is displayed.
    /// </summary>
    const string INSTRUCTIONS_RED = "Do not press <color=cyan>Spacebar</color>.";
    /// <summary>
    /// Reponse is displayed when the player incorrectly give input when red stimulus is displayed.
    /// </summary>
    const string RESPONSE_WRONG = "Do not press anything!";

    /// <summary>
    /// Displays the Stimulus for a specified duration.
    /// During that duration the player needs to respond as quickly as possible.
    /// However if the Stimulus is red, player should not respond to it. 
    /// </summary>
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
    
    /// <summary>
	/// Adds a result to the SessionData for the given trial.
	/// </summary>
	protected override void AddResult(Trial t, float time)
    {
        if (!t.isRed)
        {
            //Stimulus is not red. The new implementation is not required.
            base.AddResult(t, time);
            return;
        }
        //Stimulus is red. New implementation is required.
        TrialResult r = new TrialResult(t);
        r.responseTime = time;
        if (time == 0)
        {
            // No response.
            DisplayFeedback(RESPONSE_CORRECT, RESPONSE_COLOR_GOOD);
            r.success = true;
            r.accuracy = 1;
            GUILog.Log("Success! No response!");
        }
        else
        {
            if (IsGuessResponse(time))
            {
                // Responded before the guess limit, aka guessed.
                DisplayFeedback(RESPONSE_GUESS, RESPONSE_COLOR_BAD);
                GUILog.Log("Fail! Guess response! responseTime = {0}", time);
            }
            else
            {
                // Responded too slow.
                DisplayFeedback(RESPONSE_WRONG, RESPONSE_COLOR_BAD);
                GUILog.Log("Fail! Response detected! responseTime = {0}", time);
            }
        }
        sessionData.results.Add(r);
    }

}
