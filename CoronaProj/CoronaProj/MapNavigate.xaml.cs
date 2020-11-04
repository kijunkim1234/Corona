using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using CefSharp.WinForms;
using CefSharp;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace CoronaProj
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MapNavigate : Window
    {
        static string apiURL = "https://8oi9s0nnth.apigw.ntruss.com/corona19-masks/v1/storesByAddr/json?address=";
        static string apiAddress = "";
        public MapNavigate()
        {
            InitializeComponent();
            
            string webClientResult = callWebClient();
            var r = JObject.Parse(webClientResult);
            var stores = r["stores"];
            // MessageBox.Show(stores["addr"].ToString());

    

        }

        public void InitBrowser()
        {
            // Chromium browser
            // Initialize cef with the provided setting
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
         //   Browser.Address = "https://nocorona-a2705.firebaseapp.com/";
         
        }
      
        public static List<string> calltest()
        {

            List<string> address = new List<string>();
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            using (Stream data = client.OpenRead(apiURL + apiAddress))
            {
                using (StreamReader reader = new StreamReader(data))
                {
                    

                    /*
                    JObject jo = JObject.Parse(reader.ToString());

                    string addr = (string)jo["addr"];
                    string name = (string)jo["name"];
                    
                    address.Add(addr);
                    reader.Close();
                    data.Close();
                    */
                
                    
                }
            }
            return address;
        }

        public static string callWebClient()
        {
            string result = string.Empty;
            try
            {
                WebClient client = new WebClient();

                // 특정 요청 헤더값을 추가
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = client.OpenRead(apiURL + apiAddress))
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
                // 실패시 처리 로직
                Console.WriteLine(e.ToString());
            }
            return result;
        }

        public static string callWebRequest()
        {
            string responseFromServer = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(apiURL+apiAddress);
                request.Method = "GET";
                request.ContentType = "application/json";
                // 특정 요청 헤더값을 추가
                request.Headers["user-agent"] = "Mozilla/4.0 (compatible MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    responseFromServer = reader.ReadToEnd();
                }
            }

            catch (Exception e)
            {
                // 실패 시 예외 처리
                Console.WriteLine(e.ToString());
            }
            return responseFromServer;
        }

    
        // page load 가 만료된 시점에 호출이 된다. 
        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
           {
               AddressBox.Text = e.Url;
               BackBtn.IsEnabled = Browser.CanGoBack;
               NavigateBtn.IsEnabled = !string.IsNullOrWhiteSpace(AddressBox.Text);
               ForwardBtn.IsEnabled = Browser.CanGoForward;
           }));
        }


        // 뒤로가기 버튼
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Browser.CanGoBack)
            {
                Browser.Back();
            }
        }

        // 특정페이지 주소로 이동
        private void NavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(AddressBox.Text))
            {
                Browser.Address =  AddressBox.Text;
            }
        }


        // 앞으로가기 버튼
        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            Browser.Forward();
        }
    }

}


