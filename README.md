# unity-core

Please see the [readme](Packages/com.danielshervheim.core-utils/README.md) in the package directory for information on all of the included utilities.

## How To Install

The core-utils package uses the [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) feature to import
dependent packages. Please add the following sections to the package manifest
file (`Packages/manifest.json`).

To the `scopedRegistries` section:

```json
{
  "name": "DSS",
  "url": "https://registry.npmjs.com",
  "scopes": [ "com.danielshervheim" ]
}
```

To the `dependencies` section:

```json
"com.danielshervheim.core-utils": "1.3.2"
```

After changes, the manifest file should look like below:

```json
{
  "scopedRegistries": [
    {
      "name": "DSS",
      "url": "https://registry.npmjs.com",
      "scopes": [ "com.danielshervheim" ]
    }
  ],
  "dependencies": {
    "com.danielshervheim.core-utils": "1.3.2",
    ...
```