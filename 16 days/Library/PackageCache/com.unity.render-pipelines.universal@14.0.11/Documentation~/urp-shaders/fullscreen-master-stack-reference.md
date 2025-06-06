---
uid: um-fullscreen-master-stack-reference
---

# Fullscreen Master Stack in Shader Graph reference for URP

The Fullscreen Master Stack has a variety of properties in the Graph Settings window which control the overall appearance of the Fullscreen shader.

## <a name="surface-options"></a>Surface Options

| **Property** | **Description** |
| ------------ | --------------- |
| **Allow Override Material** | Exposes the Graph Settings properties in the Material’s **Surface Options**. **Note:** You can only expose properties that you enable in **Graph Settings.** If you enable one of these properties, you can’t disable it in the Inspector under the Material’s **Surface Options.** |
| **Blend Mode** | Specifies the blend mode to use when Unity renders the full-screen shader. Each option has an equivalent [`BlendMode`](https://docs.unity3d.com/ScriptReference/Rendering.BlendMode.html) operation. **Note**: When you write to a Blit shader, disable this property to avoid undesired effects. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Alpha** | Uses the shader’s alpha value to control its opacity. `BlendMode` operation: `Blend SrcAlpha OneMinusSrcAlpha` |
| &nbsp;&nbsp;&nbsp;&nbsp;**Premultiply** | Multiplies the RGB values of the transparent shader by its alpha value, then applies a similar effect to the shader as **Alpha**.  `BlendMode` operation: `Blend One OneMinusSrcAlpha` |
| &nbsp;&nbsp;&nbsp;&nbsp;**Additive** | Adds the color values of the full-screen shader and the Camera output together. `BlendMode` operation: `Blend One One` |
| &nbsp;&nbsp;&nbsp;&nbsp;**Multiply** | Multiplies the color of the full-screen shader with the color of the Camera’s output. `BlendMode` operation: `Blend DstColor Zero` |
| &nbsp;&nbsp;&nbsp;&nbsp;**Custom** | Set every parameter of the blending equation manually. For more information, refer to [Custom blend modes](#custom-blend-modes). |
| **Depth Test** | Specifies the function this shader uses to perform the depth test. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Disabled** | Does not perform a depth test. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Never** | The depth test never passes. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Less** | The depth test passes if the pixel's depth value is less than the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Equal** | The depth test passes if the pixel's depth value is equal to the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Less Equal** | The depth test passes if the pixel's depth value is less than or equal to the value stored in the depth buffer. This renders the tested pixel in front of other pixels. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Greater** | The depth test passes if the pixel's depth value is greater than the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Not Equal** | The depth test passes if the pixel's depth value is not equal to the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Greater Equal** | The depth test passes if the pixel's depth value is greater than or equal to the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Always** | The depth test always passes, and Unity does not compare the pixel's depth value  to the value it has stored in the depth buffer. |
| **Depth Write** | Indicates whether Unity writes depth values for GameObjects that use this shader. Enable this property to write the depth value to the depth buffer and use a depth Fragment block. |
| **Depth Write Mode** | Determines the depth value’s input format before Unity passes it to the depth buffer. This property determines which Depth block you can use in the Fragment context. This property appears when you enable **Depth Write**. |
| &nbsp;&nbsp;&nbsp;&nbsp;**LinearEye** | Converts the depth value into a value scaled to world space. This new value represents the depth (in meters) from the near to the far plane of the Camera. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Linear01** | Uses a linear depth value range between 0 and 1. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Raw** | Does not convert the depth buffer value. Use this setting with a nonlinear depth value or when you directly sample the depth value from the depth buffer. |
| **Enable Stencil** | This property gives you control over all stencil fields. Refer to [Stencil properties](#stencil-properties) for information about the options that become available when you enable this property. |
| **Custom Editor GUI** | Accepts the full name of a C# class that inherits [`FullscreenShaderGUI`](https://docs.unity3d.com/Packages/com.unity.shadergraph@14.0/api/UnityEditor.Rendering.Fullscreen.ShaderGraph.FullscreenShaderGUI.html). For information on how to use a custom editor, refer to [ShaderLab: assigning a custom editor](https://docs.unity3d.com/2022.3/Documentation/Manual/SL-CustomEditor.html). |

## <a name="custom-blend-modes"></a>Custom Blend Mode

Use the **Custom** blend mode to create a blend mode different from those available in [Surface Options](#surface-options). To show these options, set **Blend Mode** to **Custom**. The Custom blend mode properties specify the blending operation to use for this full-screen shader’s alpha and color channels.

In the blend mode properties, **Src** (source) refers to the full-screen shader itself. **Dst** (destination) refers to the Scene camera’s raw output, which this shader doesn't affect. The blending operation applies the source contents to the destination contents to produce a rendering result.

For more information on the blending equation, refer to [ShaderLab command: Blend](https://docs.unity3d.com/Manual/SL-Blend.html).

### Color Blend Mode

Determines the blending equation Unity uses for the red, green, and blue channels (RGB). Each setting defines one part of the equation.

| **Property**        | **Description**                                              |
| ------------------- | ------------------------------------------------------------ |
| **Src Color**       | Sets the blend mode of the source color.                     |
| **Dst Color**       | Sets the blend mode of the destination color.                |
| **Color Operation** | Determines how to combine the source and destination color during the blending process. For information on these options refer to [ShaderLab command: BlendOp](https://docs.unity3d.com/Manual/SL-BlendOp.html) |

### Alpha Blend Mode

Determines the blending equation Unity uses for the alpha channel. Each setting defines one part of the equation.

| **Property**          | **Description**                                              |
| --------------------- | ------------------------------------------------------------ |
|**Src**                  | Sets the blend mode of the source alpha. For information on these options, refer to [Valid parameter values](https://docs.unity3d.com/Manual/SL-Blend.html#valid-parameter-values). |
| **Dst**                  | Sets the blend mode of the destination alpha. For information on these options, refer to [Valid parameter values](https://docs.unity3d.com/Manual/SL-Blend.html). |
| **Blend Operation Alpha** | Determines how to combine the source and destination alpha during the blending process. For more information on these options, refer to [ShaderLab command: BlendOp](https://docs.unity3d.com/Manual/SL-BlendOp.html) |

## <a name="stencil-properties"></a>Stencil properties

These properties affect how this full-screen Shader Graph uses the stencil buffer. For more information on the stencil buffer, refer to [SL-Stencil](https://docs.unity3d.com/Manual/SL-Stencil.html).

| **Property** | **Description** |
| ------------ | --------------- |
| **Reference** | Determines the stencil reference value this shader uses for all stencil operations. |
| **Read Mask** | Determines which bits this shader can read during the stencil test. |
| **Write Mask** | Determines which bits this shader can write to during the stencil test. |
| **Comparison** | Determines the comparison function this shader uses during the stencil test. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Disabled** | Does not perform a stencil test. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Never** | The stencil test never passes. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Less** | The stencil test passes if the pixel's depth value is less than the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Equal** | The stencil test passes if the pixel's depth value is equal to the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Less Equal** | The stencil test passes if the pixel's depth value is less than or equal to than the depth buffer value. This renders the tested pixel in front of other pixels. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Greater** | The stencil test passes if the pixel's depth value is greater than the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Not Equal** | The stencil test passes if the pixel's depth value is not equal to the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Greater Equal** | The stencil test passes if the pixel's depth value is greater than or equal to the value stored in the depth buffer. |
| &nbsp;&nbsp;&nbsp;&nbsp;**Always** | The stencil test always passes, and Unity does not compare the pixel's depth value to the value it has stored in the depth buffer. |
| **Pass** | Determines the operation this shader executes if the stencil test succeeds.<br/>For more information on this property’s options, refer to [pass and fail options](#stencil-pass-fail). |
| **Fail** | Determines the operation this shader executes if the stencil test fails.<br/>For more information on this property’s options, refer to [pass and fail options](#stencil-pass-fail). |
| **Depth Fail** | Determines the operation this shader executes if the depth test fails. This option has no effect if the depth test **Comparison** value is **Never** or **Disabled.**<br/>For more information on this property’s options, refer to [pass and fail options](#stencil-pass-fail). |

### <a name="stencil-pass-fail"></a>Pass and Fail options

| **Option**            | **Description**                                              |
| --------------------- | ------------------------------------------------------------ |
| **Keep**              | Does not change the current contents of the stencil buffer.  |
| **Zero**              | Writes a value of 0 into the stencil buffer.                 |
| **Replace**           | Writes the **Reference** value into the buffer.              |
| **IncrementSaturate** | Adds a value of 1 to the current value in the buffer.  A value of 255 remains 255. |
| **DecrementSaturate** | Subtracts a value of 1 from the current value in the buffer.  A value of 0 remains 0. |
| **Invert**            | Performs a bitwise NOT operation. This means it negates all the bits of the current value in the buffer.<br/>For example, a decimal value of 59 is 0011 1011 in binary. The NOT operation reverses each bit to 1100 0100, which is a decimal value of 196. |
| **IncrementWrap**     | Adds a value of 1 to the current value in the buffer. A value of 255 becomes 0. |
| **DecrementWrap**     | Subtracts a value of 1 from the current value in the buffer.  A value of 0 becomes 255. |
