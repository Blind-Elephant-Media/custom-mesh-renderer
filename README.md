<div align="center">

# `🖼️ bem-custom-mesh-renderer`

**Efficient and flexible custom mesh renderer solution for Unity**

[![Bem Opensource](https://img.shields.io/badge/bem-open%20source-blueviolet.svg)](#)
[![Discord](https://img.shields.io/badge/discord-%237289da.svg?logo=discord)](https://discord.gg/7mqsYMzWdh)
[![Unity Version](https://img.shields.io/badge/Unity-2022.3%20LTS-black.svg?logo=unity)](https://unity.com/releases/editor/whats-new/2022.3.5)

</div>

## Why use this?

- It provides an efficient way to handle graphics instances in your Unity projects.
- The `GraphicsInstance` class manages a collection of `Batch` objects, each containing a dictionary of matrices representing individual instances of a `GraphicsObject`.
- It includes methods to add instances to batches, initialize all batches, remove an instance from a batch, and draw all instances of the `GraphicsObject`.
- It uses Unity's `Graphics.DrawMeshInstanced` method to draw all instances of the `GraphicsObject`.

## Why not use this?

- If your project does not require custom mesh rendering or if the built-in Unity rendering functions are sufficient for your needs, you might not need this solution.
- This solution is designed for projects that require a high degree of control over graphics instances and batches. If your project has simpler graphics needs, this solution might be more complex than necessary.

## Code Snippet

Here's a snippet from our `GraphicsInstance` class:

```csharp
public class GraphicsInstance
{
    // ...
    public int AddInstance(Matrix4x4 matrix)
    {
        // ...
    }
    
    public int AddInstanceAndLoad(Matrix4x4 matrix)
    {
        // ...
    }

    public void Init()
    {
        // ...
    }
    
    public void RemoveInstance(int id)
    {
        // ...
    }

    public class Batch
    {
        // ...
    }

    public void Draw()
    {
        // ...
    }
}
