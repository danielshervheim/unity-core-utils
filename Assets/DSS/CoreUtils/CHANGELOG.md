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