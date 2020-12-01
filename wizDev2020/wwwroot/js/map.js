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

function initMap() {
    // 地図の作成
    var mapLatLng = new google.maps.LatLng({ lat: markerData[0]['lat'], lng: markerData[0]['lng'] }); // 緯度経度のデータ作成
    map = new google.maps.Map(document.getElementById('baseMap'), { // #baseMapに地図を埋め込む
        center: mapLatLng, // 地図の中心を指定
        zoom: 15 // 地図のズームを指定
    });

    for (var i = 0; i < markerData.length; i++) {
        markerLatLng = new google.maps.LatLng({ lat: markerData[i]['lat'], lng: markerData[i]['lng'] }); // 緯度経度のデータ作成
        marker[i] = new google.maps.Marker({ // マーカーの追加
            position: markerLatLng, // マーカーを立てる位置を指定
            map: map // マーカーを立てる地図を指定
        });

        infoWindow[i] = new google.maps.InfoWindow({ // 吹き出しの追加
            content: '<div class="facilityInfo">' + markerData[i]['name'] + '</div>' // 吹き出しに表示する内容
        });
        markerEvent(i); // マーカーにクリックイベントを追加
    }
}

    // マーカーにクリックイベントを追加
    function markerEvent(i) {
        marker[i].addListener('click', function () { // マーカーをクリックしたとき
            infoWindow[i].open(map, marker[i]); // 吹き出しの表示
        });
    }
