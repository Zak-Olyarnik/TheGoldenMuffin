using System.Reflection;
using UnityEditor;

// Custom Editor script for PlayerMover, keeping the custom display created for the AIPath parent class but also
    // adding PlayerMover properties as they would normally be displayed
    // https://forum.unity.com/threads/is-it-possible-to-mixed-inherited-custom-inspector-and-default-inspector-for-not-inherited-members.516813/
namespace Pathfinding
{
    [CustomEditor(typeof(PlayerMover), true)]
    [CanEditMultipleObjects]
    public class PlayerMoverEditor : BaseAIEditor
    {
        private string[] propertiesInBaseClass;     // stores all base class properties to stop double-displaying them


        protected override void OnEnable()
        {
            // Collect all the parent class properties into a string array
            FieldInfo[] fields = typeof(AIPath).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            propertiesInBaseClass = new string[fields.Length];
            for (int i = 0; i < fields.Length; i++)
            {
                propertiesInBaseClass[i] = fields[i].Name;
            }
        }

        // Draws all properties exclusive to the child class, followed by the custom display for the parent class
        protected override void Inspector()
        {
            DrawPropertiesExcluding(serializedObject, propertiesInBaseClass);
            base.Inspector();
        }
    }
}