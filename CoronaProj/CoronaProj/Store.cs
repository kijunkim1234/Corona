using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaProj
{
    // 공공데이터 API으로부터 json 파싱한 클래스
    public class Store
    {
        // 식별코드
        public string code { get; set; }
        // 이름
        public string name { get; set; }
        // 판매처 주소
        public string addr { get; set; }
        // 판매처 유형 (약국: '01', 우체국: '02', 농협: '03'
        public string type { get; set; }
        // 위도 , wgs84 좌표계 사용 / 취소: 124.0, 최대: 132.0
        public string lat { get; set; }
        // 경도 , wgs 84 표준 / 최소: 124.0, 최대: 132.0 
        public string lng { get; set; }
        // 입고 시간
        public string stock_at { get; set; }
        // 재고 상태 ( 100개 이상 녹색('plenty') / 30개 이상 100개 미만 노랑색('some') / 1개 이하 회색('empty') 
        // 판매 중지 : 'break'
        public string remain_stat { get; set; }
        // 데이터 생성일자 Open API 기준
        public string created_at { get; set; }
    }
}
