//stim.GetComponent<RectTransform>().localPosition = new Vector3(t.x, t.y,0);
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
    protected override IEnumerator DisplayStimulus(Trial t)
    {
        GameObject stim = stimulus;
        stim.SetActive(false);

        yield return new WaitForSeconds(t.delay);

        StartInput();
        stim.GetComponent<RectTransform>().localPosition = new Vector3(t.x, t.y, 0);
        stim.SetActive(true);

        yield return new WaitForSeconds(((ReactTrial)t).duration);
        stim.SetActive(false);
        EndInput();

        yield break;
    }
}
