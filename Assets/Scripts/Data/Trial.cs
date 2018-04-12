using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;


/// <summary>
/// A trial is when a player has to respond to a situation, 
/// which becomes marked as a success or failure depending on the player's response.
/// </summary>
public class Trial
{

	#region ATTRIBUTES

	public const string ATTRIBUTE_IS_GO = "isGo";
    public const string ATTRIBUTE_DELAY = "delay";
    public const string ATTRIBUTE_IS_RED = "isRed";
    public const string ATTRIBUTE_POSITION = "position";

    #endregion


    /// <summary>
    /// A delay before the Trial begins.
    /// </summary>
    public float delay = 0;
    /// <summary>
    /// Determines whether the trial is red.
    /// If the trial is red, game proceeds to take "not responding to input" as the correct response from user.
    /// </summary>
    public bool isRed = false;
    /// <summary>
    /// x coordinate of the trial square.
    /// </summary>
    public float x = 0;
    /// <summary>
    /// y coordinate of the trial square.
    /// </summary>
    public float y = 0;

    public Trial(SessionData data, XmlElement n)
	{
		ParseGameSpecificVars(n, data);
	}
	

	/// <summary>
	/// Parses Game specific variables for this Trial from the given XmlElement.
	/// If no parsable attributes are found, or fail, then it will generate some from the given GameData.
	/// Used when parsing a Trial that IS defined in the Session file.
	/// </summary>
	public virtual void ParseGameSpecificVars(XmlNode n, SessionData data)
    {
        XMLUtil.ParseAttribute(n, ATTRIBUTE_DELAY, ref delay);
        XMLUtil.ParseAttribute(n, ATTRIBUTE_IS_RED, ref isRed, true);
        string position="";
        if(XMLUtil.ParseAttribute(n, ATTRIBUTE_POSITION, ref position, true))
        {
            if (position == "random")
            {
                x = Random.Range(data.xMin, data.xMax);
                y = Random.Range(data.yMin, data.yMax);
            }
            else
            {
                string[] xy = position.Split(' ');
                x = float.Parse(xy[0]);
                y = float.Parse(xy[1]);
            }
        }
    }

	
	/// <summary>
	/// Writes any tracked variables to the given XElement.
	/// </summary>
	public virtual void WriteOutputData(ref XElement elem)
    {
        XMLUtil.CreateAttribute(ATTRIBUTE_POSITION, (x+" "+y).ToString(), ref elem);
        XMLUtil.CreateAttribute(ATTRIBUTE_IS_RED, isRed.ToString(), ref elem);
        XMLUtil.CreateAttribute(ATTRIBUTE_DELAY, delay.ToString(), ref elem);
    }
}
