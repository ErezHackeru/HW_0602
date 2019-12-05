using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW060219
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen Shmuel = new Citizen("Shmuel", 4771);
            //Children:
            Citizen c1 = new Citizen("David", 8221);
            Citizen c2 = new Citizen("Haim", 3664);
            Citizen c3 = new Citizen("Oren", 6552);

            Citizen[] AllChilds =
            {
                c1,
                c2,
                c3
            };
            Shmuel.SetChildren(AllChilds);


        }

        static bool HasChildren(Citizen Anonym)
        {
            if (Anonym._children.Length > 0)
                return true;
            else
                return false;
        }

        static bool CheckValidity(Citizen Anonym)
        {
            //bool Check = false;
            //if (Anonym._children.Length > 0)
            //{
            //    for (int i = 0; i < Anonym._children.Length; i++)
            //    {
            //        if (Anonym._id == Anonym._children[i]._fatherID)
            //            Check = true;
            //        else
            //        {
            //            Check = false;
            //            break;
            //        }
            //    }
            //}
            //return Check;
            
            //also good:
            foreach (Citizen kid in Anonym._children)
            {
                if (kid._fatherID != Anonym._id)
                    return false;
            }
            return true;
            
        }
    }
}
