# unity-tools
Some generic tools i've written for my own games, which might also be useful for anyone else developing games in Unity3d.

# SingletonPrefab.cs
SingletonPrefab is a modified version of the Singleton class from http://wiki.unity3d.com/index.php/Singleton. It is also an abstract class, and allows you to call [concrete class name].Instance from anywhere and have the prefab instantiated at run-time if it does not already exist in the scene. 

IMPORTANT: This only works if you have named your prefab the exact same name as the concrete class name, AND your prefab must be placed at the root of the "Resources" folder.
