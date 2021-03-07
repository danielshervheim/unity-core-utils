# unity-core
A collection of common Unity scripts and extensions I've found myself continually rewriting.

TODO: write more details about how each of these works.

## Application Utilities

Exposes a setter for common `UnityEngine.Application` properties, so they can be set by the event system (Buttons, Toggles, etc).

- `OpenURL`
- `Quiter`
- `SetTargetFrameRate`

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
- `ResponsiveBidirectionalLayoutGroup`
- `ResponsiveGridLayout`

## Screen Utilities

Exposes various events for the Screen class.

- `AspectRatioConditional`
- `MatchSafeArea`
- `ScreenWatcher`

## Terrain Utilities

Utilities for converting `Terrain` components, and modifying their heights.

- `Mesh To Terrain`
- `Heighten and Deepen`

## Tweening

Exposes an extensible "Tween" class that tweens between two values, with interuption support.

- `ScaleOnClick`
- `Tweener`