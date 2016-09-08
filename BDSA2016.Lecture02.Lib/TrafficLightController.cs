using System;

namespace BDSA2016.Lecture02.Lib
{
    public class TrafficLightController : ITrafficLightController
    {
        public bool MayIGo(TrafficLightColor color)
        {
            bool go;
            switch (color)
            {
                case TrafficLightColor.Green:
                    go = true;
                    break;
                case TrafficLightColor.Red:
                case TrafficLightColor.Yellow:
                    go = false;
                    break;
                default:
                    throw new ArgumentException("Unknown color, dummy", nameof(color));
            }

            return go;
        }
    }
}
