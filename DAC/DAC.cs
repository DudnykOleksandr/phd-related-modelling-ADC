using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

using PFI.SCHVN;
using PFI.RegisterDevice;
using Utils.RamDevice;

namespace PFI.DAConv
{
    public class DAC
    {
        public NotationSystem schvn { get; private set; }
        public bool isCalibrated { get; set; }

        public DAC(int quantity, double alphaf, double delta1):this(new NotationSystem(quantity, alphaf, delta1))
        {
        }
        public DAC(NotationSystem schvn)
        {
            this.schvn = schvn;
            isCalibrated = false;
        }

        public double ZnachenyaI(Register reg)
        {
            double ekv = 0;
            for (int i = schvn.n - 1; i >= 0; i--)
            {
                ekv += reg.polinom[i] * schvn.ideal[i];
            }
            return ekv;
        }
        public double ZnachenyaC(Register reg)
        {
            double ekv = 0;
            for (int i = schvn.n - 1; i >= 0; i--)
            {
                ekv += reg.polinom[i] * RAM.Weights.calibratedWeights[i];
            }
            return ekv;
        }
        public double Convert(Register reg)
        {
            var newReg = reg.Clone();

            if (isCalibrated)
            {
                var idealValue = ZnachenyaI(newReg);

                newReg.SetPolinomNull();

                for (int ik1 = reg.n - 1; ik1 >= 0; ik1--)
                {
                    // врівноваження відбувається реальними вагами розрядів, допоки не визначені калібровані ваги
                    if (ZnachenyaC(newReg.AddBitValue(ik1, 1)) <= idealValue)
                    { }
                    else
                        newReg.AddBitValue(ik1, 0);
                }
            }

            double ekv = 0;
            for (int i = schvn.n - 1; i >= 0; i--)
            {
                ekv += newReg.polinom[i] * schvn.real[i];
            }
            return ekv;
        }
        public List<PointPairList>[] GetCharacteristicOfTransformationFullComb()
        {
            List<PointPairList> res= new List<PointPairList>();
            List<PointPairList> resSecondaryLines = new List<PointPairList>();
            Register reg = RegisterFactory.Create(schvn);
            reg.SetPolinomNull();
            PointPairList list = new PointPairList();

            for(int i=0;i< schvn.GetNumberOfCombinations()-1;i++)
            {
                double znachenyaI = ZnachenyaI(reg);
                double znachenyaR = Convert(reg);
                list.Add(znachenyaI, znachenyaR);

                reg.IncPolinom();
               
                double znachenyaI_next = ZnachenyaI(reg);
                double znachenyaR_next = Convert(reg);
                if (znachenyaI_next < znachenyaI)
                {
                    res.Add(list);
                    list = new PointPairList();
                }
            }
            res.Add(list);

            PointPairList listOfSecondary = new PointPairList();
            listOfSecondary.Add(0, 0);

            foreach (PointPairList member in res)
            {
                listOfSecondary.Add(member[0]);
                resSecondaryLines.Add(listOfSecondary);
                listOfSecondary = new PointPairList();
                listOfSecondary.Add(member[member.Count - 1]);
            }

            return new List<PointPairList>[]{res,resSecondaryLines};
        }
        public PointPairList GetCharacteristicOfTransformationStraitComb()
        {          
            Register reg = RegisterFactory.Create(schvn);
            reg.SetPolinomNull();
            PointPairList res = new PointPairList();

            for (int i = 0; i <reg.Diapason; i++)
            {
                double znachenya;

                if (isCalibrated)
                {
                    reg.AddOneCalibrated();
                }
                else
                {
                    reg.AddOne();
                }
                znachenya = Convert(reg);

                res.Add(i, znachenya);
            }
            return res;
        }
    }
}
