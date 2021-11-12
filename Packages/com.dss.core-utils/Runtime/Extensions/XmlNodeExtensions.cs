using System;
using System.Xml;

namespace DSS.CoreUtils.Extensions
{

// @brief A collection of extension methods for the XmlNode class.
public static class XmlNodeExtensions
{
    // @brief Returns wether or not the XmlNode has an attribute with the given name
    public static bool HasAttribute(this XmlNode node, string attributeName)
    {
        try
        {
            foreach (XmlAttribute attribute in node.Attributes)
            {
                if (attribute.Name.Equals(attributeName))
                {
                    return true;
                }
            }
        }
        catch (Exception)
        {
            return false;
        }
        return false;
    }
    
    // @brief Returns the value of the attribute with the specified name. If no such attribute
    // exists, the empty string is returned.
    public static string AttributeValue(this XmlNode node, string attributeName)
    {
        foreach (XmlAttribute attribute in node.Attributes)
        {
            if (attribute.Name.Equals(attributeName))
            {
                return attribute.Value;
            }
        }
        return string.Empty;
    }

    // @brief Finds the immediate child by name.
    // Throws an error if more than one child exists with the specified name.
    // Returns null if no child exists with the specified name.
    public static XmlNode SelectUniqueChild(this XmlNode node, string childNodeName)
    {
        XmlNodeList childrenNodes = node.SelectNodes(childNodeName);
        if (childrenNodes.Count > 1)
        {
            throw new ArgumentException($"Expected at most one <{childNodeName}> node per <{node.Name}> node");
        }
        return childrenNodes.Count > 0 ? childrenNodes[0] : null;
    }
}

}  // namespace DSS.CoreUtils.Extensions