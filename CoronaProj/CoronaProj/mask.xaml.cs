using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace CoronaProj
{
    /// <summary>
    /// mask.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class mask : Window
    {
        public mask()
        {
            InitializeComponent();
            GetList();
        }

        private void GetList()
        {
            string PreviousDate = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");    // 이전 날짜
            string CurrentDate = DateTime.Now.ToString("yyyyMMdd");     // 현재 날짜

            string apiAddress = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey=cA%2FJ%2Fr%2BJrrS6YXRqHX4RTAU3DH7meWbJf8GDl8iVnOg69HKgbhaQqkCfFzPS4HjEMsdJRRPtWkuR9pfNohAAiA%3D%3D";
            //string keyValue = "cA%2FJ%2Fr%2BJrrS6YXRqHX4RTAU3DH7meWbJf8GDl8iVnOg69HKgbhaQqkCfFzPS4HjEMsdJRRPtWkuR9pfNohAAiA%3D%3D";
            string url = string.Format("{0}&pageNo=1&numOfRows=10&startCreateDt={1}&endCreateDt={2}", apiAddress, CurrentDate, CurrentDate); // 코로나 감염경로 api url

            try
            {
                XmlDocument xml = new XmlDocument();

                xml.Load(url);

                XmlNodeList xnList = xml.SelectNodes("/response/body/items/item");       // 접근 노드

                foreach(XmlNode xn in xnList)
                {
                    string clearCnt = xn["clearCnt"].InnerText;     // 격리해제 수
                    string decideCnt = xn["decideCnt"].InnerText;     // 확진자 수
                    string deathCnt = xn["deathCnt"].InnerText;     // 사망자 수
                    string examCnt = xn["examCnt"].InnerText;     // 검사진행 수
                    string careCnt = xn["careCnt"].InnerText;     // 치료중 환자 
                    string stateDt = xn["stateDt"].InnerText;       // 기준일
                    string stateTime = xn["stateTime"].InnerText;       // 기준시간

                    int clear = Int32.Parse(clearCnt);
                    int decide = Int32.Parse(decideCnt);
                    int death = Int32.Parse(deathCnt);
                    int exam = Int32.Parse(examCnt);
                    int care = Int32.Parse(careCnt);


  

                    //DateTime.ParseExact(stateDt, "yyyy-MM-dd", null);
                    // DateTime dtState = Convert.ToDateTime(stateDt);

                    DateTime date = DateTime.ParseExact(stateDt, "yyyyMMdd", null);
                    System.Diagnostics.Debug.WriteLine(date);

                    resultText.Text = date.ToString() +" 기준 \n"+"확진자 수 : " + String.Format("{0:#,0}", decide) + "  격리해제 수 : " + String.Format("{0:#,0}", clear) + " 사망자 수 : " + String.Format("{0:#,0}", death)
                                                                    + "\n  검사진행 수 : " + String.Format("{0:#,0}", exam) + "  치료중인 환자 수 : " + String.Format("{0:#,0}", care);
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("xml parsing error\n" + ex);
            }
          
        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            MapNavigate map = new MapNavigate();
            map.Show();
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            list list = new list();
            list.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        //        http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson?serviceKey=cA%2FJ%2Fr%2BJrrS6YXRqHX4RTAU3DH7meWbJf8GDl8iVnOg69HKgbhaQqkCfFzPS4HjEMsdJRRPtWkuR9pfNohAAiA%3D%3D&pageNo=1&numOfRows=10&startCreateDt=20200629&endCreateDt=20200930
    }
}
