using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp; //OpenCV Library

public class FaceDetector : MonoBehaviour
{

    WebCamTexture video;
    
    //Haar cascade classifiers
    CascadeClassifier faceClassifier; 
    CascadeClassifier eyeClassifier;
    CascadeClassifier mouthClassifier;

    //Detected faces and features
    public OpenCvSharp.Rect[] faces;
    public OpenCvSharp.Rect[] eyes;
    public OpenCvSharp.Rect[] mouths;
    
    //Selected face and features
    OpenCvSharp.Rect FaceBorder;
    OpenCvSharp.Rect[] EyeBorder;
    OpenCvSharp.Rect MouthBorder;

    //Texture with drawn regions
    Texture newtexture;
    
    //The video frame
    Mat frame;
    
    //The face frame passed to classify eyes and mouth features
    Mat subFrame;

    // Start is called before the first frame update
    void Start()
    {
        //Get video
        WebCamDevice[] devices = WebCamTexture.devices;
        video = new WebCamTexture(devices[0].name);
        video.Play();
        faceClassifier = new CascadeClassifier(Application.dataPath + @"/haarcascade_frontalface_default.xml");
        eyeClassifier = new CascadeClassifier(Application.dataPath + @"/haarcascade_eye.xml");
        mouthClassifier = new CascadeClassifier(Application.dataPath + @"/haarcascade_mouth.xml");
    }

    // Update is called once per frame
    void Update()
    {
        frame = OpenCvSharp.Unity.TextureToMat(video);
        detect(frame);
        display(frame);
    }


    //Detect the face and facial features
    void detect(Mat frame)
    {
        faces = faceClassifier.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.FindBiggestObject);
        if (faces.Length >= 1)
        {
            subFrame = frame.SubMat(faces[0]);
            eyes = eyeClassifier.DetectMultiScale(subFrame, 1.1, 2, HaarDetectionType.ScaleImage);
            mouths = mouthClassifier.DetectMultiScale(subFrame, 1.1, 2, HaarDetectionType.FindBiggestObject);

            if (eyes.Length >= 2 && mouths.Length >= 1)
            {
                FaceBorder = faces[0];

                eyes[0].Y += faces[0].Y;
                eyes[0].X += faces[0].X;
                eyes[1].Y += faces[0].Y;
                eyes[1].X += faces[0].X;
                EyeBorder = eyes;

                mouths[0].Y += faces[0].Y;
                mouths[0].X += faces[0].X;
                if (mouths[0].Top >= eyes[0].Bottom)
                    MouthBorder = mouths[0];
            }
        }
    }


    //Display the detected regions on the video frame
    void display(Mat frame)
    {
        if (FaceBorder != null)
        {
            frame.Rectangle(FaceBorder,   new Scalar(0, 250, 0), 2);
            frame.Rectangle(EyeBorder[0], new Scalar(0, 250, 250), 2);
            frame.Rectangle(EyeBorder[1], new Scalar(0, 250, 250), 2);
            frame.Rectangle(MouthBorder, new Scalar(250, 0, 250), 2);
            
        }

        newtexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newtexture;
    }
}


