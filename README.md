# Unity3D Face Tracking Package
Originally built at [HackMIT 2021](https://hackmit.org/) in the health care track, this package allows for simple facial tracking, providing an ease-of-use alternative for developers building therapeutic games that take advantage of [facial muscular reeducation](https://pubmed.ncbi.nlm.nih.gov/18470837/) to help Bell's Palsy, Parkinson's, and Stroke patients.

![Tracking.gif](README/Tracking.gif)

## Setup
1. In the desired Unity3D project, import the [OpenCV plus Unity package](https://assetstore.unity.com/packages/tools/integration/opencv-plus-unity-85928), which is free from the Asset Store.
2. Download all of the files in the [package directory](https://github.com/genkikadomatsu/unity3d-face-tracking/tree/main/package) of this repository and place them in the Assets folder of the Unity3D project.
3. Create a plane object in the Unity3D Scene and attach the FaceDetector.cs script to the plane.
4. On start, the plane should display video feed of the first detected webcam device along with rectangular regions outlining the face and facial features.

## Usage
The package detects the face, eyes, and mouth regions, outlining them with rectangles. The rectangles are OpenCvSharp.Rect instances. More documentation on [OpenCv](https://opencv.org/) and [OpenCvSharp](https://shimat.github.io/opencvsharp_docs/html/d69c29a1-7fb1-4f78-82e9-79be971c3d03.htm) can be found online.

## Limitations
Due to time limitations—in its current state, this 'package' is more of a collection of scripts. See below.

## Future and Current Developments
Did not get a chance to spend much time on this, but ideally, the sample script will eventually be extended and matured into a library that exposes functionality that makes it easy to
- detect certain facial expressions,
- detect the movement of facial features,
- identify unique faces within a scene,
  
and so on, so that game developers can easily import and leverage these features.
