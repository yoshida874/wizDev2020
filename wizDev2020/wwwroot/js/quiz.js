function show(btn) {
    var elem = document.getElementById('correct');
    if (btn.id === elem.innerHTML) {
        elem.innerHTML = '正解';
        elem.hidden = false;
    }
    else {
        elem.innerHTML = '不正解';
        elem.hidden = false;
    }
    hideBtns();
    document.getElementsByClassName('form-group').disabled = true;
    document.getElementById('descriptions').hidden = false;
}

function hideBtns() {
    var btns = document.querySelectorAll('input');
    for (var i = 0; i < 6; i++) {
        btns[i].disabled = true;
    }
}