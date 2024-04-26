/*using UnityEditor;
using UnityEngine;

public class CustomEditor : EditorWindow
{
    [MenuItem("MyMenu/CustomOption")]
    static void CustomOption()
    {
        CustomMenu customMenu = new CustomMenu();
        UnityEditor.MenuCommand menuCommand = new UnityEditor.MenuCommand(customMenu, 0);
        menuCommand.context = Selection.activeObject;
        CustomMenu.MyCustomFunction(menuCommand);
    }

    [MenuItem("CustomMenu/MyCustomFunction")]
    static void DoSomething()
    {
        CustomMenu.MyCustomFunction(new MenuCommand(null, 0));
    }
}
*/