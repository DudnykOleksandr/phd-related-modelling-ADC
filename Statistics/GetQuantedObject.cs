using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using Algorithm.UsefulMethods.Extensions;

namespace Utils.Statistics
{
    public class GetQuantedObject
    {
        //дає змогу на основі масиву даних будувати розподіл (типу норрмальний тосьо)
        double[] RozpodilY;
        double[] RozpodilX;

        double StepInl;

        public GetQuantedObject(double StepQuant, PointPairList values)
        {
            StepInl = StepQuant;

            double[] valuesY = values.PointPairListGetY();

            int KilInt = (int)((MasFunctions.GetMax(valuesY) -
            MasFunctions.GetMin(valuesY)) / StepInl);

            RozpodilY = new double[KilInt];
            RozpodilX = new double[KilInt];

            double LastValue = MasFunctions.GetMin(valuesY);
            double sum = 0;

            for (int i = 0; i < KilInt; i++)
            {
                RozpodilY[i] =
                    MasFunctions.HowNanyInThisInterval(LastValue, LastValue + StepInl, valuesY);
                sum += RozpodilY[i];
                RozpodilX[i] = LastValue + StepInl / 2.0;
                LastValue += StepInl;
            }
            //щоб обрахувати імовірність потрапляння похибки в певний діапазон ділимо 
            // кількість попадінь похибки і діапазон на всю кількість попадінь похибки
            for (int i = 0; i < KilInt; i++)
            {
                RozpodilY[i] = RozpodilY[i] / (sum * StepInl);
            }
            // для обрахунку щільності імовірності в наближеному випадку можемо поділити імовірність того,
            // що величина потрапить в певний діапазон на величину цього діапазону
        }
        public double[] GetMasX()
        {
            return RozpodilX;
        }
        public double[] GetMasY()
        {
            return RozpodilY;
        }

    }

}
