# CoreUtils

## 1.0.0

- Initial release.

## 1.0.1

- Changed package name from "UnityCoreUtils" to "CoreUtils".

## 1.0.2

- Added `MultiLayoutGroup` class.

## 1.0.3

- Added `ResponsiveMultiLayoutGroup` class to modify a `MultiLayoutGroup`'s `direction` property based on the device's aspect ratio.

## 1.0.4

- Renamed `MultiLayoutGroup` to `BidirectionalLayoutGroup`, as it better describes the classes intended function.

## 1.0.5

- Added `ColorPalette` classes, for keeping a consistent color scheme throughought a project.

## 1.0.6

- Added `ResponsiveGridLayout` class, to automatically make grid children fit to a certain row and column count.

## 1.0.7

- Added `MatchSafeArea` class, to automatically resize a RectTransform to the screen's safe area. This is useful for notched devices like the iPhone X, etc.

## 1.0.8

- Added `SetTargetFrameRate` component to automatically set the applications target frame rate.

## 1.0.9

- Added `OnStartEvent` to expose an onStart event to the editor that other classes can hook into.

## 1.0.10

- Added `Tweener` class and example implementations for tweening objects between two states.
- Added a custom editor window for the `ApplyColorPalette` component. 

## 1.0.11

- Changed `BidirectionalLayoutGroup` and associated classes from namespace `Layout` to `BidirectionalLayoutGroup`.

## 1.0.12

- Moved most classes into common `DSS.CoreUtils` namespace.

## 1.0.13

- Fixed logic error in Tweener.

## 1.0.14

- Added `OpenURL` class.

## 1.0.15

- Added `TerrainExtensions` and `UpdateTerrainHeightEditorWindow` classes.

## 1.0.16

- Added `NonNull()` extension method to `ListExtensions`.

## 1.0.17

- Added `TerrainToMesh` and `MeshToTerrain` extensions.

## 1.1.0

- Split `ColorPalette` and related classes off into it's own [repository](https://github.com/danielshervheim/unity-color-palettes)

## 1.1.1

- Added `OnKeyCodeCombination` class to listen for certain key press combinations (like the Konami code).

## 1.2.0

- Added `ScreenWatcher` and `AspectRatioConditional` for en/disabling gameObjects based on the screen's aspect ratio.

## 1.2.1

- Added `InspectorNote` class.

## 1.3.0

- Majorly reshuffled and simplified classes into namespaces.

## 1.3.1

- Added `SnapRect` class.

## 1.3.2

- Moved to NPM, added readme to package root.

## 1.3.3

- Changed required unity version from `2018.3` to `2019.1`.

## 1.3.4

- Fixed github link in `package.json`.

## 1.3.5

- Added `PlatformConditional` class.

## 1.3.6

- Added `DisableIfNot` behaviour to the `PlatformConditional` class.

## 1.3.7

- Added `DynamicCameraResolution` script.

## 1.3.8

- Improved comments in the `DynamicCameraResolution` script.

## 1.3.9

- Added `Pivot` extensions to `RectTransformExtensions` class.
- Added `GraphicExtensions` class.

## 1.3.10

- Marked `MatchSafeArea` class as obsolete.
- Added `CropToSafeArea` class, which does the same thing as `MatchSafeArea` but more robustly.

## 1.4.0

- Removed `MatchSafeArea` class.
- Moved `CropToSafeArea` into `LayoutUtilities` namespace.
- Updated `SnapRect` to use layout system hooks, to reduce computation per-frame.
- Added `AddComponentAttribute` to classes.

## 1.4.1

- Fixed bug causing `CropToSafeArea` RectTransforms to shrink to 0 scale.

## 1.4.2

- Fixed undefined `Tweener` behaviour when the gameObject they are attached to are disabled.
    - Added overrideable `OnDisabledBehaviour BehaviourOnDisable()` method.

## 1.4.3

- Fixed bug where `CropToSafeArea` was not listening properly for changes in the `Screen.safeArea` rect, and hence missing re-layout. 

## 1.5.0

- Added `ReadOnly` and `ReadOnlyRuntime` attributes.

## 1.5.1

- Added `SerializedPropertyContainer` editor utility, and modified `DynamicCameraResolutionEditor` to use it.

## 1.6.0

- Removed buggy terrain utilities.
- Removed buggy `DynamicCameraResolution` utility.
- Removed `ReadOnly` and `ReadOnlyRuntime` attributes in favor of custom inspectors.
- Removed `AspectRatioConditional` and replaced with equivalent functionality in `ScreenWatcher`.
- Renamed `SnapRect` to `RectTransformSnapper`.
- Added `GUIUtilities` class for easier custom inspector creation.
- Added `XmlNodeExtensions` class.
- Added more extension methods to `StringExtensions` and `TransformExtensions`.
- Added custom inspectors for all MonoBehaviours.

## 1.6.1

- Added `MaterialPropertyContainer` class.
- Added `GUIUtilities.Popup` helper method.

## 1.6.2

- Fixed misnamed `MaterialPropertyContainer` class.