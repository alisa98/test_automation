using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public static class Triangle
    {
       

           public  static bool IsTriangle(double a, double b, double c)
            {
              
            
                if (a <= 0 || b <= 0 || c <= 0)
                    return false;
            
                return a + b > c && a + c > b && b + c > a;
                
            }
       
        
    }
}
