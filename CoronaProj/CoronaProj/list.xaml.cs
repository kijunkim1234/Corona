using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace CoronaProj
{
    /// <summary>
    /// list.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class list : Window
    {
        

        const string apiUrl = "https://8oi9s0nnth.apigw.ntruss.com/corona19-masks/v1/storesByAddr/json?address=";
        public string apiAddress;
        public string apiRes;

        // excel 파일로 저장하기
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;
        List<Store> LStore = new List<Store>();

        public int count;
        public list()
        {
            InitializeComponent();

        }

        public void GetList()
        {
            LStore.Clear();
            string webClientResult = callWebClient();

            var r = JObject.Parse(webClientResult);

            var stores = r["stores"];
            //System.Diagnostics.Debug.WriteLine(r["stores"]);
            //System.Diagnostics.Debug.WriteLine(r["count"]);

            var storeCount = r["count"];        // 판매처 총 개수
            count = Int32.Parse(storeCount.ToString());

           // MessageBox.Show(r["count"].ToString());


            for (int i = 0; i < count; i++)
            {
                try
                {
                    switch (stores[i]["remain_stat"].ToString())
                    {
                        case "plenty":
                            stores[i]["remain_stat"] = "100개 이상";
                            break;
                        case "some":
                            stores[i]["remain_stat"] = "30개 이상";
                            break;
                        case "few":
                            stores[i]["remain_stat"] = "2개 이상";
                            break;
                        default:
                            stores[i]["remain_stat"] = "재고 없음";
                            break;
                    }
                }

                catch (NullReferenceException e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }



                try
                {
                    switch (stores[i]["type"].ToString())
                    {
                        case "01":
                            stores[i]["type"] = "약국";
                            break;
                        case "02":
                            stores[i]["type"] = "우체국";
                            break;
                        default:
                            stores[i]["type"] = "농협";
                            break;
                    }


                    LStore.Add(new Store()
                    {
                        code = stores[i]["code"].ToString(),
                        name = stores[i]["name"].ToString(),
                        addr = stores[i]["addr"].ToString(),
                        remain_stat = stores[i]["remain_stat"].ToString(),
                        stock_at = stores[i]["stock_at"].ToString(),
                        type = stores[i]["type"].ToString(),
                        lat = stores[i]["lat"].ToString(),
                        lng = stores[i]["lng"].ToString()


                    });
                }
                // json 데이터 자체에 비정상적인 값이 섞여 있어 특정 주소로 검색할 경우 참조 오류 발생
                catch (NullReferenceException e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                }
            }

            // ListView에 차곡차곡 저장
            ListView01.ItemsSource = LStore;
            ListView01.Items.Refresh();     // 갱신 안할 시 InvalidOperationException 발생
        }

    public string callWebClient()
        {
            string result = string.Empty;
            try
            {
                WebClient client = new WebClient();

                //특정 요청 헤더값을 추가해준다. 
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = client.OpenRead(apiRes))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();
                        result = s;

                        reader.Close();
                        data.Close();
                    }
                }

            }
            catch (Exception e)
            {
                //통신 실패시 처리로직
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            return result;
        }



        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            apiAddress = SearchText.Text;
            apiRes = apiUrl + apiAddress;
            //MessageBox.Show(apiRes);
            GetList();


        }

        private void SaveListView_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 바탕화면 경로 
                string path = System.IO.Path.Combine(desktopPath, "MaskSearch.xlsx");


 

                excelApp = new Excel.Application(); // 워크 어플리케이션 추가
                workBook = excelApp.Workbooks.Add();    // 워크북 추가
                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;     // 엑셀 첫번쨰 워크시트 가져오기

                workSheet.Cells[1, 1] = "판매처 코드번호"; workSheet.Cells[1, 2] = "판매처 이름";
                workSheet.Cells[1, 3] = "판매처 주소"; workSheet.Cells[1, 4] = "재고 보유 현황";
                workSheet.Cells[1, 5] = "입고 시간"; workSheet.Cells[1, 6] = "판매처 타입";
                workSheet.Cells[1, 7] = "판매처 위도"; workSheet.Cells[1, 8] = "판매처 경도";


               
                for (int i = 0; i < count; i++)
                {
                    workSheet.Cells[2 + i, 1] = LStore[i].code;
                    workSheet.Cells[2 + i, 2] = LStore[i].name;
                    workSheet.Cells[2 + i, 3] = LStore[i].addr;
                    workSheet.Cells[2 + i, 4] = LStore[i].remain_stat;
                    workSheet.Cells[2 + i, 5] = LStore[i].stock_at;
                    workSheet.Cells[2 + i, 6] = LStore[i].type;
                    workSheet.Cells[2 + i, 7] = LStore[i].lat;
                    workSheet.Cells[2 + i, 8] = LStore[i].lng;

                }

                workSheet.Columns.AutoFit();
                workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                workBook.Close(true);
                excelApp.Quit();
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
            MessageBox.Show("Excel 파일 생성 완료");
        }

        // 액셀 객체 헤제 
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);      // Excel 객체 해제
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();           // 가비지 컬렉션
            }
        }
    }
}

        
        
        // https://8oi9s0nnth.apigw.ntruss.com/corona19-masks/v1/storesByAddr/json?address=%EC%A0%84%EB%9D%BC%EB%B6%81%EB%8F%84%20%EC%A0%84%EC%A3%BC%EC%8B%9C%20%EB%8D%95%EC%A7%84%EA%B5%AC%20%EC%9D%B8%ED%9B%84%EB%8F%991%EA%B0%80

    

