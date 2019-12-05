using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW060219
{
    class Citizen
    {
        public string _name;
        public Citizen[] _children = new Citizen[0]; //prevent exeption
        public readonly int _fatherID;
        public readonly int _id;
        public static int _numberOfCurrentCitizens = 0;
        public const int _maximumNumberOfCitizens = 50_000;
        public static int _configuration = 1; //must be static in order to count the same way
        static Random rnd = new Random(); // happens only once
        static int[] LookUpids = new int[_maximumNumberOfCitizens];

        public Citizen(string name, int fatherID)
        {
            bool IsIdExist = true;
            int newID = rnd.Next(1, _maximumNumberOfCitizens + 1);
            _name = name;
            _fatherID = fatherID;
            _numberOfCurrentCitizens++;
            if (_configuration == 1)
                _id = _numberOfCurrentCitizens;
            else if (_configuration == 2)
            {
                while (IsIdExist)
                {
                    for (int i = 0; i < LookUpids.Length; i++)
                    {
                        if (LookUpids[i] == newID)
                        {
                            IsIdExist = true;
                            break;
                        }
                        else
                            IsIdExist = false;
                    }
                    newID = rnd.Next(1, _maximumNumberOfCitizens + 1);
                }
                _id = newID;
                LookUpids[_numberOfCurrentCitizens] = _id;
            }
        }

        public static void PrintNumberOfCitizens()
        {
            Console.WriteLine($"number Of Current Citizens: {_numberOfCurrentCitizens}");
        }
        public static bool ReachHalfOfMaximumSize()
        {
            if (_numberOfCurrentCitizens >= _maximumNumberOfCitizens)
                return true;
            else
                return false;
        }
        public void PrintID()
        {
            Console.WriteLine($"The id is: {_id}");
        }
        public void PrintGapBtweenMyIDandFather()
        {
            Console.WriteLine($"The Gap between my ID and my father is: {_id} - {_fatherID} = {_id - _fatherID}");
        }
        //Doesn't have to be in the ctor:
        public void SetChildren(Citizen[] AllCitizens)
        {
            _children = AllCitizens;
        }

        public override string ToString()
        {
            return $"Citizen {_name} id {_id} father id: {_fatherID}";
        }

    }
}
