using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;
using System.Collections;


namespace Utils.RamDevice
{
    public static partial class RAM
    {
        public static class Weights
        {
        public static double[] calibratedWeights { get; private set; }
        static NotationSystem shchvnInst;
        public static bool isInit { get; private set; }
        static Object locker;

        static Weights()
        {
            isInit = false;
            locker = new Object();
        }
        public static void InitRAMWeights(NotationSystem shchvn)
        {
            lock (locker)
            {
                isInit = true;
                shchvnInst = shchvn;
                calibratedWeights = new double[shchvnInst.n];
                // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                shchvnInst.ideal.CopyTo(calibratedWeights, 0);
            }
        }
        public static void SetCalibrated(int i, double weight1)
        {
            lock (locker)
            {
                calibratedWeights[i] = shchvnInst.ideal[i] + weight1;
            }
        }
        public static void SetCalibratedTracking(int i, double weight)
        {
            lock (locker)
            {
                calibratedWeights[i] = weight;
            }
        }
        }
    }
}
