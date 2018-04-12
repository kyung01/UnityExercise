using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

public class SessionData2 : SessionData
{
    // General Attributes.
    const string ATTRIBUTE_X_MIN = "xMin";
    const string ATTRIBUTE_X_MAX = "xMax";
    const string ATTRIBUTE_Y_MIN = "yMin";
    const string ATTRIBUTE_Y_MAX = "yMax";
    /// <summary>
    /// Indicates the minimum value for the random position range of x coordinate.
    /// </summary>
    public float xMin = 0;
    /// <summary>
    /// Indicates the maximum value for the random position range of x coordinate.
    /// </summary>
    public float xMax = 0;
    /// <summary>
    /// Indicates the minimum value for the random position range of y coordinate.
    /// </summary>
    public float yMin = 0;
    /// <summary>
    /// Indicates the maximum value for the random position range of y coordinate.
    /// </summary>
    public float yMax = 0;

    public override void ParseElement(XmlElement elem)
    {
        XMLUtil.ParseAttribute(elem, ATTRIBUTE_Y_MIN, ref yMin);
        XMLUtil.ParseAttribute(elem, ATTRIBUTE_Y_MAX, ref yMax);
        XMLUtil.ParseAttribute(elem, ATTRIBUTE_X_MIN, ref xMin);
        XMLUtil.ParseAttribute(elem, ATTRIBUTE_X_MAX, ref xMax);
        base.ParseElement(elem);
    }
    public override void WriteOutputData(ref XElement elem)
    {
        XMLUtil.CreateAttribute(ATTRIBUTE_Y_MIN, yMin.ToString(), ref elem);
        XMLUtil.CreateAttribute(ATTRIBUTE_Y_MAX, yMax.ToString(), ref elem);
        XMLUtil.CreateAttribute(ATTRIBUTE_X_MIN, xMin.ToString(), ref elem);
        XMLUtil.CreateAttribute(ATTRIBUTE_X_MAX, xMax.ToString(), ref elem);
        base.WriteOutputData(ref elem);
    }
}
