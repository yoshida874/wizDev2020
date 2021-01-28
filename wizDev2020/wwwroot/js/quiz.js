var correctPosition = document.getElementById('correctPosition');
var PositionId = correctPosition.innerText;

showAlloutofCorrect();

// 最初の出題か
function isFirst() {
    var quizCount = document.getElementById('quizCount');   // x問目を取得
    // x問目からxを取り出し1と比較
    if (quizCount.innerText.substr(0, 1) !== "1") {
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
    var correct = document.getElementById('correct');
    correctBtnEmphasis();
    // 正解
    if (isCorrect(choice)) {
        correct.innerText = "正解";
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