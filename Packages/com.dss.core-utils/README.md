# core-utils

A collection of common Unity scripts and extensions I've found myself continually rewriting.

TODO: write more details about how each of these works.


## How To Install

The core-utils package uses the [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) feature to import
dependent packages. Please add the following sections to the package manifest
file (`Packages/manifest.json`).

To the `scopedRegistries` section:

```
{
  "name": "DSS",
  "url": "https://registry.npmjs.com",
  "scopes": [ "com.dss" ]
}
```

To the `dependencies` section:

```
"com.dss.core-utils": "1.3.7"
```

After changes, the manifest file should look like below:

```
{
  "scopedRegistries": [
    {
      "name": "DSS",
      "url": "https://registry.npmjs.com",
      "scopes": [ "com.dss" ]
    }
  ],
  "dependencies": {
    "com.dss.core-utils": "1.3.7",
    ...
```

## Application Utilities

Exposes a setter for common `UnityEngine.Application` properties, so they can be set by the event system (Buttons, Toggles, etc).

- `OpenURL`
- `PlatformConditional`
- `Quiter`
- `SetTargetFrameRate`

## Camera Utilities

Various camera and rendering related utilities.

- `DynamicCameraResolution`

## Events

Exposes common events to the event system.

- `OnKeyCodeCombination`
- `OnStart`

## Extensions

Extends several built in and Unity-specific classes.

- `ListExtensions`
- `RectTransformExtensions`
- `StringExtensions`
- `TerrainExtensions`
- `TextAssetExtensions`
- `TransformExtensions`

## Inspector Notes

Adds customizable notes to gameObject inspectors in the scene.

- `InspectorNote`

## Layout Utilities

Helps with common layout paradigms.

- `BidirectionalLayoutGroup`
- `CropToSafeArea`
- `ResponsiveBidirectionalLayoutGroup`
- `ResponsiveGridLayout`
- `SnapRect`

## Screen Utilities

Exposes various events for the Screen class.

- `AspectRatioConditional`
- `ScreenWatcher`

## Terrain Utilities

Utilities for converting `Terrain` components, and modifying their heights.

- `Mesh To Terrain`
- `Heighten and Deepen`

## Tweening

Exposes an extensible "Tween" class that tweens between two values, with interuption support.

- `ScaleOnClick`
- `Tweener`