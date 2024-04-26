/*using UnityEditor;
using UnityEngine;

public class CustomMenu : MonoBehaviour
{
    private int customMenu = 0;

    [MenuItem("MyMenu/CustomOption")]
    public static void MyCustomFunction(MenuCommand menuCommand)
    {
        Debug.Log("Custom menu option clicked!");
    }

    void MyContextFunction(MenuCommand menuCommand)
    {
        // Crea una nueva instancia de MenuCommand con el valor customMenu
        var newMenuCommand = new MenuCommand(null, customMenu);

        // Llama a la función MyCustomFunction() utilizando la nueva instancia de MenuCommand
        MyCustomFunction(newMenuCommand);
    }
}
*/