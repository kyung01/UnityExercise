using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using System.ComponentModel;
/// <summary>
/// GameBase2 Class is for implementing new version of this game
/// This class is mainly created to implement SessionData2 file.
/// </summary>
public abstract class GameBase2 : GameBase
{
    public override GameBase StartSession(TextAsset sessionFile)
    {
        // Create and load a SessionData object to give to the active game.
        sessionData = new SessionData2();
        if (XMLUtil.LoadSessionData(sessionFile, ref sessionData))
        {
            GUILog.Log("Game {0} starting Session {1}", this.gameObject.name, sessionFile.name);
            RaiseOnStart();
        }
        else
        {
            GUILog.Error("Game {0} failed to load session file {1}", this.gameObject.name, sessionFile.name);
        }
        return this;
    }
}