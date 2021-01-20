var map;
var marker = [];
var infoWindow = [];//吹き出し
var markerData = [ // マーカーを立てる場所名・緯度・経度
    {
        name: '郡山駅',
        lat: 37.3981998,
        lng: 140.3880404
    },

    {
        name: 'イオンタウン郡山',
        lat: 37.38994892859488,
        lng: 140.38888514
    },

    {
        name: '開成山公園',
        lat: 37.39805083,
        lng: 140.35825968
    }
];


function routeSearch(position) {
    var latlon = new google.maps.LatLng(lat, lon);
    //ルート検索を行う
    var directionsService = new google.maps.DirectionsService();

    //ルート検索の結果を表示するためのオブジェクトを生成
    var directionsRenderer = new google.maps.DirectionsRenderer();

    //関連付け
    directionsRenderer.setMap(mapObj);

    //指定したマーカーの座標を指定
    var goal = position;

    //originとdestinationに変数を指定
    var request = {
        origin: latlon,
        destination: goal,
        travelMode: google.maps.TravelMode.WALKING
    };

    directionsService.route(request, function (result, status) {
        //ルート検索に成功したら以下の処理
        if (status == google.maps.DirectionsStatus.OK) {

            //ルートをマップ上に表示
            directionsRenderer.setDirections(result);
        }
    });
}


function setMap(pos) {
    // google mapへ表示するための設定
    var lat = pos.coords.latitude;
    var lon = pos.coords.longitude;

    var latlon = new google.maps.LatLng(lat, lon);
    var map = document.getElementById("baseMap");
    var opt = {
        zoom: 17,
        center: latlon,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        scrollwheel: false,
        scaleControl: true,
        disableDoubleClickZoom: true,
        draggable: true
    };

    //google map表示
    var mapObj = new google.maps.Map(map, opt);

    //マーカーを設定
    marker = new google.maps.Marker({
        position: latlon,
        map: mapObj,

    });

    //ルート検索を行う
    var directionsService = new google.maps.DirectionsService();

    //ルート検索の結果を表示するためのオブジェクトを生成
    var directionsRenderer = new google.maps.DirectionsRenderer();

    //マーカーの配置
    for (var i = 0; i < markerData.length; i++) {
        markerLatLng = new google.maps.LatLng({ lat: markerData[i]['lat'], lng: markerData[i]['lng'] }); // 緯度経度のデータ作成
        marker[i] = new google.maps.Marker({ // マーカーの追加
            position: markerLatLng, // マーカーを立てる位置を指定
            map: mapObj // マーカーを立てる地図を指定
        });

        infoWindow[i] = new google.maps.InfoWindow({ // 吹き出しの追加
            content: '<div class="facilityInfo">' + markerData[i]['name'] + '</div>' // 吹き出しに表示する内容
        });
        markerEvent(i, directionsService, directionsRenderer); // マーカーにクリックイベントを追加
    }

    
    // マーカーにクリックイベントを追加
    function markerEvent(i, directionsService, directionsRenderer) {
        marker[i].addListener('click', function () { // マーカーをクリックしたとき
            infoWindow[i].open(map, marker[i]); // 吹き出しの表示

          
            //関連付け
            directionsRenderer.setMap(mapObj);

            //目的地を指定
            //ルート検索する関数
            var goal = new google.maps.LatLng({ lat: markerData[i]['lat'], lng: markerData[i]['lng'] });
            var request = {
                origin: latlon,
                destination: goal,
                travelMode: google.maps.TravelMode.WALKING
            };

            directionsService.route(request, function (result, status) {

                //ルート検索に成功したら以下の処理
                if (status == google.maps.DirectionsStatus.OK) {

                    //ルートをマップ上に表示
                    directionsRenderer.setDirections(result);
                }
            });

        });
    }
   
    


}