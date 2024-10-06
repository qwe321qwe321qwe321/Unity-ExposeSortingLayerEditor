# Unity-ExposeSortingLayerEditor
Expose the Sorting Layer settings for MeshRenderer and SkinnedMeshRenderer components in the Unity Inspector.
|![image](https://github.com/user-attachments/assets/1a704428-84ac-438e-a236-cdc33ca8a532) | ![image](https://github.com/user-attachments/assets/232b12c2-d1ce-41cf-acd9-dc7eb646d531) |
|--|--|

* Supports both MeshRenderer and SkinnedMeshRenderer components.
* Compatible with Prefab Mode, Multi-Selection, and Undo/Redo.

## Installation
Add the following url to the Package Manager in Unity.
```
https://github.com/qwe321qwe321qwe321/ExposeSortingLayerEditor.git
```

## How it works
This repo improves upon [the original gist](https://gist.github.com/sinbad/bd0c49bc462289fa1a018ffd70d806e3) by inheriting the `MeshRendererEditor` and `SkinnedMeshRendererEditor` classes instead of the Editor class. And using the internal methods to build the editor GUI to have a better look and compatibility with Unity.

To access the `MeshRendererEditor` and `SkinnedMeshRendererEditor` internal classes, I added the `ExposeSortingLayerEditor.asmdef`, which is actually the `Unity.InternalAPIEngineBridge.017` assembly. (The `017` is arbitrary; you can change it to any number under 024.)

These `InternalAPIEngineBridge` assemblies are used to access the internal classes of Unity. You can find them in the [Unity source code](https://github.com/Unity-Technologies/UnityCsReference/blob/4b436cf82aaff7a0719e373ee8af4f4625f05638/Runtime/Export/AssemblyInfo.cs#L115).