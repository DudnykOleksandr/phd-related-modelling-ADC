using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utils.SignalGenerator;

namespace PFI.ADCConv
{
    public class CharacteristoOfTransformationParametrs
    {
        public int time {  get;  set; }
        public int beatTime {  get;  set; }
        public AnalogSignal signalSource {  get;  set; }

        public CharacteristoOfTransformationParametrs(int time, int beatTime, AnalogSignal signalSource)
        {
            this.time = time;
            this.beatTime = beatTime;
            this.signalSource = signalSource;
        }
    }
}
