using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//컨트롤러 같은 것
namespace ParkingCarManager
{

    //메소드들은 전부 클래스 메소드
    //인스턴스 따로 만들거나 상속 받는 게 없다
    //하나의 변수만 쓸 것
    public class DataManager
    {
       public static List<ParkingCar> Cars
            =new List<ParkingCar>();


        static DataManager()
        {
            Load();
        }

        public static void Load()
        {

        }

        public static void printLog(string contents)
        {
            DirectoryInfo di = new DirectoryInfo("ParkingHistory");

            if(di.Exists == false)
                di.Create();
            using(StreamWriter w = new StreamWriter("ParkingHistory\\ParkingHistory.txt", true)) 
            { 
                w.WriteLine(contents);
            }
        }
    }
}
