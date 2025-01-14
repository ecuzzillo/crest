Authoring Input Modes
=====================

Overview
--------

A number of components provide multiple authoring modes.

As a concrete example, the waves generated by the *ShapeFFT* component can be added to the world in multiple ways, including:

* **Global** - waves simply added everywhere in the world
* **Painted** - waves are painted down by hand in particular areas
* **Spline** - waves are added along a user defined spline

These are selected using the *Input Mode* dropdown on the *ShapeFFT* component, which display the valid modes for each component.

The following sections describe each mode.


Global Mode
-----------

The input simply applies everywhere.


Painted Mode
------------

.. admonition:: Preview

   This feature is in preview and may change in the future.

The painting modality allows the input to be directly hand authored into the world.
This is flexible and powerful.
Keep in mind however that this data may need modification or re-authoring if the environment changes.

Selecting *Painted* from the *Input Mode* dropdown will enable the *Paint Mode Settings* UI in the Inspector and make the painting tool available which can be enabled by either clicking the Crest Input Painting icon in the tool list, or by clicking Start Painting in the inspector.

Once painting is enabled, a cursor is displayed on the water surface at the mouse position in the Scene view.
We recommend reviewing the settings described below before painting in final data.

By left click and dragging the mouse, input can be added.
For directional input types such as flow or waves, the direction of drag will specify the direction added to the data.
On the other hand inputs like foam will simply add foam under the cursor.
To remove data, hold shift while left click dragging.

The following settings can be modified in the *Paint Mode Settings* section of the inspector, by expanding the *Paint Data* group:

* **World Size** - the size of the input area, centered at the GameObject's transform. Enable gizmos to see a wireframe outline of the area in the Scene View.
* **Resolution** - the data resolution. Higher gives more detail but takes more memory.
* **Brush Radius** - controls the radius of the brush cursor used for painting. Visualised by the cursor in the Scene View.
* **Brush Strength** - scales intensity of the brush interaction.

Some planning is advisable before committing significant time to creating the input.
The data is not currently resampled when the size/position/resolution is changed, so for example the data needs to be re-authored if the resolution is changed.

As a final note, painted data will be saved into the scene with the component.
Consider minimising data resolution and painting multiple small areas rather than one huge area whenever it makes sense.
The storage required by saving this data may be evident by a sudden increase in the size of the scene file.
While most painted input is likely to compress well into a small package size, it may still be worth creating prefabs from painted input GameObjects so that the data is stored outside the main level file.


Spline Mode
-----------

Selecting *Spline* from the *Input Mode* dropdown will enable *Spline Mode Settings* UI in the Inspector.
This mode requires a *Spline* component to be present with at least two spline points added.
Help boxes in the Inspector serve to guide/automate this setup.

Once a *Spline* is created, this is used to drive the input.
A common use of splines is to set the water level to follow a riverbed using the *RegisterHeightInput* component.
A spline may also be used to add waves or flow velocity, if this gives the required level of fidelity (if not then painting may be a good option, described in the previous section).
Another typical use case of splines is to add waves aligned to shorelines.

Relevant data components will automatically be added to spline points.
For example if the spline is used with a *RegisterFlowInput* component, the *Spline Point Data Flow* component will be added to spline points which can then be used to configure the flow speed.


Custom Geometry and Shader Mode
-------------------------------

This is the most advanced type of input and allows rendering any geometry/shader into the water system data.
One could draw foam directly into the foam data, or inject a flow map baked from an offline sim.

The geometry can come from a standard *MeshRenderer*/*MeshFilter* combination, or it can come from any *Renderer* component such as a particle system.
This geometry will be rendered from a orthographic top down perspective to "print" the data onto the water.

The *Particle Renderer* example in the *Examples* scene shows a particle system being projected onto the water surface.


Primitive Mode
--------------

Use a primitive shape for the input such as a mathematical cube or sphere.

Used for surface clipping - the volume defined by the primitive shape will be cut from the water surface.
