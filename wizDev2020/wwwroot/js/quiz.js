var correctPosition = document.getElementById('correctPosition');
var PositionId = correctPosition.innerText;
var selBtnId;

showAlloutofCorrect();

function getNum() {
    // true 10問目以降
    return (4 == quizCount.innerText.length ?
        +quizCount.innerText.substr(0, 2) : +quizCount.innerText.substr(0, 1));
}

// 最初の出題か
function isFirst() {
    var quizCount = document.getElementById('quizCount');   // x問目を取得
    var num = getNum();
    // x問目からxを取り出し1と比較
    if (1 < num) {
        return true;
    }
}

// 正答数を表示
function showAlloutofCorrect() {
    var AlloutofCorrect = document.getElementById('AlloutofCorrect');   // 正答数を取得
    if (isFirst()) {
        AlloutofCorrect.hidden = false;
    }
}

// 選択肢ボタンを無効化
function disableSelectBtns() {
    var btns = document.querySelectorAll('input');  // ボタン要素を全て取得
    // 選択肢のみ無効化
    for (var i = 0; i < btns.length - 1; i++) {
        btns[i].disabled = true;
    }
}

// 正誤の判定
function isCorrect(choice) {
    return (choice.id == PositionId ? true : false);
}

// 正解のボタンをcolorで強調表示(背景色)
function correctBtnEmphasis() {
    var correctBtn = document.getElementById(PositionId);   // 正解のボタンを取得
    var color = "#090";
    correctBtn.style.backgroundColor = color;
}

// onclick時に呼ばれる
function answer(choice) {
    selBtnId = choice.id;
    var correct = document.getElementById('correct');
    correctBtnEmphasis();
    // 正解
    if (isCorrect(choice)) {
        correct.innerHTML = "正解です";
        correct.hidden = false;
    }
    // 不正解
    else {
        // 正解の表示
        correct.hidden = false;
    }
    disableSelectBtns();
    showDescriptions();
}

// 解説の表示
function showDescriptions() {
    var descriptions = document.getElementById('descriptions');
    descriptions.hidden = false;
}

function setSelBtnId(submit) {
    submit.value = selBtnId;
    submit.hidden = true;
    // 次の問題を別のボタンで表示
    document.getElementById('ghost').hidden = false;
}