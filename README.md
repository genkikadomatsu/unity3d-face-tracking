# Unity3D Face Tracking Package

Originally build at [HackMIT](https://hackmit.org/) in the health care track, this package allows for simple facial tracking, providing an ease-of-use alternative for developers building games that take advantage of [facial muscular reeducation therapy](https://pubmed.ncbi.nlm.nih.gov/18470837/) to help Bell's Palsy, Parkinson's, and Stroke patients.

![Tracking.gif](README/Tracking.gif)

## Setup

1. In the desired Unity3D project, import the [OpenCV plus Unity package](https://assetstore.unity.com/packages/tools/integration/opencv-plus-unity-85928), which is free from the Asset Store.
2. Download all of the files in the [package directory](https://github.com/genkikadomatsu/unity3d-face-tracking/tree/main/package) of this repository and place them in the Assets folder of the Unity3D project.
3. Create a plane object in the Unity3D Scene and attach the FaceDetector.cs script to the plane.
4. On start, the plane should display video feed of the first detected webcam device along with rectangular regions outlining the face and facial features.

## Usage

The package detects the face, eyes, and mouth regions, outlining them with rectangles. The rectangles are OpenCvSharp.Rect instances. More documentation on [OpenCv and](https://opencv.org/) [OpenCvSharp](https://shimat.github.io/opencvsharp_docs/html/d69c29a1-7fb1-4f78-82e9-79be971c3d03.htm) can be found online.

## Limitations
The package currently only allows for frontal face detection and classification in the form of rectangular regions. Sometimes the detected regions can briefly jump to incorrect areas of the video so ensuring consistency between frames is adviced.

## Future Work
Work is currently being done to generalize this package to track multiple faces and to provide more precise facial geometry detection.
