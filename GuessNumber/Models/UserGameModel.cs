using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessNumber.Models
{
    public class UserGameModel
    {
        public string IP { get; set; }
        public int[] GenNumber { get; set; }
        public int Stap { get; set; }
        public int MaxStap { get; set; }
        private List<CheckNumberModel> _result { get; set; }

        public UserGameModel(string IP, int[] GenNumber, int MaxStap, int Stap)
        {
            this.IP = IP;
            this.GenNumber = GenNumber;
            this.Stap = Stap;
            this.MaxStap = MaxStap;
        }

        public bool CheckStap()
        {
            if (Stap < MaxStap) return true;
            return false;
        }

        public bool CheckFinish()
        {
            var res = true;
            if (_result.Where(s => s.Status == 'B').Count() != _result.Count)

                    res = false;
  
            return res;
        }

        public List<CheckNumberModel> CheckNumber(List<CheckNumberModel> CheckNumber)
        {
            foreach (var item in CheckNumber)
            {
                item.Status = null;
            }
            for (int i = 0; i < CheckNumber.Count; i++)
            {
                if (CheckNumber[i].Value == null)
                    continue;
                if ((int)CheckNumber[i].Value == GenNumber[i])
                {
                    CheckNumber[i].Status = 'B';
                    continue;
                }

                bool k = false;
                for (int y = 0; y < i; y++)
                {
                    if ((int)CheckNumber[i].Value == GenNumber[y])
                    {
                        CheckNumber[i].Status = 'K';
                        k = true;
                        break;
                    }
                }
                if (k) continue;
                for (int y = i + 1; y < CheckNumber.Count; y++)
                {
                    if ((int)CheckNumber[i].Value == GenNumber[y])
                    {
                        CheckNumber[i].Status = 'K';
                        break;
                    }
                }
            }

            Stap++;
            _result = CheckNumber;
            return _result;
        }
    }
}